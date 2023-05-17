using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobvM
{
    public class ListOfJobsForListViewModel
    {
        public List<JobForListViewModel> Jobs { get; set; }
        public int Count { get; set; }
    }
}
