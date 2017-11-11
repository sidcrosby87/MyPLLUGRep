using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        static void Push(Aperture aperture, Cylinder cylinder)
        {
            if (cylinder.Height <= aperture.X || cylinder.Height <= aperture.Y)
            {
                Console.WriteLine("\nOperation succeeded!");
                return;
            }

            else if (cylinder.Diameter <= aperture.GetSmallestSide())
            {
                Console.WriteLine("\nOperation succeeded!");
                return;
            }

            Console.WriteLine("\nOperation failed");
        }

        static void Main(string[] args)
        {
            double a, b, x, y, z;

            while (true)
            {
                Console.WriteLine("Please choose type of subject: \n1.Brick\n2.Cylinder");

                try
                {
                    int choise = Convert.ToInt32(Console.ReadLine());
                    if (choise == 1)
                    {
                        Console.Write("\n");
                        Console.WriteLine("Please set aperture side1: ");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("side2: ");
                        b = Convert.ToDouble(Console.ReadLine());

                        Aperture aperture = new Aperture(a, b);

                        Console.WriteLine("Set subject param1: ");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("param2: ");
                        y = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("param3: ");
                        z = Convert.ToDouble(Console.ReadLine());

                        Subject subject = new Subject(x, y, z);

                        Push(aperture, subject);
                        break;
                    }


                    else if (choise == 2)
                    {
                        Console.Write("\n");
                        Console.WriteLine("Please set aperture side1: ");
                        a = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("side2: ");
                        b = Convert.ToDouble(Console.ReadLine());

                        Aperture aperture = new Aperture(a, b);

                        Console.WriteLine("Set cylinder's height: ");
                        x = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Set cylinder's diameter: ");
                        y = Convert.ToDouble(Console.ReadLine());

                        Cylinder cylinder = new Cylinder(x, y);

                        Push(aperture, cylinder);
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Wrong choise. Please try again");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nYou can set only integer values! Please try again");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}

