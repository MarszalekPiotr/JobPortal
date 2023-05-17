using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.JobvM;
using JobPortal.Application.ViewModels.JobVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class JobService : IJobService
    {
        public int AddJob(int CompanyId, NewJobViewModel job)
        {
            throw new NotImplementedException();
        }

        public int DeleteJob(int JobId)
        {
            throw new NotImplementedException();
        }

        public ListOfJobsForListViewModel GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public ListOfJobsForListViewModel GetJobByCompanyId(int comoanyId)
        {
            throw new NotImplementedException();
        }

        public JobDetailsViewModel GetJobDetails(int jobId)
        {
            throw new NotImplementedException();
        }

        public int UpdateJob(int id, NewJobViewModel model)
        {
            throw new NotImplementedException();
        }

        
    }
}
