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
            var Categories = _categoryRepository.GetAllCategories()
                .ProjectTo<CategoryForListViewModel>(_mapper.ConfigurationProvider).ToList();

            var listOfCategories = new ListCategoryForListViewModel()
            {
                Categories = Categories,
                Count = Categories.Count

            };

            return listOfCategories;

        }
    }
}
