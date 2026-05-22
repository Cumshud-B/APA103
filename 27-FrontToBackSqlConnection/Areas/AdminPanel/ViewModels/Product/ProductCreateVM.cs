using _27_FrontToBackSqlConnection.Models;
using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product
{
    public class ProductCreateVM
    {
        public IFormFile? MainPhoto { get; set; }
        public IFormFile? HoverPhoto { get; set; }
        public List<IFormFile>? AdditionalPhoto { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public List<int>? TagIds { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
