using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Agilli Ol!")]
        public string? Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
