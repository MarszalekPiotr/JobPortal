using JobPortal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public IActionResult Index()
        {    
            var applications = _applicationService.GetAllApplications();
            return File(applications[0].CVFile, System.Net.Mime.MediaTypeNames.Application.Octet, "application.pdf");
            
        }
    }
}
