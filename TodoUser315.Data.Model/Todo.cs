using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoUser315.Data.Model
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Task { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
