using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Quiz
    {
        public string Title { get; set; }
        public List<string> Top20 { get; set; }
        public List<Question> Questions { get; set; }
        public Quiz(string title)
        {
            Title = title;
            Top20 = new List<string>();
            Questions = new List<Question>();
        }
        public Quiz() : this("Untitled") { }
    }
}
