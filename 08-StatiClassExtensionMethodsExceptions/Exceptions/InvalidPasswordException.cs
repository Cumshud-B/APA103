using System;

namespace LoginApp.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("Password bos ola bilmez və minimum 6 simvol olmalidir.")
        {
        }

        public InvalidPasswordException(string message)
            : base(message)
        {
        }
    }
}