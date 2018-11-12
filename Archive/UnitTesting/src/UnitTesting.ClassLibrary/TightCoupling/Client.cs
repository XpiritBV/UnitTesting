using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting.ClassLibrary.TightCoupling
{
    /// <summary>
    /// Filters service results from <see cref="ServiceProxy"/>.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Accesses a service to find users, and returns all users that have a given last name.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersAsync(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(lastName));

            var proxy = new ServiceProxy();
            var users = await proxy.GetUsersAsync();
            return users.Where(u => u.Name.ToLowerInvariant().Contains(lastName.ToLowerInvariant()));
        }
    }
}