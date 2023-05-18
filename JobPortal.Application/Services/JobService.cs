using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.JobvM;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository  _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IJobTagRepository _jobTagRepository;
        private readonly ITagRepository _tagRepository;

        public JobService(IJobRepository jobRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IJobTagRepository jobTagRepository, ITagRepository tagRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _jobTagRepository = jobTagRepository;
            _tagRepository = tagRepository;
        }

        public int AddJob(string CompanyId, NewJobViewModel jobFromForm)
        {
            var JobToAdd = new Job()
            {
                Id = jobFromForm.Id,
                Name = jobFromForm.Name,
                Description = jobFromForm.Description,
                Location = jobFromForm.Location,
                LowestSalary = jobFromForm.LowestSalary,
                HighestSalary = jobFromForm.HighestSalary,
                UserId = CompanyId,
                CategoryId = jobFromForm.CategoryId


            };

            _jobRepository.AddJob(JobToAdd);


            return JobToAdd.Id;
        }

        public int DeleteJob(int JobId)
        {
            throw new NotImplementedException();
        }

        public ListOfJobsForListViewModel GetAllJobs()
        {
            throw new NotImplementedException();
        }
        //public int Id { get; set; }
        //public string Name { get; set; }
      
        //public string Location { get; set; }
        //public decimal LowestSalary { get; set; }
        //public decimal HighestSalary { get; set; }
        //public string CategoryName { get; set; }
        //public string CompanyName { get; set; }

  
        public ListOfJobsForListViewModel GetJobByCompanyId(string companyId)
        {
            var jobs = _jobRepository.GetAllJobs().Where(J => J.UserId == companyId);
            List<JobForListViewModel> listOfJobsForViewModel = new List<JobForListViewModel>();
            ListOfJobsForListViewModel listModel = new ListOfJobsForListViewModel();
            listModel.Jobs = new List<JobForListViewModel>();

            foreach(var job in jobs)
            {     
                // znalezc User Name i Category Name dzieki id ktore jest w job
                var category = _categoryRepository.GetCategory(job.CategoryId);
                var user = _userRepository.GetUserById(job.UserId);
                var jobTagsForOffer = _jobTagRepository.GetJobTagsByJobId(job.Id);
                var tags = new List<Tag>();
                foreach (var jobTag in jobTagsForOffer) 
                {
                    tags.Add(_tagRepository.GetTag(jobTag.TagId));
                }

                var jobToAddToViewModel = new JobForListViewModel()
                {
                    Id = job.Id,
                    Name = job.Name,
                    Location = job.Location,
                    LowestSalary = job.LowestSalary,
                    HighestSalary = job.HighestSalary,
                    CategoryName = category.Name, // ALBO WYSZUKAC PRZEZ ID!!
                    CompanyName = user.Name, // TAK SAMO
                    Tags = tags


                };
                listModel.Jobs.Add(jobToAddToViewModel);
                
                
            }
            listModel.Count = listOfJobsForViewModel.Count;

            return listModel;

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
