using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSD_CW.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int BranchId { get; set; }
    }
}