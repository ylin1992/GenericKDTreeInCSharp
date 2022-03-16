using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisLongRangeNavigationKDTreeLib.AegisKDTree
{
    public class KDNode<TKey, TValue> where TKey : IComparable
    {
        public KDNode<TKey, TValue> Left { get; private set; }
        public KDNode<TKey, TValue> Right { get; private set; }
        public List<TKey> Coord { get; private set; }

        public TValue Value { get; private set; }
        public int NumDimensions { get; private set; }
        
        public KDNode(Tuple<List<TKey>, TValue> tuple)
        {
            if (tuple == null)
            {
                throw new ArgumentException("KeyValuePair should not be null and Count should be greater than 0");
            }
            List<TKey> coord = tuple.Item1;
            TValue val = tuple.Item2;
            
            if (coord == null || coord.Count == 0)
            {
                throw new ArgumentException("Coordinate array should not be null and Count should be greater than 0");
            }

            if (val == null)
            {
                throw new ArgumentException("Value should not be null and Count should be greater than 0");

            }

            this.Coord = coord;
            this.NumDimensions = coord.Count;
            this.Value = val;
        }

        public void Add(KDNode<TKey, TValue> newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException("Inserted Node should not be null");
            }
            Add(newNode, 0);
        }

        private void Add(KDNode<TKey, TValue> newNode, int curDimension)
        {
            // if newNode.Coord[k] < this.Coord[k]
            if (newNode.GetKeyByDimension(curDimension).CompareTo(this.GetKeyByDimension(curDimension)) < 0)
            {
                if (Left == null)
                    Left = newNode;
                else
                    Left.Add(newNode, curDimension + 1);
            }
            else
            {
                if (Right == null)
                    Right = newNode;
                else
                    Right.Add(newNode, curDimension + 1);
            }
        }

        public TKey GetKeyByDimension(int k)
        {
            return Coord[k % NumDimensions];
        }

        public override string ToString()
        {
            string res = "{[";
            foreach (TKey coord in Coord)
            {
                res += coord.ToString() + " ";
            }
            res += "], Dim: ";
            res += Coord.Count.ToString();
            res += "}";
            return res;
        }
    }
}
