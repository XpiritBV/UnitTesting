using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTesting.ClassLibrary.Mocking
{
    public interface IRepository
    {
        /// <summary>
        /// Connects to a database server on the network and returns all shapes.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Shape>> GetAllShapes();

        /// <summary>
        /// Connects to a database server on the network and returns all shapes that have an area larger than <paramref name="minimumArea"/>.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Shape>> GetShapeByArea(double minimumArea);
    }
}

