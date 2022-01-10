using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.IRepositories
{
    public  interface IPatientRepositories
    {
        void AddPatient(Patient patient);

        void RemovePatient(Patient patient);

         void UpdatePatient(Patient patient);

        void SearchPatient(String contact);
    }
}
