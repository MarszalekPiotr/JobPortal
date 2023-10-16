using JobPortal.Application.Interfaces;
using JobPortal.Application.Services;
using JobPortal.Domain.Model;
using JobPortal.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobPortal.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, IJobService jobService, UserManager<User> userManager)
        {
            _logger = logger;
            _jobService = jobService;
            _userManager = userManager;
        }

        //[Route("Jobs/All")]
        public IActionResult Index()
        {
            if (User.IsInRole("Company"))
            {
                return RedirectToAction("CompanyPanel", "Job");
            }
            if (User.IsInRole("NormalUser"))
            {
                return RedirectToAction("Index", "Job");
            }

            
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

        public IActionResult Denied()
        {
            return View();
        }
    }
}