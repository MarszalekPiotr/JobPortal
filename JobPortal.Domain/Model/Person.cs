using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public  class Person
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }

      public string Email { get; set; } 

      public string PhoneNumber { get; set; }
     
      public string Address { get; set; }

      public DateTime BirthDate { get; set; }

      public int UserId { get; set; }
      public virtual User User { get; set; }

      public virtual ICollection<Application> Applications { get;}

      



    }
}
