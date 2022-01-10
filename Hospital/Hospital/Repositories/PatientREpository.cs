using Hospital.Extention;
using Hospital.IRepositories;
using Hospital.Models;
using Hospital.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    internal class PatientREpository : Models.Patient, IPatientRepositories
    {
        public void AddPatient(Patient patient)
        {
            string json = File.ReadAllText(FilePaths.PatientsJsonPath);
            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(json);
            bool result = CheckIfAlreadyExist(patient);

            if (result == false)
            {
                patients.Add(patient);
                string res = JsonConvert.SerializeObject(patients);
                File.WriteAllText(FilePaths.PatientsJsonPath, res);
                Console.WriteLine("Bemor muaffaqiyatli qo'shildi");
            }
            else Console.WriteLine("\nTelefon raqam mavjudligi aniqlandi, iltimos qaytadan urunib ko'ring\n");
        }//Done

        public void UpdatePatient(Patient patient)
        {
            bool result = false;
            Patient patient1 = new Patient();

            string json = File.ReadAllText(FilePaths.PatientsJsonPath);
            IList<Patient> PatientList = JsonConvert.DeserializeObject<IList<Patient>>(json);

            var patients = PatientList.Where(x => x.Contact == patient.Contact).ToList();

            if (patients.Count > 0)
            {
                foreach (var item in patients)
                {
                    PatientList.Remove(item);
                }

                string res = JsonConvert.SerializeObject(PatientList);
                File.WriteAllText(FilePaths.PatientsJsonPath, res);
                result = true;
            }
            if (result == true)
            {

                Console.Write("Yangi ism kiriting: ");
                patient1.FirstName = Console.ReadLine();
                patient1.FirstName = patient1.FirstName.Capitalize();

                Console.Write($"{patient1.FirstName}ning familyasini kiriting: ");
                patient1.LastName = Console.ReadLine();
                patient1.LastName = patient1.LastName.Capitalize();

                Console.Write($"{patient1.FirstName} {patient1.LastName}ning yoshni kiriting: ");
                patient1.Age = int.Parse(Console.ReadLine());

                Console.Write($"{patient1.FirstName} {patient1.LastName}ning telfon raqamini kiriting: ");
                patient1.Contact = Console.ReadLine();

                Console.Write($"{patient1.FirstName} {patient1.LastName} {patient1.Sickness} ning kasalligini kiritin: ");
                patient1.Sickness = Console.ReadLine();

                Console.Write($"{patient1.FirstName} {patient1.LastName} {patient1.Room} ning xonasini kiriting: ");
                patient1.Room = int.Parse(Console.ReadLine());
                Console.WriteLine("Bemor yangilandi");

                PatientList.Add(patient1);
                File.Delete(FilePaths.PatientsJsonPath);
                string res = JsonConvert.SerializeObject(PatientList);
                File.WriteAllText(FilePaths.PatientsJsonPath, res);
            }
        }// Done

        public void SearchPatient(String contact)
        {
            int succesChecker = 0;

            string json = File.ReadAllText(FilePaths.PatientsJsonPath);
            IList<Patient> PatientList = JsonConvert.DeserializeObject<List<Patient>>(json);

            
                foreach (var item in PatientList)
                {
                    if (item.Contact == contact)
                    {
                        //sharing result with user
                        //changing console text color
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nIsm: {item.FirstName}\n" +
                            $"Familya: {item.LastName}\n" +
                            $"Yosh: {item.Age}\n" +
                            $"Kontakt: {item.Contact}\n" +
                            $"Kasalligi: {item.Sickness}\n" +
                            $"Joylashgan xonasi: {item.Room}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        succesChecker++;
                        break;
                    }
                }

            if (succesChecker == 0)
            {
                //changing console text color
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kasal topilmadi");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }// Done 

        public void RemovePatient(Patient patient)
        {
            string json = File.ReadAllText(FilePaths.PatientsJsonPath);
            IList<Patient> PatientList = JsonConvert.DeserializeObject<IList<Patient>>(json);

            var patients = PatientList.Where(x => x.Contact == Contact).ToList();

            if (patients.Count > 0)
            {
                foreach (var item in patients)
                {
                    PatientList.Remove(item);
                }

                string res = JsonConvert.SerializeObject(PatientList);
                File.WriteAllText(FilePaths.PatientsJsonPath, res);
                Console.WriteLine("Bemor muaffaqiyatli o'chirildi");
            }
        } //Done

        public static bool CheckIfAlreadyExist(Patient patient)
        {
            bool result = false;
            string json = File.ReadAllText(FilePaths.PatientsJsonPath);
            IList<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(json);
            foreach (var Item in patients) if (Item.Contact == patient.Contact) result = true;
            return result;
        }//Done
    }
}
