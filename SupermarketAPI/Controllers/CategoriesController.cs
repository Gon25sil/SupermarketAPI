using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Domain.Models;
using SupermarketAPI.Domain.Services;
using SupermarketAPI.DTO;

namespace SupermarketAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper )
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        /// <summary>
        /// List of all categories
        /// </summary>
        /// <returns> List of categories</returns>
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories()
        {
            var categories = categoryService.GetAllCategories();
            var categoriesDto = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryReadDto>>(categories);

            return Ok(categoriesDto);
        }

        /// <summary>
        /// Gets a specific category, according to an identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Response for the request</returns>
        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<CategoryReadDto> GetCategory(int id)
        {
            var category = categoryService.GetCategory(id);
            if(category == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Category, CategoryReadDto>(category));
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="resource">Category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = mapper.Map<Category>(resource);
            var result = categoryService.Create(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryReadDto = mapper.Map<CategoryReadDto>(result.Category);
            return CreatedAtRoute(nameof(GetCategory), new { id = categoryReadDto.Id }, categoryReadDto);

        }

        /// <summary>
        /// Updates an existing category
        /// </summary>
        /// <param name="id">Category identifier</param>
        /// <param name="resource">Category new data</param>
        /// <returns>Response for the request</returns>
        [HttpPut("{id}")]
        public ActionResult<CategoryReadDto> UpdateCategory(int id, CategoryUpdateDto resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = mapper.Map<Category>(resource);
            
            //var categoryModel = categoryService.GetCategory(id);
            //var a = mapper.Map(resource, categoryModel); // this already updates dbcontext

            var result = categoryService.Update(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryRead = mapper.Map<CategoryReadDto>(result.Category);
            return Ok(categoryRead);

        }

        /// <summary>
        /// Updates an existing category using PATCH request
        /// </summary>
        /// <param name="id">category identifier</param>
        /// <param name="patchDoc">Patch data</param>
        /// <returns>Response for the request</returns>
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CategoryUpdateDto> patchDoc)
        {
            var categoryFromRepo = categoryService.GetCategory(id);
            if (categoryFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = mapper.Map<CategoryUpdateDto>(categoryFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem();
            }

            mapper.Map(commandToPatch, categoryFromRepo); //already updates the Context
            var result = categoryService.PartialUpdate(categoryFromRepo);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryRead = mapper.Map<CategoryReadDto>(result.Category);
            return Ok(categoryRead);
        }

        /// <summary>
        /// Deletes an existing category
        /// </summary>
        /// <param name="id">Catwgory identifier</param>
        /// <returns>Response for the request</returns>
        [HttpDelete("{id}")]
        public ActionResult<CategoryReadDto> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var result = categoryService.Delete(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryRead = mapper.Map<CategoryReadDto>(result.Category);
            return Ok(categoryRead);

        }


    }
}
