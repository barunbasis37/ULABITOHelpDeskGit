using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABITOHelpDesk.Models
{
    public class Entity
    {
        public int ID { get; set; }
        public string CreatedIP { get; set; }
        public string UpdatedIP { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
