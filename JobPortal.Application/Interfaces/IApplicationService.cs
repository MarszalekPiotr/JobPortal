using JobPortal.Application.ViewModels.ApplicationVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Interfaces
{
    public  interface IApplicationService
    {
        ListOfApplicationsViewModel GetApplicationsByJobId(int jobId);
        ApplicationDetailsViewModel GetApplicationDetailsByApplicationId(int ApplicationId);

        int AddApplication(NewApplicationViewModel newApplication);
    }
}
