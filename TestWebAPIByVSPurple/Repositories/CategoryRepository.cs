using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestWebAPIByVSPurple.Entities;
using TestWebAPIByVSPurple.Models;

namespace TestWebAPIByVSPurple.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyShopContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(MyShopContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryModel model)
        {
            try
            {
                model.Id = null;
                var newCate = _mapper.Map<Category>(model);
                _context.Categories.Add(newCate);

                await _context.SaveChangesAsync();
                return newCate.Id;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(categories);
        }

        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task UpdateCategoryAsync(int id, CategoryModel model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
