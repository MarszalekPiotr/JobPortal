using JobPortal.Application.ViewModels.JobvM;
using JobPortal.Application.ViewModels.JobVm;
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
        ListOfJobsForListViewModel GetJobByCompanyId(string companyId);
        int AddJob(string CompanyId,NewJobViewModel job);
        JobDetailsViewModel GetJobDetails(int jobId);
        int UpdateJob(int id, NewJobViewModel model );
        int DeleteJob(int JobId);



    }
}
