using System;

namespace UnitTesting.ClassLibrary.Mocking
{
    public sealed class Circle : Shape
    {
        //deliberate bug here

        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
            Area = Math.PI * Math.Sqrt(radius);
        }
    }
}