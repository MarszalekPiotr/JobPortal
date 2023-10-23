using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.JobVM
{
    public class UpdateJobViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal LowestSalary { get; set; }
        public decimal HighestSalary { get; set; }

        public int CategoryId { get; set; }


        public List<int> TagsIds { get; set; }

        public bool RemoveCurrentApplicationsAtJob { get; set; }

    }
}
