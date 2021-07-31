using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;
using ULABITOHelpDesk.Models.ViewModels;
using ULABITOHelpDesk.Utility;

namespace ULABITOHelpDesk.AppOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_SuperAdmin)]
    public class IssueInitiateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public IssueInitiateController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            IssueInitiateVM issueInitiateVM = new IssueInitiateVM()
            {
                IssueInitiate = new IssueInitiate(),
                ProgrmaList = _unitOfWork.Program.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                IssueSubtypeList = _unitOfWork.IssueSubtype.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(issueInitiateVM);
            }
            //this is for edit
            issueInitiateVM.IssueInitiate = _unitOfWork.IssueInitiate.Get(id.GetValueOrDefault());
            if (issueInitiateVM.IssueInitiate == null)
            {
                return NotFound();
            }
            return View(issueInitiateVM);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(IssueInitiateVM issueInitiateVM)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        string webRootPath = _hostEnvironment.WebRootPath;
        //        var files = HttpContext.Request.Form.Files;
        //        if (files.Count > 0)
        //        {
        //            string fileName = Guid.NewGuid().ToString();
        //            var uploads = Path.Combine(webRootPath, @"images\issues");
        //            var extenstion = Path.GetExtension(files[0].FileName);

        //            if (issueInitiateVM.IssueInitiate.ImagePath != null)
        //            {
        //                //this is an edit and we need to remove old image
        //                var imagePath = Path.Combine(webRootPath, issueInitiateVM.IssueInitiate.ImagePath.TrimStart('\\'));
        //                if (System.IO.File.Exists(imagePath))
        //                {
        //                    System.IO.File.Delete(imagePath);
        //                }
        //            }
        //            using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
        //            {
        //                files[0].CopyTo(filesStreams);
        //            }
        //            issueInitiateVM.IssueInitiate.ImagePath = @"\images\issues\" + fileName + extenstion;
        //        }
        //        else
        //        {
        //            //update when they do not change the image
        //            if (issueInitiateVM.IssueInitiate.Id != 0)
        //            {
        //                IssueInitiate objFromDb = _unitOfWork.IssueInitiate.Get(issueInitiateVM.IssueInitiate.Id);
        //                issueInitiateVM.IssueInitiate.ImagePath = objFromDb.ImagePath;
        //            }
        //        }

        //        if (issueInitiateVM.IssueInitiate.Id == 0)
        //        {
        //            issueInitiateVM.IssueInitiate.QueryId = Guid.NewGuid();
        //            //issueInitiateVM.IssueInitiate.IsActive = true;
        //            issueInitiateVM.IssueInitiate.CreatedDate = DateTime.Now;
        //            issueInitiateVM.IssueInitiate.CreatedBy = "423036";
        //            issueInitiateVM.IssueInitiate.CreatedIp = "172.16.25.30";
        //            issueInitiateVM.IssueInitiate.UpdatedDate = DateTime.Now;
        //            issueInitiateVM.IssueInitiate.UpdatedBy = "423036";
        //            issueInitiateVM.IssueInitiate.UpdatedIp = "172.16.25.30";
        //            issueInitiateVM.IssueInitiate.IsDeleted = false;
        //            _unitOfWork.IssueInitiate.Add(issueInitiateVM.IssueInitiate);

        //        }
        //        else
        //        {
        //            issueInitiateVM.IssueInitiate.UpdatedDate = DateTime.Now;
        //            //issueInitiate.UpdatedBy = User.Identity.Name;
        //            //issueInitiate.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
        //            issueInitiateVM.IssueInitiate.UpdatedBy = "423036";
        //            issueInitiateVM.IssueInitiate.UpdatedIp = "172.16.25.30";
        //            issueInitiateVM.IssueInitiate.IsDeleted = false;
        //            _unitOfWork.IssueInitiate.Update(issueInitiateVM.IssueInitiate);
        //        }
        //        _unitOfWork.Save();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    issueInitiateVM.ProgrmaList = _unitOfWork.Program.GetAll().Select(i => new SelectListItem
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    });
        //    issueInitiateVM.IssueSubtypeList = _unitOfWork.IssueSubtype.GetAll().Select(i => new SelectListItem
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    });
        //    return View(issueInitiateVM);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(IssueInitiateVM issueInitiateVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\issues");
                    var extenstion = Path.GetExtension(files[0].FileName);

                    if (issueInitiateVM.IssueInitiate.ImagePath != null)
                    {
                        //this is an edit and we need to remove old image
                        var imagePath = Path.Combine(webRootPath, issueInitiateVM.IssueInitiate.ImagePath.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    issueInitiateVM.IssueInitiate.ImagePath = @"\images\issues\" + fileName + extenstion;
                }
                else
                {
                    //update when they do not change the image
                    if (issueInitiateVM.IssueInitiate.Id != 0)
                    {
                        IssueInitiate objFromDb = _unitOfWork.IssueInitiate.Get(issueInitiateVM.IssueInitiate.Id);
                        issueInitiateVM.IssueInitiate.ImagePath = objFromDb.ImagePath;
                    }
                }


                if (issueInitiateVM.IssueInitiate.Id == 0)
                {
                    issueInitiateVM.IssueInitiate.QueryId = Guid.NewGuid();
                    //issueInitiateVM.IssueInitiate.IsActive = true;
                    issueInitiateVM.IssueInitiate.CreatedDate = DateTime.Now;
                    issueInitiateVM.IssueInitiate.CreatedBy = User.Identity.Name;
                    issueInitiateVM.IssueInitiate.CreatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    issueInitiateVM.IssueInitiate.UpdatedDate = DateTime.MinValue;
                    issueInitiateVM.IssueInitiate.UpdatedBy = "N/A";
                    issueInitiateVM.IssueInitiate.UpdatedIp = "0.0.0.0";
                    issueInitiateVM.IssueInitiate.IsDeleted = false;
                    _unitOfWork.IssueInitiate.Add(issueInitiateVM.IssueInitiate);

                }
                else
                {
                    issueInitiateVM.IssueInitiate.UpdatedDate = DateTime.Now;
                    //issueInitiate.UpdatedBy = User.Identity.Name;
                    //issueInitiate.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    issueInitiateVM.IssueInitiate.UpdatedBy = User.Identity.Name;
                    issueInitiateVM.IssueInitiate.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                    issueInitiateVM.IssueInitiate.IsDeleted = false;
                    _unitOfWork.IssueInitiate.Update(issueInitiateVM.IssueInitiate);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                issueInitiateVM.ProgrmaList = _unitOfWork.Program.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                issueInitiateVM.IssueSubtypeList = _unitOfWork.IssueSubtype.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                if (issueInitiateVM.IssueInitiate.Id != 0)
                {
                    issueInitiateVM.IssueInitiate = _unitOfWork.IssueInitiate.Get(issueInitiateVM.IssueInitiate.Id);
                }
            }
            return View(issueInitiateVM);
        }


        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.IssueInitiate.GetAll(includeProperties: "ProgramData,IssueSubtype");
            return Json(new { data = allObj });
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.IssueInitiate.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImagePath.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _unitOfWork.IssueInitiate.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
