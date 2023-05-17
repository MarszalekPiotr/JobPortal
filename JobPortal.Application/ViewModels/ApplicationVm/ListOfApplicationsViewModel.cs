using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.ApplicationVm
{
    public  class ListOfApplicationsViewModel
    {
        public List<ApplicationForListViewModel> Applications;
        public int Count { get; set; }
    }
}
