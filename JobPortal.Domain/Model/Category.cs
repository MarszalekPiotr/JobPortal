﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public  class Category
    {
         public int Id { get; set; }
         public string Name { get; set; }
          
        public virtual ICollection<Job> Jobs { get; set; }

    }
}
