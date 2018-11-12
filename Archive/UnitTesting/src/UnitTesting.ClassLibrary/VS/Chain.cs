using System;
using System.Collections.Generic;

namespace UnitTesting.ClassLibrary
{
    public class Chain
    {
        private List<Link> _links = new List<Link>();
        public IReadOnlyCollection<Link> Links => _links;

        public void Add(Link link)
        {
            //if (link == null)
            //{
            //    throw new ArgumentNullException(nameof(link));
            //}

            System.Diagnostics.Debug.WriteLine($"Adding Link #{link.Count}");

            _links.Add(link);
        }
    }
}
