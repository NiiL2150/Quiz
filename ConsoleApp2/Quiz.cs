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
        public void Start(User user)
        {
            if(Top20.Count == 0)
            {
                Console.WriteLine("You are the first one to take part in this test!");
            }
            else
            {
                Console.WriteLine($"Top {Top20.Count} of the quiz: ");
                int i = 0;
                foreach (var item in Top20)
                {
                    Console.WriteLine($"{++i}. {item}");
                }
            }
            Console.ReadKey();
            int right = 0;
            foreach (var item in Questions)
            {
                Console.Clear();
                Console.WriteLine($"{item.QuestionText}\n");
                if (item.RightAnswers.Count == 1)
                {
                    Console.WriteLine("One choice question\n");
                }
                else
                {
                    Console.WriteLine("Multiple choice question\n");
                }
                int iii = 0;
                foreach (var item2 in item.AnswerText)
                {
                    Console.WriteLine($"{++iii}. {item2}");
                }
                int tmpint = 0;
                List<int> rights = new List<int>();
                do
                {
                    string tmpstr = Console.ReadLine();
                    if (tmpstr == null || tmpstr == "")
                    {
                        break;
                    }
                    tmpint = Int32.Parse(tmpstr);
                    if (tmpint > 0)
                    {
                        if (!rights.Contains(tmpint))
                        {
                            if (tmpint <= item.AnswerText.Count)
                            {
                                rights.Add(tmpint);
                            }
                        }
                    }
                } while (tmpint > 0);
                if(item.RightAnswers.Count == rights.Count)
                {
                    int r = 0;
                    for (int i = 0; i < item.RightAnswers.Count; i++)
                    {
                        if(item.RightAnswers[i] == rights[i])
                        {
                            r++;
                        }
                    }
                    if (r == item.RightAnswers.Count)
                    {
                        right++;
                    }
                }
            }
            Console.WriteLine($"Your score - {right}/10");
            user.Recent.Insert(0, right >= 10 ? $"{right}/10 - {Title}" : $"0{right}/10 - {Title}");
            Top20.Add(right >= 10 ? $"{right}/10 - {user.Name}" : $"0{right}/10 - {user.Name}");
            Top20.Sort();
            Top20.Reverse();
            if (Top20.Count > 20)
            {
                Top20.RemoveAt(20);
            }
            Console.ReadKey();
        }
        public Quiz(string title)
        {
            Title = title;
            Top20 = new List<string>();
            Questions = new List<Question>();
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.WriteLine($"Question number {i+1}: ");
                string tmpstr = Console.ReadLine(), tmpstr2;
                List<string> answers = new List<string>();
                List<int> rights = new List<int>();
                int ii = 0, tmpint;
                do
                {
                    Console.WriteLine($"Answer {++ii} (blank line to end): ");
                    tmpstr2 = Console.ReadLine();
                    if(tmpstr2 != "" && tmpstr2 != null)
                    {
                        answers.Add(tmpstr2);
                    }
                } while (tmpstr2 != "" && tmpstr2 != null);
                Console.Clear();
                Console.WriteLine(tmpstr);
                foreach (var item in answers)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Select right answers: ");
                do
                {
                    string tmpstr3 = Console.ReadLine();
                    if(tmpstr3 == null || tmpstr3 == "")
                    {
                        break;
                    }
                    tmpint = Int32.Parse(tmpstr3);
                    if (tmpint > 0)
                    {
                        if (!rights.Contains(tmpint))
                        {
                            if (tmpint <= answers.Count)
                            {
                                rights.Add(tmpint);
                            }
                        }
                    }
                } while (tmpint > 0);
                Questions.Add(new Question(tmpstr, answers, rights));
            }
        }
        public Quiz()
        {
            Title = "Unnamed";
            Top20 = new List<string>();
            Questions = new List<Question>();
        }
    }
}
