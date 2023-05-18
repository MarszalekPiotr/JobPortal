using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Interfaces
{
    public interface IJobTagRepository
    {
        int AddJobTag(JobTag jobTag);
        void RemoveJobTag(int jobTagId);

        List<JobTag> GetJobTagsByJobId(int jobId);
       

    }
}
