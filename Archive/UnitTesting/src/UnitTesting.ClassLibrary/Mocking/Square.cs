using System;

namespace UnitTesting.ClassLibrary.Mocking
{
    public sealed class Square : Shape
    {
        //deliberate bug here

        public double Width { get; set; }

        public double Height { get; set; }

        public override string Name { get; set; }

        public Square(double width, double height)
        {
            if (width < 0d) throw new ArgumentOutOfRangeException(nameof(width));
            if (height < 0d) throw new ArgumentOutOfRangeException(nameof(height));
            Width = width;
            Height = height;
            Area = width * height;           
        }
    }
}