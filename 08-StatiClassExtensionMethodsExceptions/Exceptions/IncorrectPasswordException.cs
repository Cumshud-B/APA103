using System;

namespace LoginApp.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; set; }

        public IncorrectPasswordException(int attemptsLeft)
            : base($"Sifre sehvdir. Qalan cehd sayı: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
}