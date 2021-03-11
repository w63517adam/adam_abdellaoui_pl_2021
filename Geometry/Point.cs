using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IReflectable
    {
        public void ReflectX();
        public void ReflectY();
    }
    public class Point : IReflectable
    {
        public double X
        {
            get
            {
                return X;
            }

            private set
            {
                X = value;
            }
        }

        public double Y
        {
            get
            {
                return Y;
            }

            private set
            {
                Y = value;
            }
        }

        public Point(double x)
        {
            X = x;
            Y = 0;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        void IReflectable.ReflectX()
        {
            Y = Y * -1;
        }

        void IReflectable.ReflectY()
        {
            X = X * -1;
        }
    }
}
