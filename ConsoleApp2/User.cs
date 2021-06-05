using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class User : IUser
    {
        [StringLength(6, 16)]
        public string Name { get; set; }
        [StringLength(8, 32)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> Recent { get; set; }

        public User(User[] logins, object[] args)
        {

            do
            {
                Console.Clear();
                Console.Write("Enter your username: ");
                Name = Console.ReadLine();
            } while ((((typeof(User).GetProperty("Name")).GetCustomAttributes(false)[0]) as StringLengthAttribute).ExceedsLimits(this.Name, logins));
            do
            {
                Console.Clear();
                Console.Write($"{Name}, enter your password: ");
                Password = Console.ReadLine();
            } while ((((typeof(User).GetProperty("Password")).GetCustomAttributes(false)[0]) as StringLengthAttribute).ExceedsLimits(this.Password));
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write($"{Name}, enter your birthday: ");
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Try again!");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            Recent = new List<string>();
        }

        public User(object[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("Enter your username: ");
                Name = Console.ReadLine();
            } while ((((typeof(User).GetProperty("Name")).GetCustomAttributes(false)[0]) as StringLengthAttribute).ExceedsLimits(this.Name));
            do
            {
                Console.Clear();
                Console.Write($"{Name}, enter your password: ");
                Password = Console.ReadLine();
            } while ((((typeof(User).GetProperty("Password")).GetCustomAttributes(false)[0]) as StringLengthAttribute).ExceedsLimits(this.Password));
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write($"{Name}, enter your birthday: ");
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Try again!");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            Recent = new List<string>();
        }

        public User()
        {
            Name = "Unnamed";
            Password = "qwertyqwerty";
            Birthday = Convert.ToDateTime("02.09.2005");
            Recent = new List<string>();
        }
    }
}
