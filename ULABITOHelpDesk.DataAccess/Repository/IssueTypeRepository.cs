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
    public class IssueTypeRepository : Repository<IssueType>, IIssueTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public IssueTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(IssueType issueType)
        {
            //var objFromDb = _db.IssueTypes.FirstOrDefault(s => s.Id == issueType.Id);
            //if (objFromDb != null)
            //{
            //    objFromDb.Name = issueType.Name;
            //    _db.SaveChanges();
            //}
            _db.Update(issueType);
        }
    }
}
