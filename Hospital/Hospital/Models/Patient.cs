using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient : Person
    {
        public string Sickness { get; set; }
        public int Room { get; set; }
    }
}
