using JobPortal.Application.ViewModels.JobvM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.CompanyVm
{
    public  class CompanyDetailsViewModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public ListOfJobsForListViewModel Jobs { get; set; }
    }
}
