using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketAPI.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Category category)
        {
            context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
        }
    }
}
