
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.IRepositories
{
    public interface IDoctorRepositories
    {
        void AddDoctor(Doctor doctor);

        void RemoveDoctor();
        void SearchDoctor(String contact);
    }
}
