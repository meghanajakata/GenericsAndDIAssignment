using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApplication.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
