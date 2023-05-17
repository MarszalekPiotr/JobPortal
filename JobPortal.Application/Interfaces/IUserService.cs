using JobPortal.Application.ViewModels.CompanyVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Interfaces
{
    public  interface IUserService
    {
        ListOfCompanyForListViewModel GetAllCompanies();
        CompanyDetailsViewModel GetCompanyDetailsById(int Id);
    }
}
