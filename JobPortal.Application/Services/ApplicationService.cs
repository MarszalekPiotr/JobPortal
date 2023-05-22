using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.ApplicationVm;
using JobPortal.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public List<JobPortal.Domain.Model.Application> GetAllApplications()
        {
            var ApplicationsFromDb = _applicationRepository.GetAllApplications();
            
            return ApplicationsFromDb;
        }

        public  byte[] ToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public int AddApplication( NewApplicationViewModel newApplication)
        {


            if (newApplication.CV != null)
            {
                using (var stream = newApplication.CV.OpenReadStream())
                {
                    
                    
                        
                      var  file_data = ToByteArray(stream);
                    var id = _applicationRepository.AddApplication(new JobPortal.Domain.Model.Application()
                    {
                    UserId = newApplication.UserId,
                    JobId = newApplication.JobId,
                     
                    CVFile = file_data


                  });
                  return id;
            
                    
                }
            }

            return 0;


            

           




           
        }

        public ApplicationDetailsViewModel GetApplicationDetailsByApplicationId(int ApplicationId)
        {
            throw new NotImplementedException();
        }

        public ListOfApplicationsViewModel GetApplicationsByJobId(int jobId)
        {
            throw new NotImplementedException();
        }
    }
}
