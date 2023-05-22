using JobPortal.Application.Interfaces;
using JobPortal.Application.Services;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;
        private readonly UserManager<User> _userManager;
        private readonly ITagService _tagService;
        private readonly ICategoryService _categoryService;

        public JobController(ILogger<JobController> logger, IJobService jobService, UserManager<User> userManager, ITagService tagService, ICategoryService categoryService)
        {
            _logger = logger;
            _jobService = jobService;
            _userManager = userManager;
            _tagService = tagService;
            _categoryService = categoryService;
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
            ViewData["Jobs"] =  _jobService.GetAllJobsForUser(searchStringJobName,  SearchStringCategoryName, TagNames);

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
    }
}
