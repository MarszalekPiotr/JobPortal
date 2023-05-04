using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public  class JobTag
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }


        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }


    }
}
