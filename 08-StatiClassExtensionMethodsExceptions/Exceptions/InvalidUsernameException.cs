using System;

namespace LoginApp.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
            : base("Username bos ola bilmez ve minimum 3 simvol olmalidir.")
        {
        }

        public InvalidUsernameException(string message)
            : base(message)
        {
        }
    }
}