using JobPortal.Application.Interfaces;
using JobPortal.Application.Services;
using JobPortal.Application.ViewModels.ApplicationVm;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;
        private readonly UserManager<User> _userManager;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;
        private readonly IApplicationService _applicationService;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IJobRepository _jobRepository;

        public JobController(ILogger<JobController> logger, IJobService jobService, UserManager<User> userManager, ITagService tagService, ICategoryService categoryService, IApplicationService applicationService, IApplicationRepository applicationRepository, IJobRepository jobRepository)
        {
            _logger = logger;
            _jobService = jobService;
            _userManager = userManager;
            _tagService = tagService;
            _categoryService = categoryService;
            _applicationService = applicationService;
            _applicationRepository = applicationRepository;
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public IActionResult Apply(int id)
        {
            NewApplicationViewModel newApp = new NewApplicationViewModel()
            {
                JobId = id,
                UserId = _userManager.GetUserId(User)
            };

            return View(newApp);
        
        }
        [HttpPost]
        public IActionResult Apply(NewApplicationViewModel newApp)
        {
            // dodanie aplikacji

            _applicationService.AddApplication(newApp);

            return RedirectToAction("Index");

        }



        public IActionResult DetailsForUser(int id)
        {
            var CurrentUserId = _userManager.GetUserId(User);
            if (User.IsInRole("Company") && _jobRepository.GetJob(id).UserId == CurrentUserId)
            {
                ViewData["IsCompany"] = true;
                ViewData["AlreadyApplied"] = false;
                ViewData["IsUser"] = false;
            }
            else if(User.IsInRole("NormalUser"))
            {
                ViewData["IsUser"] = true;
                ViewData["IsCompany"] = false;
             
                if (_applicationRepository.Exist(CurrentUserId, id))
                {
                    ViewData["AlreadyApplied"] = true;
                 
                }
                else
                {
                    ViewData["AlreadyApplied"] = false;
                }
            }
            else
            {
                ViewData["IsUser"] = false;
                ViewData["IsCompany"] = false;
                ViewData["AlreadyApplied"] = false;
            }
            
            

            var model = _jobService.GetJobDetailsForUser(id);
            return View(model);

        }

        //[Route("Jobs/all")]
        public IActionResult Index()
        {
            var tagsListViewModel = _tagService.GetAllTags();
            var categoryListViewModel = _categoryService.GetCateogryList();

            ViewData["Categories"] = new SelectList(categoryListViewModel.Categories, "Id", "Name");
            ViewData["Tags"] = new SelectList(tagsListViewModel.Tags, "Id", "Name");
            ViewData["Jobs"] = _jobService.GetAllJobs();

            return View();
        }

        [HttpPost]
        public IActionResult Index(QueryViewModel qvm)
        {   

            var tagsListViewModel = _tagService.GetAllTags();
            var categoryListViewModel = _categoryService.GetCateogryList();
            // podmiana id i name
            ViewData["Categories"] = new SelectList(categoryListViewModel.Categories,   "Id", "Name");
            ViewData["Tags"] = new SelectList(tagsListViewModel.Tags, "Id", "Name");

            var searchStringJobName = qvm.SearchString;
            var SearchStringCategoryName = qvm.CategoryName;
            var TagNames = qvm.TagNames;
            var Location = qvm.LocationSearchString;
            ViewData["Jobs"] =  _jobService.GetAllJobsForUser(searchStringJobName,  SearchStringCategoryName, TagNames, Location);

            return View();
        }

        // dodac role jako firma tylko ez
        //[Authorize(Roles = "Company")]
        [Authorize(Roles = "Company")]
        public IActionResult CompanyPanel()
        {

            // wziac id obecnego usera czyli firmy
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);
            var listOfJobs = _jobService.GetJobByCompanyId(id);
            return View(listOfJobs);
        }


        [HttpGet]
        [Authorize(Roles ="Company")]
        public IActionResult AddJob()
        {
            // pobrac wszystkie tagi i kategorie i dodac potem w formularzu ez
            var tagsListViewModel = _tagService.GetAllTags();
            var categoryListViewModel = _categoryService.GetCateogryList();

            ViewData["Categories"] = new SelectList(categoryListViewModel.Categories, "Id", "Name");
            ViewData["Tags"] = new SelectList(tagsListViewModel.Tags, "Id", "Name");

            return View(new NewJobViewModel());
        }

        [HttpPost]
        public IActionResult AddJob(NewJobViewModel model)
        {   
            var idOfCurrentUser = _userManager.GetUserId(User);
            var id = _jobService.AddJob(idOfCurrentUser ,model);

            return RedirectToAction("CompanyPanel");
        }

        [HttpGet]
        [Authorize(Roles = "Company")]
        public IActionResult RemoveJobRequest(int id)
        {
            var JobToDelete = _jobService.GetJobDetailsForUser(id);
            var JobToCheck = _jobRepository.GetJob(id);
            //  Chek if User that want delete job is the owner
            var urrentUser = this.User;
            var currentUserId = _userManager.GetUserId(urrentUser);
            if(JobToCheck.UserId == currentUserId)
            {
                return View(JobToDelete);
            }

            return RedirectToAction("Denied", "Home");


        }

        [HttpGet]
        public IActionResult RemoveJob(int id)
        {
            var removedJobId = _jobService.DeleteJob(id);
            return RedirectToAction("CompanyPanel");
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {   
            

            var tagsListViewModel = _tagService.GetAllTags();
            var categoryListViewModel = _categoryService.GetCateogryList();
            ViewData["Categories"] = new SelectList(categoryListViewModel.Categories, "Id", "Name");
            ViewData["Tags"] = new SelectList(tagsListViewModel.Tags, "Id", "Name");


            var jobToUpdate  =   _jobService.GetJobDetailsForUser(id);
           
            var jobToUpdateTags = jobToUpdate.Tags;
            List<int> tagsIds = jobToUpdateTags.Select(jt => jt.Id).ToList();
            //jobToUpdateTags.ForEach(jtt => Ids.Add(jtt.Id));

            ViewData["ModelHelper"] = new UpdateJobHelperViewModel()
            {
                JobId = jobToUpdate.Id,
                PreviousJob = jobToUpdate,
                LowestSalary = jobToUpdate.LowestSalary,
                HighestSalary = jobToUpdate.HighestSalary
            };

            // delete
            ViewData["PreviousJob"] = jobToUpdate;
            ViewData["ID"] = jobToUpdate.Id;
            ViewData["LOWEST"] = jobToUpdate.LowestSalary;
            ViewData["HIGHEST"] = jobToUpdate.HighestSalary;

           // var jobToUpdateTagsIds = Ids;
            return View(new UpdateJobViewModel()
            {
                Id = id,
                Name = jobToUpdate.Name,
                Description = jobToUpdate.Description,
                Location = jobToUpdate.Location,
                LowestSalary = jobToUpdate.LowestSalary,
                HighestSalary = jobToUpdate.HighestSalary,
                TagsIds = tagsIds

            }
                ) ;
        
        }

        [HttpPost]
        public IActionResult UpdateJob(UpdateJobViewModel updateJobViewModel)
        {
            _jobService.UpdateJob(updateJobViewModel);
            return RedirectToAction("CompanyPanel");
        }


    }
}
