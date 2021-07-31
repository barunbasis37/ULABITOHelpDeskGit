using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABITOHelpDesk.Models;

namespace ULABITOHelpDesk.DataAccess.Repository.IRepository
{
    public interface IProgramRepository : IRepository<ProgramData>
    {
        void Update(ProgramData program);
    }
}
