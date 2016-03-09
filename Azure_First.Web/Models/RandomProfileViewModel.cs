using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azure_First.Web.Models
{
    public class RandomProfileViewModel
    {
        public string PhotoUrl { get; set; }
        public string LookingFor { get; set; }
        public string MemberName { get; set; }
        public string UserName { get; set; }
    }
}