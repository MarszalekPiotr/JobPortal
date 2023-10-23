using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Interfaces
{
    public interface IApplicationRepository
    {

        int AddApplication(Application application);
        void RemoveApplicationById(int ApplicationId);
        List<Application> GetAllApplications();

        Application GetApplicationById(string UserId,int JobId);
        bool Exist(string UserId, int JobId);

        void RemoveApplicationsByJobId(int id);

        List<Application> GetAllApplicationsByJobId(int jobId);



    }
}
