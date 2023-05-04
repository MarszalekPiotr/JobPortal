using JobPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Interfaces
{
    public  interface ICategoryRepository
    {



        int AddCategory(Category category);
        void Updateategory(Category category);
        void Deletecategory(int CategoryId);
        IQueryable<Category> GetAllCategories();
        Category GetCategory(int CategoryId);
        
    }
}
