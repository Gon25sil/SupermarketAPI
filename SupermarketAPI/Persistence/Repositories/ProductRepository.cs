using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketAPI.Persistance.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
        }

        public Product Get(int id)
        {
            return context.Products.Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.Include(p => p.Category).ToList();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
        }
    }
}
