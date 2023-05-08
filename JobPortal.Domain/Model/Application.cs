using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Model
{
    public  class Application
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public virtual User User { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte[] CVFile { get; set; }
    }
}
