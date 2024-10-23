using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
