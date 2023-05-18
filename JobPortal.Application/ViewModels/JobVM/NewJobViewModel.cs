using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVm
{
    public  class NewJobViewModel
    {    
        public int Id { get; set; }
        public string Name { get ; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal LowestSalary { get; set; }
        public decimal HighestSalary { get; set; }

        public int CategoryId { get; set; }

        public CategoryForListViewModel  Category { get; set; }
        public ListOfTagsForListViewModel Tags { get; set; }

    }
}
