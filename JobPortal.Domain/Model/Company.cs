using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public  class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string NIP { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Locaization { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
