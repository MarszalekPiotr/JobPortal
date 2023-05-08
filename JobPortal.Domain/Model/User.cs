using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public class User : IdentityUser
    {  

        //wspolne
        //public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public bool IsCompany { get; set; }

        // optional
        public string? Surname { get; set; }

        public virtual ICollection<Application>? Applications { get; set; }
        public virtual ICollection<Job>? Jobs { get; set; }

       //public virtual Company Company { get; set; }

       //public virtual Person Person { get; set; }
    }
}
