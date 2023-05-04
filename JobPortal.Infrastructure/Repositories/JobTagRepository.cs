using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobTagRepository
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

        public void RemoveJobTag(int jobTagId)
        {
            JobTag jobTag = _context.JobTags.FirstOrDefault(jt => jt.Id == jobTagId);
            if (jobTag != null)
            {
                _context.Remove(jobTag);
                _context.SaveChanges();
            }
                
        }

    }
}
