using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> AnswerText { get; set; }
        public List<int> RightAnswers { get; set; }
        public Question(string text, List<string> answers, List<int> rights)
        {
            QuestionText = text;
            AnswerText = answers;
            RightAnswers = rights;
        }
        public Question() : this("No text", null, null) { }
    }
}
