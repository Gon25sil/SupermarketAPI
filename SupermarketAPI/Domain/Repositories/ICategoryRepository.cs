using SupermarketAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Persistance
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();

        public Category Get(int id);

        public void Create(Category category);
        public void Update(Category category);
        public void Delete(Category category);


    }
}
