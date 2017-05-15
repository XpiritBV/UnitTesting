using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTesting.ClassLibrary.Mocking
{
    /// <summary>
    /// Repository implementation.
    /// (Imagine that this connects to a database server on the network.)
    /// </summary>
    public class DefaultRepository : IRepository
    {
        public Task<IEnumerable<Shape>> GetAllShapes()
        {
            throw new TimeoutException("Failed to connect to the database.");
        }

        public Task<IEnumerable<Shape>> GetShapeByArea(double minimumArea)
        {
            throw new TimeoutException("Failed to connect to the database.");
        }      
    }
}