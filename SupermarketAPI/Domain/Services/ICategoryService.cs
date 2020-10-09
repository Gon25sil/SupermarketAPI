using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetAllCategories();

        public Category GetCategory(int id);

        public SaveCategoryResponse Create(Category category);
        public SaveCategoryResponse Update(int id, Category category);
        public SaveCategoryResponse PartialUpdate(Category category);
        public SaveCategoryResponse Delete(int id);

    }
}
