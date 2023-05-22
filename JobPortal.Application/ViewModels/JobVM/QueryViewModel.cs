using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVM
{
    public  class QueryViewModel
    {
        public string SearchString { get; set; }
        public int CategoryName { get; set; }
        public List<int> TagNames { get; set; }

        public string LocationSearchString { get; set; }
    }
}
