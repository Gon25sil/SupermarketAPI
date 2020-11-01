using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Persistance;
using SupermarketAPI.Domain.Persistance.Repositories;
using SupermarketAPI.Domain.Services;
using SupermarketAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;

namespace SupermarketAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public SaveCategoryResponse Create(Category category)
        {
            try
            {
                categoryRepository.Create(category);
                unitOfWork.Complete();

                return new SaveCategoryResponse(category);
            }
            catch (Exception e)
            {
                return new SaveCategoryResponse($"An error ocurred when saving the category: {e.Message}");
            }
            
        }

        public SaveCategoryResponse Delete(int id)
        {
            var existingCategory = categoryRepository.Get(id);

            if(existingCategory == null)
                return new SaveCategoryResponse($"Category not found (id: {id}).");

            try
            {
                categoryRepository.Delete(existingCategory);
                unitOfWork.Complete();

                return new SaveCategoryResponse(existingCategory);

            }
            catch (Exception e)
            {
                return new SaveCategoryResponse($"An error occurred when deleting the category: {e.Message}");
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return categoryRepository.Get(id);
        }

        public SaveCategoryResponse PartialUpdate(Category category)
        {
            try
            {
                unitOfWork.Complete();
                return new SaveCategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new SaveCategoryResponse($"Error during partial update. {ex.Message}");
            }
        }

        public SaveCategoryResponse Update(int id, Category category)
        {
            try
            {
                var existingCategory = categoryRepository.Get(id);
                
                if(existingCategory == null)
                {
                    return new SaveCategoryResponse($"Category not found (id: {id}).");
                }

                existingCategory.Name = category.Name;

                categoryRepository.Update(existingCategory);
                unitOfWork.Complete();

                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new SaveCategoryResponse($"An error occurred when updating the category: {e.Message}");
            }
        }
    }
}
