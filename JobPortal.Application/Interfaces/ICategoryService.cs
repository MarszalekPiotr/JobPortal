﻿using JobPortal.Application.ViewModels.CategoryVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Interfaces
{
    public  interface ICategoryService
    {
        int AddCategory(NewCategoryViewModel category);
        void DeleteCategory(int id);
        ListCategoryForListViewModel GetCateogryList();
    }
}
