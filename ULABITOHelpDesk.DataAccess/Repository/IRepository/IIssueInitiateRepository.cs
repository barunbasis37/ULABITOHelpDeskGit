using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ULABITOHelpDesk.Models;

namespace ULABITOHelpDesk.DataAccess.Repository.IRepository
{
    public interface IIssueInitiateRepository : IRepository<IssueInitiate>
    {
        void Update(IssueInitiate issueInitiate);
    }
}
