using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSD_CW.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
        public int MenuItem { get; set; }
        public int StaffId { get; set; }
    }
}