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

        void Insert(Staff staff);
    }
}
