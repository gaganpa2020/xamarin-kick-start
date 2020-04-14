using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Services.Product
{
    public class MockProductService : IProductService
    {
        public async Task<List<Models.Product>> GetProductsForUser(User user)
        {
            await Task.Delay(1000);
            List<Models.Product> output = new List<Models.Product>();
            Models.Product p = new Models.Product()
            {
                Description = "Green Electric 1",
                IPSIdentifier = 1,
                Name = "Green Electric 1",
                Id = 1
            };
            output.Add(p);
            return output;
        }
    }
}
