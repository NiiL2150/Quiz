using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Topic
    {
        public string Title { get; set; }
        public List<Quiz> Quizzes { get; set; }
        public Topic(string title)
        {
            Title = title;
            Quizzes = new List<Quiz>();
        }
        public Topic() : this("Unnamed") { }
        public void Open(Admin admin)
        {
            Console.Clear();
            Console.WriteLine("0. For adding, -1 for exiting, others for deleting");
            int i = 0;
            foreach (var item in Quizzes)
            {
                Console.WriteLine($"{++i}. {item.Title}");
            }
            int ch = Int32.Parse(Console.ReadLine());
            if (ch == 0)
            {
                Console.Clear();
                Console.WriteLine("Quiz name: ");
                string tmpstr = Console.ReadLine();
                admin.AddQuiz(this, tmpstr);
            }
            else if (ch != -1)
            {
                admin.DeleteQuiz(this, ch);
            }
        }

        public void Open(User user)
        {
            Console.Clear();
            Console.WriteLine("0. For exiting, others for doing tests");
            int i = 0;
            foreach (var item in Quizzes)
            {
                Console.WriteLine($"{++i}. {item.Title}");
            }
            int ch = Int32.Parse(Console.ReadLine());
            if (ch > 0 && ch <= Quizzes.Count)
            {
                Quizzes[--ch].Start(user);
            }
        }
    }
}
