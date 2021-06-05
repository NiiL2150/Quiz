using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public interface IUser
    {
        [StringLength(6, 16)]
        string Name { get; set; }
        [StringLength(8, 32)]
        string Password { get; set; }
        DateTime Birthday { get; set; }
    }
}
