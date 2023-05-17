using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.ApplicationVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        public int AddApplication(NewApplicationViewModel newApplication)
        {
            throw new NotImplementedException();
        }

        public ApplicationDetailsViewModel GetApplicationDetailsByApplicationId(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public ListOfApplicationsViewModel GetApplicationsByJobId(int jobId)
        {
            throw new NotImplementedException();
        }
    }
}
