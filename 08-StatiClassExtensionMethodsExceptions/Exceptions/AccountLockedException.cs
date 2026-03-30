using System;

namespace LoginApp.Exceptions
{
    public class AccountLockedException : Exception
    {
        public AccountLockedException()
            : base("Hesab bloklanib!")
        {
        }
    }
}