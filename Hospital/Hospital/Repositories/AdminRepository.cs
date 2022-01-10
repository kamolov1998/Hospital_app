using Hospital.IRepositories;
using Hospital.Models;
using Hospital.Security;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hospital.Extention;

namespace Hospital.Repositories
{
    public class AdminRepository : Models.Admin, IAdminRepositories
    {   
        public void AddAdmin(AdminRepository admin)
        {
            string json = File.ReadAllText(FilePaths.AdminsJsonPath);
            List<AdminRepository> AdminstList = JsonConvert.DeserializeObject<List<AdminRepository>>(json);
            bool result = CheckIfAlreadyExist(admin);

            if (result == false)
            {
                //hashing input password
                byte[] tmpByteHashedPassword = HashThePassword(admin);
                admin.Password = ByteArrayToString(tmpByteHashedPassword);
                
                AdminstList.Add(admin);
                string res = JsonConvert.SerializeObject(AdminstList);
                File.WriteAllText(FilePaths.AdminsJsonPath, res);
                Console.WriteLine("Admin muaffaqiyatli qo'shildi");
            }
            else Console.WriteLine("\nLogin mavjudligi aniqlandi, iltimos qaytadan urunib ko'ring\n");
        }//Done
    
        public bool IsAdmin(Admin admin)
        {
            bool result1 = false;
            bool result2 = CheckIfAlreadyExist(admin);
            if(result2 == true) 
            {
               
                string json = File.ReadAllText(FilePaths.AdminsJsonPath);
                List<AdminRepository> AdminstList = JsonConvert.DeserializeObject<List<AdminRepository>>(json);
                byte[] hashed = HashThePassword(admin);
                admin.Password = ByteArrayToString(hashed);
                foreach(AdminRepository item in AdminstList) if (item.Login == admin.Login && item.Password == admin.Password) result1 = true;
            }
            return result1;
        }//Done

        public void RemoveAdmin()
        {
            Admin admin = new Admin();
            Console.Write("\nO'chirmoqchi bo'lgan adminstratorning telefon raqamini kiriting: ");
            admin.Contact = Console.ReadLine();

            string json = File.ReadAllText(FilePaths.AdminsJsonPath);
            IList<AdminRepository> AdminstList = JsonConvert.DeserializeObject<List<AdminRepository>>(json);
            int succesChecker = 0;
            foreach (var item in AdminstList)
            {
                if (admin.Contact == item.Contact)
                {
                    AdminstList.Remove(item);
                    string res = JsonConvert.SerializeObject(AdminstList);
                    File.Delete(FilePaths.AdminsJsonPath);
                    File.WriteAllText(FilePaths.AdminsJsonPath, res);
                    Console.WriteLine("\nAdminstrator muaffaqiyatli o'chirildi\n");
                    succesChecker++;
                    break;
                }
            }
            if(succesChecker == 0) Console.WriteLine("\nAdminstrator topilmadi\n");
        }//Done
        
        public static byte[] HashThePassword(Admin admin)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(admin.Password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return tmpHash;
        }//Done

        static string ByteArrayToString(byte[] arrInput)
        {
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (int i = 0; i < arrInput.Length; i++)  sOutput.Append(arrInput[i].ToString("X2"));
            return sOutput.ToString();
        }//Done

        public static bool CheckIfAlreadyExist(Admin admin)
        {
            bool result = false;
            string json = File.ReadAllText(FilePaths.AdminsJsonPath);
            IList<AdminRepository> AdminstList = JsonConvert.DeserializeObject<List<AdminRepository>>(json);
            foreach (var Item in AdminstList)  if (Item.Login == admin.Login) result = true;
            return result;
        }//Done

    }
}