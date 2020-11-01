using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Services;
using SupermarketAPI.DTO;
using System.Collections.Generic;

namespace SupermarketAPI.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        /// <summary>
        /// List of all products
        /// </summary>
        /// <returns>List of products</returns>
      [HttpGet]
      public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var products = productService.GetAllProducts();
            var productsReadDto = mapper.Map<IEnumerable<ProductReadDto>>(products);
            return Ok(productsReadDto);
        }


        /// <summary>
        /// Returns a specific product, according to an identifier
        /// </summary>
        /// <param name="id">product identifier</param>
        /// <returns>response for the request</returns>
        [HttpGet("{id}", Name = "GetProducts")]
        public ActionResult<ProductReadDto> GetProducts(int id)
        {
            Product product = productService.Get(id);
            if (product == null)
                return NotFound();

            var productReadDto = mapper.Map<ProductReadDto>(product);
            return Ok(productReadDto);
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="productCreateDTO">Product data</param>
        /// <returns>response for the request</returns>
        [HttpPost]
        public ActionResult<ProductReadDto> Create(ProductCreateDTO productCreateDTO)
        {
            
            var productToCreate = mapper.Map<Product>(productCreateDTO);

            var result = productService.Create(productToCreate);

            if (!result.Success)
                return BadRequest(result.Message);

            var productReadDto = mapper.Map<ProductReadDto>(result.Product);
            return CreatedAtRoute(nameof(GetProducts), new { id = productReadDto.Id }, productReadDto);

        }


        /// <summary>
        /// Updates a given product according to an identifier.
        /// </summary>
        /// <param name="id"> product identified </param>
        /// <param name="productUpdateDTO"> Product new Data</param>
        /// <returns>Response for the request</returns>
        [HttpPut("{id}")]
        public ActionResult<ProductReadDto> Update(int id, ProductUpdateDTO productUpdateDTO)
        {
            var productToCreate = mapper.Map<Product>(productUpdateDTO);

            var result = productService.Update(id, productToCreate);
            if (!result.Success)
                return BadRequest(result.Message);

            var productReadDto = mapper.Map<ProductReadDto>(result.Product);
            return Ok(productReadDto);
        }


        /// <summary>
        /// Deletes a given product according to an identifier.
        /// </summary>
        /// <param name="id"> product identifier</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<ProductReadDto> Delete(int id)
        {

            var result = productService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var productReadDto = mapper.Map<ProductReadDto>(result.Product);
            return Ok(productReadDto);
        }
    }
}
