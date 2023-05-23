using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.ApplicationVm
{
    public class ApplicationFileViewModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public byte[] CVFile { get; set; }

    }
}
