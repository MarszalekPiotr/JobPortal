using JobPortal.Application.ViewModels.JobVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVM
{
    public  class ListOfTagsForListViewModel
    {
        List<TagForListViewModel> Tags { get; set; }

        public int Count { get; set; }
    }
}
