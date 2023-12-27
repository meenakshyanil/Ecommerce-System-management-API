using ecommerce_web_api.Models;

namespace ecommerce_web_api.Services.Categories

{
    public interface IcategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int d);
        Category AddCategory(Category category);
        Category UpdateCategory(int d, Category category);
        void DeleteCategory(int d);






    }
}
