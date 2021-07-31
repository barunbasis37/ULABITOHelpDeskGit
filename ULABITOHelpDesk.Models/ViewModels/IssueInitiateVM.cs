using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ULABITOHelpDesk.Models.ViewModels
{
    public class IssueInitiateVM
    {
        public IssueInitiate IssueInitiate { get; set; }
        public IEnumerable<SelectListItem> ProgrmaList { get; set; }
        public IEnumerable<SelectListItem> IssueSubtypeList { get; set; }

    }
}
