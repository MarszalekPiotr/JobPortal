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
        ApplicationDetailsViewModel GetApplicationDetailsByApplicationId(string UserId, int JobId);

        int AddApplication(NewApplicationViewModel newApplication);

        List<JobPortal.Domain.Model.Application> GetAllApplications();
        ApplicationFileViewModel GetUserCvByApplicationId(string UserId, int JobId);
    }
}
