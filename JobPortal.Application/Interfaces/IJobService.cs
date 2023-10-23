using JobPortal.Application.ViewModels.JobvM;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Application.ViewModels.JobVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Interfaces
{
    public  interface IJobService
    {

        ListOfJobsForListViewModel GetAllJobs();
        ListOfJobsForListViewModel GetAllJobsForUser(string searchStringJobName, int SearchStringCategoryName, List<int> TagNames, string searchStringLocation);
        ListOfJobsForListViewModel GetJobByCompanyId(string companyId);
        int AddJob(string CompanyId,NewJobViewModel job);
        JobDetailsViewModel GetJobDetailsForUser(int jobId);
        int UpdateJob( UpdateJobViewModel model );
        int DeleteJob(int JobId);




    }
}
