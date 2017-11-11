using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureTest
{
    class Subject
    {

        double x, y, z;

        internal double X { get { return x; } }

        internal double Y { get { return y; } }

        internal double Z { get { return z; } }

        public Subject(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
