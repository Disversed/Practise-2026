using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkWithText_4_additional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tUser registration");

            string login = GetValidLogin();
            string password = GetValidPassword();
        }

        static string GetValidLogin()
        {
            string login = null;
            string pattern = @"^[a-zA-z]+$";
            while (string.IsNullOrEmpty(login))
            {
                Console.Write("Enter user login (only latin characters): ");
                login = Console.ReadLine().Trim();
                
                if (Regex.IsMatch(login, pattern))
                {
                    break;
                } 
                else
                {
                    Console.WriteLine("Login may consist only of latin characters. Try again");
                    login = null;
                }
            }
            return login;
        }

        static string GetValidPassword()
        {
            string password = null;
            string pattern = @"^[^a-zA-Zа-яА-ЯёЁ\s]{2,}$";
            while (string.IsNullOrEmpty(password))
            {
                Console.Write("Enter user password (only digits and special characters): ");
                password = Console.ReadLine().Trim();
                if (Regex.IsMatch(password, pattern)
                    && Regex.IsMatch(password, @"\D"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Password may consist only of digits and special characters. Try again");
                    password = null;
                }
            }
            return password;
        }
    }
}
