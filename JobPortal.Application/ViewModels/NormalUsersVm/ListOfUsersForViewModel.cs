using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.NormalUsersVm
{
    public  class ListOfUsersForViewModel
    {
        public List<UserForListViewModel> Users { get; set; }
        public int Count { get; set; }
    }
}
