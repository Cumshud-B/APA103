using System;
using LoginApp.Services;
using LoginApp.Exceptions;

namespace LoginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginSystem system = new LoginSystem();

            while (true)
            {
                try
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    bool result = system.Login(username, password);

                    if (result)
                        break;
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    system.ShowUsers();
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine("WARNING: " + ex.Message);
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine("CRITICAL: " + ex.Message + " Contact admin.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
                }
            }
        }
    }
}