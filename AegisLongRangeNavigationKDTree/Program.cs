using System;
using System.Collections.Generic;
using AegisLongRangeNavigationKDTreeLib.AegisKDTree;
using AegisLongRangeNavigationKDTreeLib.AegisKDTree.TreeType;
namespace AegisLongRangeNavigationKDTree
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] nodes = new double[][] {
                new double[] { 10, 10},
                new double[] { 50, 20},
                new double[] { 100, 20},
                new double[] { 30, 30},
                new double[] { 40, 20},
                new double[] { 100, 100},
            };

            //KDNode<double, int> kDNode = 
            //    new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[0]), 1));
            //for (int i = 1; i < nodes.Length; i++)
            //{
            //    kDNode.Add(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[i]), i)));
            //}
            //Console.WriteLine(kDNode);

            //// Test List of Nodes
            //List<KDNode<double, int>> listOfNodes = new List<KDNode<double, int>>();
            //listOfNodes.Add(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[0]), 0)));
            //listOfNodes.Add(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[1]), 1)));
            //listOfNodes.Add(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[2]), 2)));
            //listOfNodes.Add(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[3]), 3)));
            //listOfNodes.Add(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[4]), 4)));
            //KDTree<double, int> tree = new KDTree<double, int>(listOfNodes);

            KDTree<double, int> treee = new KDTree<double, int>(2, new DoubleOperable());
            for (int i = 0; i < nodes.Length; i++)
                treee.Insert(new KDNode<double, int>(new Tuple<List<double>, int>(new List<double>(nodes[i]), i)));

            KDNode<double, int> n1 =  treee.GetNearestNeighbor(new double[] { 5, 5});
            KDNode<double, int> n2 = treee.GetNearestNeighbor(new double[] { 50, 25 });
            KDNode<double, int> n3 = treee.GetNearestNeighbor(new double[] { 100, 5 });
            Console.ReadLine();
        }
    }
}
