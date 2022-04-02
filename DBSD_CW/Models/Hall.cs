using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSD_CW.Models
{
    public class Hall
    {
        public int HallId { get; set; }
        public int Places { get; set; }
        public int BranchId { get; set; }
    }
}