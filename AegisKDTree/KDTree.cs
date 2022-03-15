using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AegisLongRangeNavigationKDTree.AegisKDTree.TreeType;

namespace AegisLongRangeNavigationKDTree.AegisKDTree
{
    class KDTree<TKey, TValue> where TKey : IComparable
    {
        public KDNode<TKey, TValue> Root { get; private set; }
        public int Depth { get; private set; }
        public int Count { get; private set; }
        public int NumDimensions { get; private set; }

        private IOperable<TKey> _operations;

        public KDTree(int numDimensions, IOperable<TKey> op)
        {
            if (op == null)
                throw new ArgumentNullException();
            _operations = op;
            NumDimensions = numDimensions;
        }

        public KDTree(KDNode<TKey, TValue> root, IOperable<TKey> op)
        {
            if (root == null || op == null)
            {
                throw new ArgumentNullException("root and Operable object should not be null.");
            }
            _operations = op;
            Root = root;
            NumDimensions = root.NumDimensions;
        }

        /// <summary>
        /// Constuctor for a list of nodes
        /// </summary>
        /// <param name="listOfNodes"></param>
        public KDTree(List<KDNode<TKey, TValue>> listOfNodes, IOperable<TKey> op)
        {
            if (listOfNodes == null || op == null)
            {
                throw new ArgumentNullException("Operable and List of Nodes should not be null.");
            }

            if (listOfNodes.Count == 0)
            {
                throw new ArgumentException("Length of the list should greater than zero.");
            }
            _operations = op;
            NumDimensions = listOfNodes[0].NumDimensions;
            Root = listOfNodes[0];
            for (int i = 1; i < listOfNodes.Count; i++)
            {
                Root.Add(listOfNodes[i]);
            }
        }

        public void Insert(KDNode<TKey, TValue> newNode)
        {
            if (Root == null)
                Root = newNode;
            else
                Root.Add(newNode);
        }
        public KDNode<TKey, TValue> GetNearestNeighbor(TKey[] target)
        {
            if (target == null || target.Length != NumDimensions)
            {
                throw new ArgumentException("Invalid target, null or length != num of dimensions"); 
            }
            return GetNearestNeighbor(Root, target, 0);
        }
        public KDNode<TKey, TValue> GetNearestNeighbor(KDNode<TKey, TValue> target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// PRE: root.NumDimensions == target.Length
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="d"> current depth, can be used for dimension </param>
        /// <returns></returns>
        private KDNode<TKey, TValue> GetNearestNeighbor(KDNode<TKey, TValue> root, TKey[] target, int d)
        {
            if (root == null) return null;

            bool isGoLeft = _operations.Compare(target[d % NumDimensions], root.GetKeyByDimension(d)) < 0;
            KDNode<TKey, TValue> next = isGoLeft ? root.Left : root.Right;
            KDNode<TKey, TValue> other = isGoLeft ? root.Right : root.Left;

            KDNode<TKey, TValue> returned = GetNearestNeighbor(next, target, d + 1);
            KDNode<TKey, TValue> closestNode = getCloserNode(returned, root, target);

            // Check if the distance from the current root node to the target in the current dimension
            // is smaller than the distance from the closest node to the target node
            // If so, traverse the other branch
            TKey distFromClosestToTarget = getDistSquare(closestNode, target);
            TKey distFromRootToTarget = _operations.Abs
                (_operations.Minus(root.GetKeyByDimension(d), target[d % NumDimensions]));

            if (_operations.Compare(distFromRootToTarget, _operations.Square(distFromRootToTarget)) >= 0)
            {
                returned = GetNearestNeighbor(next, target, d + 1);
                closestNode = getCloserNode(returned, root, target);
            }

            return closestNode;
        }

        private KDNode<TKey, TValue> getCloserNode(KDNode<TKey, TValue> n1, KDNode<TKey, TValue> n2, TKey[] target)
        {
            if (n1 == null) return n2;
            if (n2 == null) return n1;

            TKey d1 = getDistSquare(n1, target);
            TKey d2 = getDistSquare(n2, target);
            return _operations.Compare(d1, d2) < 0 ? n1 : n2;
        }

        private TKey getDistSquare(KDNode<TKey, TValue> node, TKey[] target)
        {
            TKey res = _operations.InitialVal();
            for (int i = 0; i < target.Length; i++)
            {
                TKey diff = _operations.Minus(node.GetKeyByDimension(i), target[i]);
                res = _operations.Add(_operations.Square(diff), res);
            }
            return res;
        }
    }
}
