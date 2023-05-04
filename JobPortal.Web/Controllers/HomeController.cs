using JobPortal.Application.Interfaces;
using JobPortal.Application.Services;
using JobPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobPortal.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;

        public HomeController(ILogger<HomeController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        [Route("Jobs/All")]
        public IActionResult Index()
        {    
            
            //var listOfJobs = _jobService.GetAllJobs();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}