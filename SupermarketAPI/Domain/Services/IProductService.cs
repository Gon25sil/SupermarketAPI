using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public Product Get(int id);
        public SaveProductResponse Delete(int id);

        public SaveProductResponse Create(Product product);

        public SaveProductResponse Update(int id, Product product);

    }
}
