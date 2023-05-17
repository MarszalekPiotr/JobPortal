using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobvM
{
    public class JobForListViewModel
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public string Location { get; set; }
        public decimal LowestSalary { get; set; }
        public decimal HighestSalary { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }

        public List<Tag> Tags { get; set; } 


    }
}
