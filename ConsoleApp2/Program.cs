using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Load();
            KeyboardInput input = new KeyboardInput(3);
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                PrintMenu(input.Choice);
                keyInfo = Console.ReadKey();
                input.Input(keyInfo);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (input.Choice == 1)
                    {
                        Global.LogIn();
                    }
                    else if (input.Choice == 2)
                    {
                        Global.SignUp();
                    }
                    else if (input.Choice == 3)
                    {
                        Global.AdminLogIn();
                    }
                    Save();
                }
                else if (keyInfo.Key == ConsoleKey.Escape || keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
            } while (true);
        }
        public static void PrintMenu(int choice)
        {
            if (choice == 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine("LogIn");
            Console.ResetColor();
            if (choice == 2)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine("SignUp");
            Console.ResetColor();
            if (choice == 3)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine("LogIn for Admin");
            Console.ResetColor();
        }
        public static void Load()
        {
            XmlSerializer xs;
            try
            {
                xs = new XmlSerializer(typeof(List<Topic>));
                using (var sr = new StreamReader("Topics.xml"))
                {
                    Global.Topics = (List<Topic>)xs.Deserialize(sr);
                }

                xs = new XmlSerializer(typeof(Admin));
                using (var sr = new StreamReader("Admin.xml"))
                {
                    Global.mainAdmin = (Admin)xs.Deserialize(sr);
                }

                xs = new XmlSerializer(typeof(List<User>));
                using (var sr = new StreamReader("Users.xml"))
                {
                    Global.users = (List<User>)xs.Deserialize(sr);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("This is the first time you run your program!");
                Console.ReadKey();
                Global.mainAdmin = new Admin(null);
            }
        }
        public static void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Topic>));
            TextWriter tw = new StreamWriter("Topics.xml");
            xs.Serialize(tw, Global.Topics);
            tw.Close();

            xs = new XmlSerializer(typeof(Admin));
            tw = new StreamWriter("Admin.xml");
            xs.Serialize(tw, Global.mainAdmin);
            tw.Close();

            xs = new XmlSerializer(typeof(List<User>));
            tw = new StreamWriter("Users.xml");
            xs.Serialize(tw, Global.users);
            tw.Close();
        }
    }
}