using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Menu
{
    internal class MainMenu
    {
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1.Adminstratsiya:\n" +
                    "2.Dasturdan chiqish:\n");
                string Mainchoice = Console.ReadLine();
                if (Mainchoice == "1")
                {
                    AdminRepository adminRepository = new AdminRepository();
                    Console.Clear();
                    Console.WriteLine("Login: admin  | Parol: admin12345: ");
                    Console.Write("\nLoginingizni kiriting: ");
                    adminRepository.Login = Console.ReadLine();
                    Console.Write("Parolingizni kiriting: ");
                    adminRepository.Password = Console.ReadLine();

                    bool result = adminRepository.IsAdmin(adminRepository);
                    if (result == true)
                    {
                        Console.Clear();
                        Console.WriteLine("Muaffaqiyatli kirildi.\n");
                    Place:
                        Console.WriteLine("1.Bemorlar sozlamalari.\n" +
                            "2.Shifokorlar sozlamalari.\n" +
                            "3.Admin sozlamalari.");
                        string choice1;
                        choice1 = Console.ReadLine();
                        if (choice1 == "1")
                        {
                            PatientREpository patient = new PatientREpository();
                            Console.Clear();
                            Console.WriteLine("1.Bemor qo'shish:\n" +
                            "2.Bemor o'chirish:\n" +
                            "3.Bemor izlash:\n" +
                            "4.Bemor yangilash:\n" +
                            "5.Asosiy menuga qaytish:");
                            string BemorChoice;
                            BemorChoice = Console.ReadLine();

                            if (BemorChoice == "1")
                            {
                                Console.Clear();
                                /////////input date////////
                                Console.Write("Bemorning ismini kiriting: ");
                                patient.FirstName = Console.ReadLine();

                                Console.Write("Bemorning familyasini kiriting: ");
                                patient.LastName = Console.ReadLine();

                                Console.Write("Bemorning yoshini kiriting: ");
                                patient.Age = int.Parse(Console.ReadLine());

                                Console.Write("Bemorning nomerini kiriting: ");
                                patient.Contact = Console.ReadLine();

                                Console.Write("Bemorning kasalligini kiriting: ");
                                patient.Sickness = Console.ReadLine();

                                Console.Write("Bemorning xonasini kiriting: ");
                                patient.Room = int.Parse(Console.ReadLine());
                                ////////
                                patient.AddPatient(patient);
                            }
                            else if (BemorChoice == "2")
                            {
                                Console.Clear();
                                Console.Write("Bemorning nomerini kiriting: ");
                                patient.Contact = Console.ReadLine();
                                patient.RemovePatient(patient);
                            }
                            else if (BemorChoice == "3")
                            {
                                Console.Clear();
                                Console.Write("Bemorning nomerini kiriting: ");
                                string Contact = Console.ReadLine();
                                patient.SearchPatient(Contact);
                            }
                            else if (BemorChoice == "4")
                            {
                                Console.Clear();
                                Console.Write("Bemorni yangilash: ");
                            }
                            else if (BemorChoice == "5") goto Place;
                        }
                        else if (choice1 == "2")
                        {
                            DoctorReposiyory doctor = new DoctorReposiyory();
                            Console.Clear();
                            Console.WriteLine("1.Doctor qo'shish:\n" +
                           "2.Doctor o'chirish:\n" +
                           "3.Doctor izlash:\n" +
                           "4.Asosiy menuga qaytish:");
                            string DoctorChoice;
                            DoctorChoice = Console.ReadLine();

                            if (DoctorChoice == "1")
                            {
                                Console.Clear();
                                Console.Write("Doctorning ismini kiriing: ");
                                doctor.FirstName = Console.ReadLine();

                                Console.Write("Doctornini familiyasini kiriing: ");
                                doctor.LastName = Console.ReadLine();

                                Console.Write("Doctorning yoshini kiriing: ");
                                doctor.Age = int.Parse(Console.ReadLine());

                                Console.Write("Doctorning nomerini kiriing: ");
                                doctor.Contact = Console.ReadLine();

                                Console.Write("Doctorning mutaxasisliginni kiriing: ");
                                doctor.Specialty = Console.ReadLine();

                                doctor.AddDoctor(doctor);
                            }
                            else if (DoctorChoice == "2")
                            {
                                Console.Clear();
                                Console.Write("Doctorni nomerini kiriting: ");
                                doctor.Contact = Console.ReadLine();
                                doctor.RemoveDoctor();
                            }
                            else if (DoctorChoice == "3")
                            {
                                Console.Clear();
                                Console.Write("Doctorni nomerini kiriting: ");
                                doctor.Contact = Console.ReadLine();
                                doctor.RemoveDoctor();
                            }
                            else if (DoctorChoice == "4") goto Place;
                        }  
                        else if (choice1 == "3") 
                        {
                            AdminRepository admin = new AdminRepository();
                            Console.Clear();
                            Console.WriteLine("1.Admin qo'shish\n" +
                           "2.Admin o'chirish\n" +
                           "3.Asosiy menuga qaytish");
                            string AdminChoice;
                            AdminChoice = Console.ReadLine();

                            if (AdminChoice == "1")
                            {
                                Console.Clear();

                                Console.Write("Adminni Loginini kititing:");
                                admin.Login = Console.ReadLine();

                                Console.Write("Adminni Pasword kititing: ");
                                admin.Password = Console.ReadLine();

                                Console.Write("Adminni ismini kititing:");
                                admin.FirstName = Console.ReadLine();

                                Console.Write("Adminni familyasini kititing: ");
                                admin.LastName = Console.ReadLine();

                                Console.Write("Adminni yoshini kititing: ");
                                admin.Age = int.Parse(Console.ReadLine());

                                Console.Write("Adminni nomerini kititing: ");
                                admin.Contact = Console.ReadLine();

                                admin.AddAdmin(admin);
                            }

                            else if (AdminChoice == "2")
                            {
                                Console.Clear();
                                Console.Write("Adminni nomerini kiriting: ");
                                admin.Contact = Console.ReadLine();
                                admin.RemoveAdmin();
                            }
                            else if (AdminChoice == "3") goto Place;
                        }
                        else if (choice1 == "4") break;
                        else Console.WriteLine("Hech narsa toplimadi");

                    }

                    else if (result == false) Console.WriteLine("Login yoki parol xato kiritildi");
            
                }
                else Console.WriteLine("Hech narsa topilmadi");

            }
        }
         
    }
}
