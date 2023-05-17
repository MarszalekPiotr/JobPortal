using JobPortal.Application.ViewModels.ApplicationVm;
using JobPortal.Application.ViewModels.JobvM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVM
{
    public  class JobDetailsForCompanyViewModel
    {
        public ListOfApplicationsViewModel listOfApplications {  get; set; }
        public  JobDetailsViewModel jobDetails { get; set; }
    }
}
