using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureTest
{
    class Cylinder
    {
        double height, diameter;

        public Cylinder(double height, double diameter)
        {
            this.height = height;
            this.diameter = diameter;
        }

        internal double Height { get { return height; } }

        internal double Diameter { get { return diameter; } }
    }

}

