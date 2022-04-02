using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSD_CW.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public int BranchId { get; set; }
    }
}