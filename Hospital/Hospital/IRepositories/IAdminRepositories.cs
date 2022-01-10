using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.IRepositories
{
    public interface IAdminRepositories
    {
        void AddAdmin(AdminRepository admin);
        
        void RemoveAdmin();

        bool IsAdmin (Admin admin);
    }
}
