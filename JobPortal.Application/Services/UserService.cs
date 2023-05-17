using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.CompanyVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class UserService : IUserService
    {
        public ListOfCompanyForListViewModel GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public CompanyDetailsViewModel GetCompanyDetailsById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
