﻿using JobPortal.Application.ViewModels.NormalUsersVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.ViewModels.ApplicationVm
{
    public  class ApplicationDetailsViewModel
    {
        public UserDetailsViewModel UserDetails { get; set; }
        public byte[] CV { get; set; }
    }
}