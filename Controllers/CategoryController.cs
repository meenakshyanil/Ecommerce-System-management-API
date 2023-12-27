using ecommerce_web_api.Models;
using ecommerce_web_api.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IcategoryService _categoryService;

        public CategoryController(IcategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            var data = _categoryService.GetCategories();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategorybyId(int id) {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
            {
                return NotFound("No category Found with Id:" + id);
            }
            return Ok(data);
        }

        [HttpPost]
        public ActionResult<Category> PostCategory([FromBody] Category category)
        {
            var data = _categoryService.AddCategory(category);
            if (data == null)
            {
                return BadRequest();
            }
            return Created("", data);

        }
        [HttpPut("{id}")]
        public ActionResult<Category> PutCategory(int id,[FromBody] Category category)
        {
            var data = _categoryService.GetCategoryById(id);
            if(data == null)
            {  return NotFound("No category found with id :"+id); }
            var response=_categoryService.UpdateCategory(id, category);
            return Ok(response);



        }
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCategory(int id)
        {
            var data = _categoryService.GetCategoryById(id);
            if (data == null)
            {
                return NotFound("Not category found with id:" + id);
            }
            _categoryService.DeleteCategory(id);
            return Ok("category deleted");
        }
    }
}
