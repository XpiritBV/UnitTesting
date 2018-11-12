using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTesting.ClassLibrary.TightCoupling
{
    /// <summary>
    /// Proxy to access a remote service. Remote service returns JSON data. JSON data is converted to objects of type <see cref="User"/>
    /// and the objects are returned.
    /// </summary>
    /// <returns>
    /// {
    ///    "id": 1,
    ///    "name": "Leanne Graham",
    ///    "username": "Bret",
    ///    "email": "Sincere@april.biz",
    ///    "address": {
    ///      "street": "Kulas Light",
    ///      "suite": "Apt. 556",
    ///      "city": "Gwenborough",
    ///      "zipcode": "92998-3874",
    ///      "geo": {
    ///        "lat": "-37.3159",
    ///        "lng": "81.1496"
    ///      }
    ///    },
    ///    "phone": "1-770-736-8031 x56442",
    ///    "website": "hildegard.org",
    ///    "company": {
    ///      "name": "Romaguera-Crona",
    ///      "catchPhrase": "Multi-layered client-server neural-net",
    ///      "bs": "harness real-time e-markets"
    ///    }
    ///  },
    ///
    /// </returns>
    public class ServiceProxy
    {
        private readonly HttpClient _httpClient;

        public ServiceProxy()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            string json = await _httpClient.GetStringAsync("/users");
            var users = JsonConvert.DeserializeObject<User[]>(json);
            return users;
        }
    }
}