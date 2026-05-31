using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels
{
    public class RegisterVM
    {
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]
        [MinLength(3)]
        public string Name { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string Surname { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string UserName { get; set; }
        [MaxLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
