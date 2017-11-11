using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureTest
{
    class Aperture
    {
        double x;
        double y;

        internal double X { get { return x; } }

        internal double Y { get { return y; } }

        public Aperture(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
