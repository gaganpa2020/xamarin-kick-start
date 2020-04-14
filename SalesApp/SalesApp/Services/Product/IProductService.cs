using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Models;

namespace SalesApp.Services.Product
{
    public interface IProductService
    {
        Task<List<Models.Product>> GetProductsForUser(User user);

    }
}
