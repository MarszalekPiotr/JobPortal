using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.ApplicationVm;
using JobPortal.Application.ViewModels.NormalUsersVm;
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
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;

        public ApplicationService(IApplicationRepository applicationRepository, IUserRepository userRepository, IJobRepository jobRepository)
        {
            _applicationRepository = applicationRepository;
            _userRepository = userRepository;
            _jobRepository = jobRepository;
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

        public ApplicationFileViewModel GetUserCvByApplicationId(string UserId,int JobId)
        {    
            // zmienic na pobieranie Cv by UserId i JobId 
            var application = _applicationRepository.GetApplicationById(UserId,JobId);
            var user = _userRepository.GetUserById(application.UserId);
            ApplicationFileViewModel applicationFileViewModel = new ApplicationFileViewModel()
            {
                UserName = user.Name,
                UserSurname = user.Surname,
                CVFile = application.CVFile
            };

            return applicationFileViewModel;
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
                    //Id = newApplication.Id,
                    UserId = newApplication.UserId,
                    JobId = newApplication.JobId,
                     
                    CVFile = file_data


                  });
                  return id;
            
                    
                }
            }

            return 0;


            

           




           
        }

        // zmienic na job id i user id
        public ApplicationDetailsViewModel GetApplicationDetailsByApplicationId(string UserId, int JobId)
        {
            var application = _applicationRepository.GetApplicationById(UserId, JobId);
            var Applicant = _userRepository.GetUserById(application.UserId);

            UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel()
            {
                Id = Applicant.Id,
                Name = Applicant.Name,
                Surname = Applicant.Surname,
                Email = Applicant.Email,
                PhoneNumber = Applicant.PhoneNumber,
                Address = Applicant.Address,
                Description = Applicant.Description


            };
            ApplicationDetailsViewModel applicationDetailsViewModel = new ApplicationDetailsViewModel();
            applicationDetailsViewModel.JobId= application.JobId;
            applicationDetailsViewModel.UserDetails = userDetailsViewModel;
            applicationDetailsViewModel.ApplicationDate = application.CreatedAt;

            return applicationDetailsViewModel;

            

        }

        public ListOfApplicationsViewModel GetApplicationsByJobId(int jobId)
        {
            var applications = _applicationRepository.GetAllApplications().Where(app => app.JobId == jobId);
            var ListOfApplicationsVm = new ListOfApplicationsViewModel();
            List<ApplicationForListViewModel> applicationsForListViewModels = new List<ApplicationForListViewModel>();
            foreach (var application in applications)
            {    
                var Applicant = _userRepository.GetUserById(application.UserId);
                
                applicationsForListViewModels.Add(new ApplicationForListViewModel()
                {
                    
                    UserId = application.UserId,
                    JobId = application.JobId,
                    ApplicantName = Applicant.Name,
                    ApplicantEmail = Applicant.Email,
                    ApplicantSurname = Applicant.Surname,
                    DateTime  = application.CreatedAt,
                    
                    
                }) ;
            }
            ListOfApplicationsVm.Applications = applicationsForListViewModels;
            ListOfApplicationsVm.Count = applicationsForListViewModels.Count;
            return ListOfApplicationsVm;

        }
    }
}
