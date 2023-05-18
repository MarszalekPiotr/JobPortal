using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.CompanyVm;
using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ListOfCompanyForListViewModel GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        //public CompanyDetailsViewModel GetCompanyDetailsById(string Id)
        //{
         
        //    User userFromRepo = _userRepository.GetUserById(Id);
        //    CompanyDetailsViewModel companyDetailsViewModel = new CompanyDetailsViewModel()
        //    {

        //    };



        //}
    }
}
