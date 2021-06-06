using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public interface IAdmin
    {
        void AddTopic(List<Topic> topics, string name);
        void DeleteTopic(List<Topic> topics, int pos);
        void AddQuiz(Topic topic, string str);
        void DeleteQuiz(Topic topic, int pos);
    }
}
