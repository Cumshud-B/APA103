using System;
using LoginApp.Models;
using LoginApp.Exceptions;

namespace LoginApp.Services
{
    public class LoginSystem
    {
        private User[] users;
        private const int MaxAttempts = 3;

        public LoginSystem()
        {
            users = new User[]
            {
                new User("admin", "admin123"),
                new User("student", "student123"),
                new User("teacher", "teacher123")
            };
        }

        public void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                throw new InvalidUsernameException();
        }

        public void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new InvalidPasswordException();
        }

        private User FindUser(string username)
        {
            foreach (var user in users)
            {
                if (user.Username.ToLower() == username.ToLower())
                    return user;
            }
            return null;
        }

        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);

            User user = FindUser(username);

            if (user == null)
                throw new UserNotFoundException(username);

            if (user.IsLocked)
                throw new AccountLockedException();

            if (user.Password == password)
            {
                user.FailedAttempts = 0;
                Console.WriteLine($"Login successful! Welcome, {username}!");
                return true;
            }
            else
            {
                user.FailedAttempts++;
                int attemptsLeft = MaxAttempts - user.FailedAttempts;

                if (attemptsLeft > 0)
                    throw new IncorrectPasswordException(attemptsLeft);
                else
                {
                    user.IsLocked = true;
                    throw new AccountLockedException();
                }
            }
        }

        public void ShowUsers()
        {
            Console.WriteLine("Movcud istifadeciler:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}