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
    public class IssueTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IssueTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            IssueTypeVM issueTypeVM = new IssueTypeVM()
            {
                IssueType = new IssueType(),
                UserTypeList = _unitOfWork.UserType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(issueTypeVM);
            }
            //this is for edit
            issueTypeVM.IssueType = _unitOfWork.IssueType.Get(id.GetValueOrDefault());
            if (issueTypeVM.IssueType == null)
            {
                return NotFound();
            }
            return View(issueTypeVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(IssueTypeVM issueTypeVM)
        {

            if (ModelState.IsValid)
            {
                if (issueTypeVM.IssueType.Id == 0)
                {
                    issueTypeVM.IssueType.QueryId = Guid.NewGuid();
                    issueTypeVM.IssueType.CreatedDate = DateTime.Now;
                    issueTypeVM.IssueType.CreatedBy = "423036";
                    issueTypeVM.IssueType.CreatedIp = "172.16.25.30";
                    issueTypeVM.IssueType.UpdatedDate = DateTime.Now;
                    issueTypeVM.IssueType.UpdatedBy = "423036";
                    issueTypeVM.IssueType.UpdatedIp = "172.16.25.30";
                    issueTypeVM.IssueType.IsDeleted = false;
                    _unitOfWork.IssueType.Add(issueTypeVM.IssueType);

                }
                else
                {
                    issueTypeVM.IssueType.UpdatedDate = DateTime.Now;
                    //department.UpdatedBy = User.Identity.Name;
                    //department.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    issueTypeVM.IssueType.UpdatedBy = "423036";
                    issueTypeVM.IssueType.UpdatedIp = "172.16.25.30";
                    issueTypeVM.IssueType.IsDeleted = false;
                    _unitOfWork.IssueType.Update(issueTypeVM.IssueType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            issueTypeVM.UserTypeList = _unitOfWork.UserType.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(issueTypeVM);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.IssueType.GetAll(includeProperties:"UserType");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.IssueType.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.IssueType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
