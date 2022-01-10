using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Admin: Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
