using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Global
    {
        public static Admin mainAdmin;
        public static List<User> users;
        public static List<Topic> Topics { get; set; }
        static public void SignUp()
        {
            Console.Clear();
            User[] logins = new User[Global.users.Count];
            int i = 0;
            foreach (var item in Global.users)
            {
                logins[i] = item;
                ++i;
            }
            User tmp = new User(logins, null);
            Global.users.Add(tmp);
            StartQuiz(users[Global.users.Count - 1]);
        }
        static public void LogIn()
        {
            Console.Clear();
            Console.Write("Login: ");
            string name = Console.ReadLine();
            try
            {
                User user = Global.users.Find(x => x.Name == name);
                if (user == null) throw new NullReferenceException("User not found");
                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (password != user.Password) throw new WrongPasswordException();
                StartQuiz(user);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        static public void AdminLogIn()
        {
            Console.Clear();
            Console.WriteLine("Login: ");
            string name = Console.ReadLine();
            try
            {
                if (name != Global.mainAdmin.Name) throw new NullReferenceException("Wrong login!");
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                if (password != Global.mainAdmin.Password) throw new WrongPasswordException();
                AdminTable(Global.mainAdmin);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            catch (WrongPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        static public void StartQuiz(User user)
        {
            Console.Clear();
            try
            {
                if (Topics.Count == 0) throw new NoElementsException();
                Console.WriteLine("Choose topic to participate in (0 for exiting, -1 for Recent): ");
                int i = 0, ch;
                foreach (var item in Global.Topics)
                {
                    Console.WriteLine($"{++i}. {item.Title} - {item.Quizzes.Count}");
                }
                ch = Int32.Parse(Console.ReadLine());
                if (ch == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Recent: ");
                    foreach (var item in user.Recent)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadKey();
                }
                else if(ch>0 && ch <= Topics.Count)
                {
                    Topics[--ch].Open(user);
                }
            }
            catch (NoElementsException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }

        static public void AdminTable(Admin admin)
        {
            Console.Clear();
            Console.WriteLine("0. For adding and deleting, -1 for exit");
            int i = 0;
            foreach (var item in Global.Topics)
            {
                Console.WriteLine($"{++i}. {item.Title} - {item.Quizzes.Count}");
            }
            try
            {
                int ch = Int32.Parse(Console.ReadLine());
                if (ch == 0)
                {
                    Console.Clear();
                    i = 0;
                    Console.WriteLine("0. Add new, -1 for exit, others for deletion");
                    foreach (var item in Global.Topics)
                    {
                        Console.WriteLine($"{++i}. {item.Title} - {item.Quizzes.Count}");
                    }
                    i = Int32.Parse(Console.ReadLine());
                    if (i == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("New topic name: ");
                        string str2 = Console.ReadLine();
                        admin.AddTopic(Global.Topics, str2);
                    }
                    else if(i!=-1)
                    {
                        admin.DeleteTopic(Global.Topics, i);
                    }
                }
                else if (ch != -1)
                {
                    Global.Topics[--ch].Open(admin);
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }

        static Global()
        {
            Topics = new List<Topic>() { };
            mainAdmin = null;
            users = new List<User>() { };
        }
    }
}
