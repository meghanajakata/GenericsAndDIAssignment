using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerceApplication.Models
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
