using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.NormalUsersVm
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

    }
}
