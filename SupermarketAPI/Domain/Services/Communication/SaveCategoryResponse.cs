using SupermarketAPI.Domain.Models;

namespace SupermarketAPI.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; set; }

        private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a success response
        /// </summary>
        /// <param name="category"></param>
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category )
        {
        }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="category"></param>
        public SaveCategoryResponse(string message) : this (false, message, null)
        {
        }


    }
}
