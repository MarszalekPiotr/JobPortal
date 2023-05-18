using JobPortal.Application.Interfaces;
using JobPortal.Application.ViewModels.CategoryVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobPortal.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        //admin
        public IActionResult Index()
        {
            var model = _categoryService.GetCateogryList();
            return View(model);
        }

        //dodanie kategorii admin
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new NewCategoryViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(NewCategoryViewModel model)
        {
            var id = _categoryService.AddCategory(model);
            
            return RedirectToAction("Index");
        }


        //useless chyba
        [HttpGet]
        public IActionResult ViewCategory(int CategoryId)
        {   
            // var dbModel = _categoryService.GetById(categoryId)
            // tworzenie view modelu ez 
            return View();
        }


    }
}
