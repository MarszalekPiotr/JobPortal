using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public  class JobRepository
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

        public void UpdateJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _context.Jobs.Update(job);
                _context.SaveChanges();
            }
        }


        public Job GetJob(int jobId)
        {    
            return _context.Jobs.FirstOrDefault(j => j.Id == jobId);
        }

        public IQueryable<Job> GetJobsByCategoryId(int categoryId)
        {
            var jobs = _context.Jobs.Where(j => j.CategoryId == categoryId);
            if( jobs != null)
            {
                return jobs;
            }
            throw new NullReferenceException();
        }

        public IQueryable<Job> GetAllJobs()
        {
            var jobs = _context.Jobs;
            return jobs;
        }

       
      



    }
}
