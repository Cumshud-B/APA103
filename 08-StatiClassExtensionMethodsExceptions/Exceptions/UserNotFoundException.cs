using System;

namespace LoginApp.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("Istifadeci tapilmadi.")
        {
        }

        public UserNotFoundException(string username)
            : base($"'{username}' adli istifadeci tapilmadi.")
        {
        }
    }
}