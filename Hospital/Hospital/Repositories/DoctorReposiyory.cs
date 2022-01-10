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
    internal class DoctorReposiyory : Models.Doctor, IDoctorRepositories
    {
        public void AddDoctor(Doctor doctor)
        {
            string json = File.ReadAllText(FilePaths.DoctorsJsonPath);
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);
            bool result = CheckIfAlreadyExist(doctor);

            if (result == false)
            {
                doctors.Add(doctor);
                string res = JsonConvert.SerializeObject(doctors);
                File.WriteAllText(FilePaths.DoctorsJsonPath, res);
                Console.WriteLine("Doctor muaffaqiyatli qo'shildi");
            }
            else Console.WriteLine("\nTelefon raqam mavjudligi aniqlandi, iltimos qaytadan urunib ko'ring\n");
        }//Done 

        public void RemoveDoctor()
        {
            Doctor doctor = new Doctor();
            Console.Write("\nO'chirmoqchi bo'lgan Doctorning telefon raqamini kiriting: ");
            doctor.Contact = Console.ReadLine();

            string json = File.ReadAllText(FilePaths.DoctorsJsonPath);
            IList<Doctor> DoctorsList = JsonConvert.DeserializeObject<List<Doctor>>(json);
            int succesChecker = 0;
            foreach (var item in DoctorsList)
            {
                if (doctor.Contact == item.Contact)
                {
                    DoctorsList.Remove(item);
                    string res = JsonConvert.SerializeObject(DoctorsList);
                    File.Delete(FilePaths.DoctorsJsonPath);
                    File.WriteAllText(FilePaths.DoctorsJsonPath, res);
                    Console.WriteLine("\nDoctor muaffaqiyatli o'chirildi\n");
                    succesChecker++;
                    break;
                }
            }
            if (succesChecker == 0) Console.WriteLine("\nDoctor topilmadi\n");
        }// Done 

        public void SearchDoctor(string contact)
        {
            int succesChecker = 0;

            string json = File.ReadAllText(FilePaths.DoctorsJsonPath);
            IList<Doctor> DoctorList = JsonConvert.DeserializeObject<List<Doctor>>(json);
           
                foreach (var item in DoctorList)
                {
                    if (item.Contact == contact)
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nIsm: {item.FirstName}\n" +
                            $"Familya: {item.LastName}\n" +
                            $"Yosh: {item.Age}\n" +
                            $"Kontakt: {item.Contact}\n" +
                            $"Mutaxasisligi: {item.Specialty}");
                        Console.ForegroundColor = ConsoleColor.White;
                        succesChecker++;
                        break;
                    }
                }
            
            if (succesChecker == 0)
            {
                //changing console text color
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor topilmadi: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }// Done
        public static bool CheckIfAlreadyExist(Doctor doctor)
        {
            bool result = false;
            string json = File.ReadAllText(FilePaths.DoctorsJsonPath);
            IList<Doctor> DoctorsList = JsonConvert.DeserializeObject<List<Doctor>>(json);
            foreach (var Item in DoctorsList) if (Item.Contact == doctor.Contact) result = true;
            return result;
        }//Done A


    }
}
