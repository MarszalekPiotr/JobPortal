using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public class User : IdentityUser
    {  
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsCompany { get; set; }

        public string Description { get; set; }
       
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Application>? Applications { get; set; }
        public virtual ICollection<Job>? Jobs { get; set; }

   
    }
}
