using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisLongRangeNavigationKDTree.AegisKDTree.TreeType
{
    public abstract class Operable<T> : IOperable<T>
    {
        public abstract T Abs(T o1);
        public abstract T Add(T o1, T o2);
        public abstract int Compare(T o1, T o2);
        public abstract T Divide(T o1, T o2);
        public abstract T InitialVal();
        public abstract T Minus(T o1, T o2);
        public abstract T Multiply(T o1, T o2);
        public abstract T Sqrt(T o1);
        public abstract T Square(T o1);

    }
}
