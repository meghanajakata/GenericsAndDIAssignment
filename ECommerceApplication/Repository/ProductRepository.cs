using ECommerceApplication.Data;
using ECommerceApplication.Models;

namespace ECommerceApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context context;
        public ProductRepository(Context _context)
        {
            context = _context;
        }

        /// <summary>
        /// Get products from database
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            try
            {
                var products = context.Products.ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add product to database
        /// </summary>
        /// <param name="product"></param>
        public bool AddProduct(Product productModel)
        {
            try
            {
                Product product = context.Products.FirstOrDefault(u => u.Name == productModel.Name);
                if (product != null)
                {
                    return false;
                }
                context.Products.Add(product);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProduct(Product productModel)
        {
            try
            {
                var product = context.Products.FirstOrDefault(u => u.ProductId == productModel.ProductId);
                if (product == null)
                {
                    return false;
                }
                product.Name = productModel.Name;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                var product = context.Products.FirstOrDefault(u => u.ProductId == Id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
