using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraminIndia.Areas.Admin.Model
{
    public class Navigation
    {
        public int NavigationId { get; set; }
        public string NavigationName { get; set; }
        public int CreatedBy { get; set; }
        public int Flag { get; set; }
        public int UpdatedBy { get; set; }

    }
}