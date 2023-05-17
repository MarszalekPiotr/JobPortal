using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.CompanyVm
{
    public  class ListOfCompanyForListViewModel
    {
        public List<CompanyForListViewModel> Comapanies { get; set; }
        public int Count { get; set; }
    }
}
