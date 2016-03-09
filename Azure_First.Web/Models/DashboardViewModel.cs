using Azure_First.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure_First.Web.Models
{
    public class DashboardViewModel
    {
        public Profile UserProfile { get; set; }
        public IEnumerable<RandomProfileViewModel> ExistingUsers { get; set;  }
    }
}