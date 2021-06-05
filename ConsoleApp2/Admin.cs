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
            Birthday = Convert.ToDateTime("02.09.2005");
        }

        public void AddQuiz(Topic topic)
        {
            Quiz quiz = new Quiz();
            topic.Quizzes.Add(quiz);
        }

        public void DeleteQuiz(Topic topic)
        {
            int i = 0;
            foreach (var item in topic.Quizzes)
            {
                Console.WriteLine($"{i++}. ");
            }
            int pos = Int32.Parse(Console.ReadLine());
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
