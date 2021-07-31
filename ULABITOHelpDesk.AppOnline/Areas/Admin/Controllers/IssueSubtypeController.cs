using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;
using ULABITOHelpDesk.Models.ViewModels;
using ULABITOHelpDesk.Utility;

namespace ULABITOHelpDesk.AppOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_SuperAdmin)]
    public class IssueSubtypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IssueSubtypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            IssueSubtypeVM issueSubtypeVM = new IssueSubtypeVM()
            {
                IssueSubtype = new IssueSubtype(),
                IssueTypeList = _unitOfWork.IssueType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(issueSubtypeVM);
            }
            //this is for edit
            issueSubtypeVM.IssueSubtype = _unitOfWork.IssueSubtype.Get(id.GetValueOrDefault());
            if (issueSubtypeVM.IssueSubtype == null)
            {
                return NotFound();
            }
            return View(issueSubtypeVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(IssueSubtypeVM issueSubtypeVM)
        {

            if (ModelState.IsValid)
            {
                if (issueSubtypeVM.IssueSubtype.Id == 0)
                {
                    issueSubtypeVM.IssueSubtype.QueryId = Guid.NewGuid();
                    issueSubtypeVM.IssueSubtype.CreatedDate = DateTime.Now;
                    issueSubtypeVM.IssueSubtype.CreatedBy = "423036";
                    issueSubtypeVM.IssueSubtype.CreatedIp = "172.16.25.30";
                    issueSubtypeVM.IssueSubtype.UpdatedDate = DateTime.Now;
                    issueSubtypeVM.IssueSubtype.UpdatedBy = "423036";
                    issueSubtypeVM.IssueSubtype.UpdatedIp = "172.16.25.30";
                    issueSubtypeVM.IssueSubtype.IsDeleted = false;
                    _unitOfWork.IssueSubtype.Add(issueSubtypeVM.IssueSubtype);

                }
                else
                {
                    issueSubtypeVM.IssueSubtype.UpdatedDate = DateTime.Now;
                    //department.UpdatedBy = User.Identity.Name;
                    //department.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    issueSubtypeVM.IssueSubtype.UpdatedBy = "423036";
                    issueSubtypeVM.IssueSubtype.UpdatedIp = "172.16.25.30";
                    issueSubtypeVM.IssueSubtype.IsDeleted = false;
                    _unitOfWork.IssueSubtype.Update(issueSubtypeVM.IssueSubtype);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            issueSubtypeVM.IssueTypeList = _unitOfWork.UserType.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(issueSubtypeVM);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.IssueSubtype.GetAll(includeProperties:"IssueType");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.IssueSubtype.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.IssueSubtype.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
