using JobPortal.Domain.Interfaces;
using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Infrastructure.Repositories
{
    public  class CategoryRepository  : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public int AddCategory(Category category)
        {
            if(category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category.Id;
            }
            throw new Exception();
        }
        public void Updateategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Deletecategory(int CategoryId)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == CategoryId);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }

        public Category GetCategory(int CategoryId)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == CategoryId);
            if(category != null)
            {
                return category;
            }
            else
            {
                throw new NullReferenceException();
            }

        }


    }
}
