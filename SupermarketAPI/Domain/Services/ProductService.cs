using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Persistance;
using SupermarketAPI.Domain.Persistance.Repositories;
using SupermarketAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository,ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public SaveProductResponse Create(Product product)
        {
            try
            {
                var existingCategory = categoryRepository.Get(product.CategoryId);
                if (existingCategory == null)
                    return new SaveProductResponse("Invalid category.");

                productRepository.Create(product);
                unitOfWork.Complete();

                return new SaveProductResponse(product);

            }
            catch (Exception e)
            {
                return new SaveProductResponse($"Error creating product: {e.Message}");
            }
        }

        public SaveProductResponse Delete(int id)
        {
            try
            {
                var productToDelete = productRepository.Get(id);
                if (productToDelete == null)
                    return new SaveProductResponse("Invalid product ID");

                productRepository.Delete(productToDelete);
                unitOfWork.Complete();

                return new SaveProductResponse(productToDelete);
            }
            catch (Exception e)
            {
                return new SaveProductResponse($"Error creating product: {e.Message}");

            }
        }

        public Product Get(int id)
        {
            return productRepository.Get(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public SaveProductResponse Update(int id, Product product)
        {
            try
            {
                var existingCategory = categoryRepository.Get(product.CategoryId);
                if (categoryRepository == null)
                    return new SaveProductResponse("Invlid category!");

                var existingProduct = productRepository.Get(id);
                if (existingProduct == null)
                    return new SaveProductResponse("Invalid product!");

                existingProduct.Name = product.Name;
                existingProduct.QuantityInPackage = product.QuantityInPackage;
                existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
                existingProduct.CategoryId = product.CategoryId;

                productRepository.Update(existingProduct);
                unitOfWork.Complete();

                return new SaveProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new SaveProductResponse($"Error creating product: {e.Message}");
            }
        }
    }
}
