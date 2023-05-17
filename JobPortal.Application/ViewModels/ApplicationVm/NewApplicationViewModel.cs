using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.ApplicationVm
{
    public  class NewApplicationViewModel
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public byte[] CV { get; set; }
    }
}
