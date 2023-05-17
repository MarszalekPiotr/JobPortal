using JobPortal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            // Lista kategorii z podstawowoymi operacjami 
            return View();
        }

        //dodanie kategorii admin
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddCategory(CategoryModel model)
        //{
        //    var id = _categoryService.AddCategory(model);
        //    return View();
        //}

        [HttpGet]
        public IActionResult ViewCategory(int CategoryId)
        {   
            // var dbModel = _categoryService.GetById(categoryId)
            // tworzenie view modelu ez 
            return View();
        }


    }
}
