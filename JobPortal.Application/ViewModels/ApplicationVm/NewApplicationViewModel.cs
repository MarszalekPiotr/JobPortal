using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.ApplicationVm
{
    public  class NewApplicationViewModel
    {   
        public int Id { get; set; }
        public string UserId { get; set; }
        public int JobId { get; set; }
        public IFormFile CV { get; set; }
    }
}
