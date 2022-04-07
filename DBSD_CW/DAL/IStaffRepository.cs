using DBSD_CW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSD_CW.DAL
{
    public interface IStaffRepository
    {
        IList<Staff> GetAll();

        IList<Staff> Filter(string first_name, string last_name, string email, string branch, string role);

        void Insert(Staff staff);

        Staff GetById(int Id);

        void Update(Staff staff);

        void Delete(int Id);
    }
}
