using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AegisLongRangeNavigationKDTreeLib.AegisKDTree.TreeType
{
    public interface IOperable<T>
    {
        public abstract T InitialVal();
        public abstract T Add(T o1, T o2);
        public abstract T Minus(T o1, T o2);
        public abstract T Multiply(T o1, T o2);
        public abstract T Divide(T o1, T o2);
        public abstract T Square(T o1);
        public abstract T Sqrt(T o1);
        public abstract int Compare(T o1, T o2);
        public abstract T Abs(T o1);
    }

}
