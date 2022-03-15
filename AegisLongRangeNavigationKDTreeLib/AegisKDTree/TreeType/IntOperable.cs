using System;
using System.Collections.Generic;
using System.Text;

namespace AegisLongRangeNavigationKDTreeLib.AegisKDTree.TreeType
{
    public class IntOperable : Operable<int>
    {
        public override int Abs(int o1)
        {
            return Math.Abs(o1);
        }

        public override int Add(int o1, int o2)
        {
            return o1 + o2;
        }

        public override int Compare(int o1, int o2)
        {
            return o1.CompareTo(o2);
        }

        public override int Divide(int o1, int o2)
        {
            return o1 / o2;
        }

        public override int InitialVal()
        {
            return 0;
        }

        public override int Minus(int o1, int o2)
        {
            return o1 - o2;
        }

        public override int Multiply(int o1, int o2)
        {
            return o1 * o2;
        }

        /// <summary>
        /// Should be really careful about possibly lossy information
        /// </summary>
        /// <param name="o1"></param>
        /// <returns></returns>
        public override int Sqrt(int o1)
        {
            return (int)Math.Sqrt(o1);
        }

        public override int Square(int o1)
        {
            return o1 * o1;
        }
    }
}
