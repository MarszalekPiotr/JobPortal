using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.JobvM;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private readonly IApplicationRepository _applicationRepository;
        public JobService(IJobRepository jobRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IJobTagRepository jobTagRepository, ITagRepository tagRepository, IApplicationRepository applicationRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _jobTagRepository = jobTagRepository;
            _tagRepository = tagRepository;
            _applicationRepository = applicationRepository;
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

           int jobIdToAddingJobTag =  _jobRepository.AddJob(JobToAdd);
            jobFromForm.TagsIds.ForEach(t => _jobTagRepository.AddJobTag(new JobTag() { JobId = jobIdToAddingJobTag, TagId = t }));

            


            return JobToAdd.Id;
        }

        public int DeleteJob(int JobId)
        {   
            _jobRepository.DeleteJob(JobId);

            return JobId;
        }

        // zmienic parametry dla filtrowania i paginacji
        // zmienic model lekko z page size itd.
        // zmienic nazwe funkcji
        public ListOfJobsForListViewModel GetAllJobsForUser(string searchStringJobName, int SearchStringCategoryName, List<int> TagNames, string searchStringLocation)
        {
            var jobs = _jobRepository.GetAllJobs();
            List<JobForListViewModel> listOfJobsForViewModel = new List<JobForListViewModel>();
            ListOfJobsForListViewModel listModel = new ListOfJobsForListViewModel();
            listModel.Jobs = new List<JobForListViewModel>();

            foreach (var job in jobs)
            {
                // znalezc User Name i Category Name dzieki id ktore jest w job
                var category = _categoryRepository.GetCategory(job.CategoryId);
                var user = _userRepository.GetUserById(job.UserId);
                var jobTagsForOffer = _jobTagRepository.GetJobTagsByJobId(job.Id);
                var tags = new List<Tag>();
                // tu pownno byc mapowanie chyba xd
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
                    // mamy cale tagi ;/
                    Tags = tags


                };
                listModel.Jobs.Add(jobToAddToViewModel);


            }
            var CategoryForSearch =  _categoryRepository.GetCategory(SearchStringCategoryName);
            listModel.Jobs = (List<JobForListViewModel>)listModel.Jobs.Where(j => j.Name.StartsWith(searchStringJobName))
             .Where(j => j.CategoryName == CategoryForSearch.Name)
             .Where(j => TagNames.All(tn => j.Tags.Any(t => tn == t.Id)) || TagNames.Any(tn => j.Tags.Any(t => tn ==t.Id)))
             .Where(j => j.Location.StartsWith(searchStringLocation))
             .ToList();


            listModel.Count = listOfJobsForViewModel.Count;
            // logika do zwracania przefiltrowanych ofert Tags where t => t.name == tag name podany z controllera itd.
            return listModel;
        }
        public ListOfJobsForListViewModel GetAllJobs()
        {
            var jobs = _jobRepository.GetAllJobs();
            List<JobForListViewModel> listOfJobsForViewModel = new List<JobForListViewModel>();
            ListOfJobsForListViewModel listModel = new ListOfJobsForListViewModel();
            listModel.Jobs = new List<JobForListViewModel>();

            foreach (var job in jobs)
            {
                // znalezc User Name i Category Name dzieki id ktore jest w job
                var category = _categoryRepository.GetCategory(job.CategoryId);
                var user = _userRepository.GetUserById(job.UserId);
                var jobTagsForOffer = _jobTagRepository.GetJobTagsByJobId(job.Id);
                var tags = new List<Tag>();
                // tu pownno byc mapowanie chyba xd
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
                    // mamy cale tagi ;/
                    Tags = tags


                };
                listModel.Jobs.Add(jobToAddToViewModel);


            }
            listModel.Count = listOfJobsForViewModel.Count;
            // logika do zwracania przefiltrowanych ofert Tags where t => t.name == tag name podany z controllera itd.
            return listModel;
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
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Location { get; set; }
        //public decimal LowestSalary { get; set; }
        //public decimal HighestSalary { get; set; }
        //public string CategoryName { get; set; }
        //public string CompanyName { get; set; }

        //public List<Tag> Tags { get; set; }
        public JobDetailsViewModel GetJobDetailsForUser(int jobId)
        {
            var jobFromDatabase = _jobRepository.GetJob(jobId);
            var CompanyName = _userRepository.GetUserById(jobFromDatabase.UserId).Name;
            var CategoryName = _categoryRepository.GetCategory(jobFromDatabase.CategoryId).Name;
            List<JobTag> JobTags = _jobTagRepository.GetJobTagsByJobId(jobId);
            List<Tag> Tags = new List<Tag>();
            JobTags.ForEach(jt => Tags.Add(_tagRepository.GetTag(jt.TagId)));
            JobDetailsViewModel jobDetailsViewModel = new JobDetailsViewModel()
            {
                Id = jobFromDatabase.Id,
                Name = jobFromDatabase.Name,
                Location = jobFromDatabase.Location,
                Description = jobFromDatabase.Description,
                LowestSalary = jobFromDatabase.LowestSalary,
                HighestSalary = jobFromDatabase.HighestSalary,
                CategoryName = CategoryName,
                CompanyName = CompanyName,
                Tags = Tags

            };

            return jobDetailsViewModel;
            
        }

        

        public int UpdateJob(UpdateJobViewModel jobFromForm)
        {

            

            var previousJob = _jobRepository.GetJob(jobFromForm.Id);
       

            var JobToUpdate = new Job()
            {
                
                Name = jobFromForm.Name,
                Description = jobFromForm.Description,
                Location = jobFromForm.Location,
                LowestSalary = jobFromForm.LowestSalary,
                HighestSalary = jobFromForm.HighestSalary,
                UserId = previousJob.UserId,
                CategoryId = jobFromForm.CategoryId


            };

            int newjobId = _jobRepository.UpdateJob(JobToUpdate);

            // restore jobTags
            jobFromForm.TagsIds.ForEach(t => _jobTagRepository.AddJobTag(new JobTag() { JobId = newjobId, TagId = t }));

            /*restore applications*/
            if (!jobFromForm.RemoveCurrentApplicationsAtJob)
            {
                var previousApps = _applicationRepository.GetAllApplicationsByJobId(jobFromForm.Id);

                previousApps.ForEach(pa => _applicationRepository.AddApplication(new JobPortal.Domain.Model.Application()
                {
                    JobId = newjobId,
                    UserId = pa.UserId,
                    CVFile = pa.CVFile,
                    CreatedAt = pa.CreatedAt,
                }));

            }


            this.DeleteJob(jobFromForm.Id);


            return JobToUpdate.Id;
        }

        
    }
}
