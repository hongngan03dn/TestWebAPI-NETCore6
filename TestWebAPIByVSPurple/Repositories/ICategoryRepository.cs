using TestWebAPIByVSPurple.Entities;
using TestWebAPIByVSPurple.Models;

namespace TestWebAPIByVSPurple.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> GetAllCategoriesAsync();
        public Task<CategoryModel> GetCategoryAsync(int id);
        public Task<int> AddCategoryAsync(CategoryModel model);
        public Task UpdateCategoryAsync(int id, CategoryModel model);
        public Task DeleteCategoryAsync(int id);

    }
}
