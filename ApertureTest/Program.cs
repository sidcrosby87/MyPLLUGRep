using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureTest
{
    class Program
    {
        private static bool CheckDiagonal(Aperture aperture, Subject subject)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(aperture.X, 2) + Math.Pow(aperture.Y, 2));

            if (
                hypotenuse >= subject.X && hypotenuse >= subject.Y ||
                hypotenuse >= subject.X && hypotenuse >= subject.Z ||
                hypotenuse >= subject.Y && hypotenuse >= subject.Z 
                )
                return true;

            return false;

        }

        static void Push(Aperture aperture, Subject subject)
        {
            int n = 0;

            List<double> subjectSidesList = new List<double>(3) { subject.X, subject.Y, subject.Z };

            List<double> apertureSidesList = new List<double>(2) { aperture.X, aperture.Y };

            foreach (var subjectSide in subjectSidesList)
            {
                foreach (var apertureSide in apertureSidesList)
                {
                    if (subjectSide <= apertureSide)
                    {
                        n++;
                        break;
                    }
                }
            }


            if (n >= 2)
            {
                Console.WriteLine("\nOperation succeeded!");
            }
            else if (CheckDiagonal(aperture, subject))
            {
                Console.WriteLine("\nOperation succeeded!");
            }
            else
            {
                Console.WriteLine("\nOperation failed");
            }

        }

        static void Main(string[] args)
        {
            double a, b, x, y, z;

            Console.WriteLine("Set subject param1: ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("param2: ");
            y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("param3: ");
            z = Convert.ToDouble(Console.ReadLine());

            Subject subject = new Subject(x, y, z);

            Console.Write("\n");
            Console.WriteLine("Please set aperture side1: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("side2: ");
            b = Convert.ToDouble(Console.ReadLine());

            Aperture aperture = new Aperture(a, b);

            Push(aperture, subject);
        }
    }
}
