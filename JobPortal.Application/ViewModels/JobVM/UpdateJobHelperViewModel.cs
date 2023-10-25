using JobPortal.Application.ViewModels.JobvM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVM
{
    public  class UpdateJobHelperViewModel
    {
        public int JobId { get; set; }
        public JobDetailsViewModel PreviousJob { get; set; }

        public decimal LowestSalary { get; set; }

        public decimal HighestSalary { get;  set; }
    }
}
