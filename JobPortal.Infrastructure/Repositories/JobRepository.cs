using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public  class JobRepository : IJobRepository
    {    

        private readonly Context _context;
        public JobRepository(Context context)
        {
            _context = context;
        }


        
        public void DeleteJob(int jobId)
        {
          



            Job jobToRemove = _context.Jobs.FirstOrDefault(j => j.Id == jobId);
            if (jobToRemove != null) 
            {
                List<JobTag> jobTags = _context.JobTags.Where(jt => jt.JobId == jobId).ToList();
                if (jobTags != null)
                {
                    _context.RemoveRange(jobTags);
                    _context.SaveChanges();
                }
                var appliations = _context.Applications.Where(a => a.JobId == jobId);

                _context.Applications.RemoveRange(appliations);
                _context.SaveChanges();
                _context.Jobs.Remove(jobToRemove);

                
                _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public int AddJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _context.Jobs.Add(job);
                _context.SaveChanges();
                return job.Id;
            }
        }

        public int UpdateJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException();
            }
            else
            {    
                _context.Jobs.Update(job);
                _context.SaveChanges();
                return job.Id;
            }
        }


        public Job GetJob(int jobId)
        {    
            return _context.Jobs.FirstOrDefault(j => j.Id == jobId);
        }

        public List<Job> GetJobsByCategoryId(int categoryId)
        {
            var jobs = _context.Jobs.Where(j => j.CategoryId == categoryId);
            if( jobs != null)
            {
                return jobs.ToList();
            }
            throw new NullReferenceException();
        }

        public List<Job> GetAllJobs()
        {
            var jobs = _context.Jobs.ToList();
            return jobs;
        }

       
      



    }
}
