using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobTagRepository : IJobTagRepository
    {
        private readonly Context _context;

        public JobTagRepository(Context context) 
        {
            _context = context;
        }

        public int AddJobTag(JobTag jobTag)
        {
           if(jobTag != null)
            {
                _context.JobTags.Add(jobTag);
                _context.SaveChanges();
                return jobTag.Id;

            }
            throw new Exception();
        }

        public List<JobTag> GetJobTagsByJobId(int jobId)
        {
            List<JobTag> JobTags = _context.JobTags.Where( j => j.JobId == jobId).ToList();
            return JobTags;
        }

        public void RemoveJobTag(int jobTagId)
        {
            throw new NotImplementedException();
        }

        public void RemoveJobTagByJobId(int jobId)
        {
            List<JobTag> jobTags = _context.JobTags.Where(jt => jt.JobId == jobId).ToList();
            if (jobTags != null)
            {
                _context.RemoveRange(jobTags);
                _context.SaveChanges();
            }
                
        }

    }
}
