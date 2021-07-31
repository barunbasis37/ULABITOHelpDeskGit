using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABITOHelpDesk.DataAccess.Data;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;

namespace ULABITOHelpDesk.DataAccess.Repository
{
    public class IssueInitiateRepository : Repository<IssueInitiate>, IIssueInitiateRepository
    {
        private readonly ApplicationDbContext _db;
        public IssueInitiateRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(IssueInitiate issueInitiate)
        {
            var objFromDb = _db.IssueInitiates.FirstOrDefault(s => s.Id == issueInitiate.Id);
            if (objFromDb != null)
            {
                if (issueInitiate.ImagePath != null)
                {
                    objFromDb.ImagePath = issueInitiate.ImagePath;
                }
                objFromDb.Description = issueInitiate.Description;
                objFromDb.IssueSubTypeId = issueInitiate.IssueSubTypeId;
                //objFromDb.ProgramId = issueInitiate.ProgramId;
                objFromDb.IsCompleted = issueInitiate.IsCompleted;
                objFromDb.IsDeleted = issueInitiate.IsDeleted;

            }
            //_db.Update(issueInitiate);

        }
    }
}
