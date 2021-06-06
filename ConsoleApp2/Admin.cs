using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Admin : IUser, IAdmin
    {
        [StringLength(6, 16)]
        public string Name { get; set; }
        [StringLength(8, 32)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        public Admin(object[] args)
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
        }

        public Admin()
        {
            Name = "Unnamed";
            Password = "qwertyqwerty";
            Birthday = Convert.ToDateTime("01.01.1990");
        }

        public void AddQuiz(Topic topic, string str)
        {
            Quiz quiz = new Quiz(str);
            topic.Quizzes.Add(quiz);
        }

        public void DeleteQuiz(Topic topic, int pos)
        {
            topic.Quizzes.RemoveAt(--pos);
        }

        public void AddTopic(List<Topic> topics, string name)
        {
            Topic topic = new Topic(name);
            topics.Add(topic);
        }

        public void DeleteTopic(List<Topic> topics, int pos)
        {
            topics.RemoveAt(--pos);
        }
    }
}
