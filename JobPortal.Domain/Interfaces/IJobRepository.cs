using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Interfaces
{
     public  interface IJobRepository
     {

        void DeleteJob(int jobId);
        int AddJob(Job job);
        void UpdateJob(Job job);
        public Job GetJob(int jobId);
        IQueryable<Job> GetJobsByCategoryId(int categoryId);
        IQueryable<Job> GetAllJobs();
        


    }
}
