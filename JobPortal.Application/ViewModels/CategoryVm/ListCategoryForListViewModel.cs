using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.CategoryVm
{
    public  class ListCategoryForListViewModel
    {
        public List<CategoryForListViewModel> Categories { get; set; }
        public int Count { get; set; }
    }
}
