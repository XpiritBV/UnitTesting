using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting.ClassLibrary.Mocking
{
    public class Program
    {
        private readonly IRepository _defaultRepository;

        public Program(IRepository repository = null)
        {
            _defaultRepository = repository ?? new DefaultRepository();
        }

        public Task<IEnumerable<Shape>> GetShapesAsync()
        {
            return _defaultRepository.GetAllShapes();
        }

        public Task<IEnumerable<Shape>> GetShapesByAreaAsync(double minimumArea)
        {
            return _defaultRepository.GetShapeByArea(minimumArea);
        }
    }
}
