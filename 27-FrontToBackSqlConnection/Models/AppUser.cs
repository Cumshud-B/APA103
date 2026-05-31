using Microsoft.AspNetCore.Identity;

namespace _27_FrontToBackSqlConnection.Models
{
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
