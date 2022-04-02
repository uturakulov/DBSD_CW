using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSD_CW.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public bool Married { get; set; }
        public byte[] Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public int BranchId { get; set; }
    }
}