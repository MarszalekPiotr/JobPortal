using JobPortal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;

        public JobController(ILogger<JobController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
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
    }
}
