namespace UnitTesting.ClassLibrary.Mocking
{
    /// <summary>
    /// Abstract base for shapes.
    /// Defines that shapes have an area.
    /// </summary>
    public abstract class Shape
    {
        //make this read-only
        public double Area { get; set; }

        public abstract string Name { get; set; }
    }
}