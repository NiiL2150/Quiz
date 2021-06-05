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
    }
}
