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
            return View();
            //return File(applications[0].CVFile, System.Net.Mime.MediaTypeNames.Application.Octet, "application.pdf");

        }

        public IActionResult ApplicationAtJob(int id)
        {
            var model = _applicationService.GetApplicationsByJobId(id);
            return View(model);
        }

        public IActionResult ApplicationDetails(string UserId, int JobId)
        {
            var model = _applicationService.GetApplicationDetailsByApplicationId(UserId,JobId);
            return View(model);
        }

        public IActionResult DownloadCv(string UserId, int JobId)
        {
            var applicationFileVm = _applicationService.GetUserCvByApplicationId(UserId, JobId);
            var fileBytes = applicationFileVm.CVFile;
            var fileName = $"{applicationFileVm.UserSurname}_{applicationFileVm.UserName}_CV.pdf";

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }

        public IActionResult OpenCv(string UserId, int JobId)
        {
            var applicationFileVm = _applicationService.GetUserCvByApplicationId(UserId, JobId);
            var fileBytes = applicationFileVm.CVFile;
            var fileName = $"{applicationFileVm.UserSurname}_{applicationFileVm.UserName}_CV.pdf";

            return File(fileBytes ,"application/pdf");

        }
    }
}
