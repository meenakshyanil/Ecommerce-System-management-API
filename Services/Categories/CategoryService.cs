using ecommerce_web_api.Database;
using ecommerce_web_api.Models;

namespace ecommerce_web_api.Services.Categories

{
    public class CategoryService : IcategoryService
    {
        private readonly DatabaseContext _dbContext;
        public CategoryService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            Category saveCat = GetCategoryById(id);
            _dbContext.Categories.Remove(saveCat);
            _dbContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(stud => stud.CategoryId == id);
        }

        public Category UpdateCategory(int d, Category category)
        {
            Category cat = GetCategoryById(d);
            cat.CategoryName = category.CategoryName;
            cat.CategoryImage = category.CategoryImage;
            _dbContext.SaveChanges();
            return cat;
        }
    }
}
