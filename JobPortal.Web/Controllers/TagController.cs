using JobPortal.Application.Interfaces;
using JobPortal.Application.Services;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Application.ViewModels.JobVM;
using JobPortal.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {   

           var model = _tagService.GetAllTags();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTag()
        {
            return View(new NewTagViewModel());
        }

        [HttpPost]
        public IActionResult AddTag(NewTagViewModel model)
        {
            var id = _tagService.AddTag(model);

            return RedirectToAction("Index");
        }

    }
}
