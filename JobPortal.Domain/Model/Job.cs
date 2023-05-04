using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal LowestSalary { get; set; }
        public decimal HighestSalary { get;  set; }

        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int UserId { get; set; }
         public User User { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<JobTag> JobTags { get; set; }






    }
}
