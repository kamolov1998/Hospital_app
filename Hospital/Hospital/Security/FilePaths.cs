using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Security
{
    internal class FilePaths
    {
        public static readonly string AdminsJsonPath = @"..\..\..\Database\Admin.json";
        public static readonly string PatientsJsonPath = @"..\..\..\Database\Patient.json";
        public static readonly string DoctorsJsonPath = @"..\..\..\Database\Doctor.json";
    }
}
