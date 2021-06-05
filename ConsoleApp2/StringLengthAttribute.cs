using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class StringLengthAttribute : System.Attribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public StringLengthAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
        public bool ExceedsLimits(string str, User[] strs)
        {
            if (str.Length >= MinLength && str.Length <= MaxLength)
            {
                foreach (var item in strs)
                {
                    try
                    {
                        if (String.Compare(item.Name, str) == 0)
                        {
                            return true;
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
                return false;
            }

            return true;
        }
        public bool ExceedsLimits(string str)
        {
            if (str.Length >= MinLength && str.Length <= MaxLength)
            {
                return false;
            }
            return true;
        }
    }
}
