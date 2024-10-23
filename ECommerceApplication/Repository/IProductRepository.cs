using ECommerceApplication.Models;

namespace ECommerceApplication.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public bool AddProduct(Product productModel);
        public bool UpdateProduct(Product productModel);
        public bool DeleteUser(int Id);

    }
}
