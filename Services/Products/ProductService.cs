using ecommerce_web_api.Database;
using ecommerce_web_api.Models;

namespace ecommerce_web_api.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly DatabaseContext _dbContext;
        public ProductService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product Addproduct(Product product, int catId)
        {
            Category category =  _dbContext.Categories.FirstOrDefault(cat => cat.CategoryId == catId);
            product.category = category;
            _dbContext.products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int d)
        {
            Product savepro = GetProductById(d);
            _dbContext.products.Remove(savepro);
            _dbContext.SaveChanges();
        }

        public Product GetProductById(int d)
        {
            return _dbContext.products.FirstOrDefault(stud => stud.ProductId == d);
        }

        public List<Product> GetProducts()
        {
            return _dbContext.products.ToList();
        }

        public Product UpdateProduct(int d, Product product)
        {
            Product pro = GetProductById(d);
            pro.ProductTitle = product.ProductTitle;
            pro.ProductDescription=product.ProductDescription;
            pro.ProductPrice = product.ProductPrice;
            pro.ProductImages = product.ProductImages;
            pro.category.CategoryId=product.category.CategoryId;
            
            _dbContext.SaveChanges();
            return pro;
        }
    }
}
