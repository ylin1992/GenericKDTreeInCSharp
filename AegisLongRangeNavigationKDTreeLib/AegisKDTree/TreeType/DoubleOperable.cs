using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisLongRangeNavigationKDTreeLib.AegisKDTree.TreeType
{
    public class DoubleOperable : Operable<double>
    {
        public override double Abs(double o1)
        {
            return Math.Abs(o1);
        }

        public override double Add(double o1, double o2)
        {
            return o1 + o2;
        }

        public override int Compare(double o1, double o2)
        {
            return o1.CompareTo(o2);
        }

        public override double Divide(double o1, double o2)
        {
            return o1 / o2;
        }

        public override double InitialVal()
        {
            return 0.0;
        }

        public override double Minus(double o1, double o2)
        {
            return o1 - o2;
        }

        public override double Multiply(double o1, double o2)
        {
            return o1 * o2;
        }

        public override double Sqrt(double o1)
        {
            return Math.Sqrt(o1);
        }

        public override double Square(double o1)
        {
            return o1 * o1;
        }
    }
}
