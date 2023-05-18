using JobPortal.Application.Interfaces;
using JobPortal.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;
        private readonly UserManager<User> _userManager;


      

        public JobController(ILogger<JobController> logger, IJobService jobService, UserManager<User> userManager)
        {
            _logger = logger;
            _jobService = jobService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var listOfJobs = _jobService.GetAllJobs();
            // stworzenie widoku na górze wyszukiwarka i pod nia lista
            // pobranie z seriwsu listy elementow i przekazanie do wikdoku 
            // serwis musi przygotwac dane i zwrocic je w odpowiednim formacie
            // mozliwe ze viewmodel ale w sumue w moim przypadku jest git 
            return View();
        }

        // dodac role jako firma tylko ez
        //[Authorize(Roles = "Company")]
        public IActionResult CompanyPanel()
        {

            // wziac id obecnego usera czyli firmy
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var id = _userManager.GetUserId(User);
            var listOfJobs = _jobService.GetJobByCompanyId(id);
            return View(listOfJobs);
        }
    }
}
