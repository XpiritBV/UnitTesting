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

        /// <summary>
        /// Gets all shapes.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Shape>> GetShapesAsync()
        {
            return _defaultRepository.GetAllShapes();
        }

        /// <summary>
        /// Gets shapes with a minimum size. Filters in repo.
        /// </summary>
        /// <param name="minimumArea"></param>
        /// <returns></returns>
        public Task<IEnumerable<Shape>> GetShapesByAreaAsync(double minimumArea)
        {
            return _defaultRepository.GetShapeByArea(minimumArea);
        }

        // TODO: create a unit test for this.
        /// <summary>
        /// Gets all shapes with type <typeparamref name="TShape"/>.
        /// </summary>
        /// <typeparam name="TShape"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<TShape>> GetShapesByTypeAsync<TShape>()
            where TShape : Shape
        {
            var everything = await _defaultRepository.GetAllShapes();
            return everything.OfType<TShape>();
        }

        // TODO: create a unit test for this.
        /// <summary>
        /// Returns squares with a width smaller than 2.0D. Filters in memory.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Square>> GetSmallSquaresAsync()            
        {
            var everything = await _defaultRepository.GetAllShapes();
            return everything
                .OfType<Square>()
                .Where(s=>s.Width < 2.0D);
        }
    }
}
