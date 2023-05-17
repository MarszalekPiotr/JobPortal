using JobPortal.Application.ViewModels.NormalUsersVm;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.ApplicationVm
{
    public  class ApplicationForListViewModel
    {
        public UserForListViewModel Applicant;
        public string JobName { get; set; }
        public DateTime DateTime { get; set; }

    }
}
