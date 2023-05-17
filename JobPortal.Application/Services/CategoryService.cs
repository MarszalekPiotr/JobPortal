using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobPortal.Application.Interfaces;
using JobPortal.Application.Mapping;
using JobPortal.Application.ViewModels.CategoryVm;
using JobPortal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public int AddCategory(NewCategoryViewModel category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public ListCategoryForListViewModel GetCateogryList()
        {
            var CategoriesModels = _categoryRepository.GetAllCategories();
            var Categories = new List<CategoryForListViewModel>();

            foreach(var category in CategoriesModels)
            {
                Categories.Add(new CategoryForListViewModel() { Id = category.Id, Name = category.Name });
            }
           



            var listOfCategories = new ListCategoryForListViewModel()
            {
                Categories = Categories,
                Count = Categories.Count

            };

            return listOfCategories;

        }
    }
}
