using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class SliderCreateVM
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
