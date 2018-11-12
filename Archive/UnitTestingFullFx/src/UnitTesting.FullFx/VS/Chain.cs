using System;
using System.Collections.Generic;

namespace UnitTesting.ClassLibrary
{
    public class Chain
    {
        private List<Link> _links = new List<Link>();
        public IReadOnlyCollection<Link> Links => _links;

        public Chain AddRange(params Link[] links)
        {
            if (links == null)
            {
                throw new ArgumentNullException(nameof(links));
            }

            _links.AddRange(links);
            return this;
        }
    }
}
