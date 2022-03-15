using System;
using System.Collections.Generic;
using System.Text;

namespace AegisLongRangeNavigationKDTreeLib.AegisKDTree.TreeType
{
    public class FloatOperable : Operable<float>
    {
        public override float Abs(float o1)
        {
            return Math.Abs(o1);
        }

        public override float Add(float o1, float o2)
        {
            return o1 + o2;
        }

        public override int Compare(float o1, float o2)
        {
            return o1.CompareTo(o2);
        }

        public override float Divide(float o1, float o2)
        {
            return o1 / o2;
        }

        public override float InitialVal()
        {
            return 0.0f;
        }

        public override float Minus(float o1, float o2)
        {
            return o1 - o2;
        }

        public override float Multiply(float o1, float o2)
        {
            return o1 * o2;
        }

        public override float Sqrt(float o1)
        {
            return (float)Math.Sqrt((double)o1);
        }

        public override float Square(float o1)
        {
            return o1 * o1;
        }
    }
}
