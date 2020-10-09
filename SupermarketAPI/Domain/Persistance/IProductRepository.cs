using SupermarketAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Persistance
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product Get(int id);
        public void Delete(Product product);

        public void Create(Product product);

        public void Update(Product product);
    }
}
