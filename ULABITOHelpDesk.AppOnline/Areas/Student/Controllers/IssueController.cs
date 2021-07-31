using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using ULABITOHelpDesk.DataAccess.Repository.IRepository;
using ULABITOHelpDesk.Models;
using ULABITOHelpDesk.Models.ViewModels;
using ULABITOHelpDesk.Utility;

namespace ULABITOHelpDesk.AppOnline.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = SD.Role_Student)]
    public class IssueController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<IssueController> _logger;

        public IssueController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, ILogger<IssueController> logger)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Viewed By: "+User.Identity.Name);
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
            _logger.LogInformation("Loaded By: " + User.Identity.Name);
            return View(issueInitiateVM);

        }
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
                    issueInitiateVM.IssueInitiate.UpdatedDate = DateTime.Now;
                    issueInitiateVM.IssueInitiate.UpdatedBy = "423036";
                    issueInitiateVM.IssueInitiate.UpdatedIp = "172.16.25.30";
                    issueInitiateVM.IssueInitiate.IsDeleted = false;
                    _unitOfWork.IssueInitiate.Add(issueInitiateVM.IssueInitiate);
                    _unitOfWork.Save();
                    _logger.LogInformation("Created By: " + User.Identity.Name);
                }
                //else
                //{
                //    issueInitiateVM.IssueInitiate.UpdatedDate = DateTime.Now;
                //    //issueInitiate.UpdatedBy = User.Identity.Name;
                //    //issueInitiate.UpdatedIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                //    issueInitiateVM.IssueInitiate.UpdatedBy = User.Identity.Name;
                //    issueInitiateVM.IssueInitiate.UpdatedIp = "172.16.25.30";
                //    issueInitiateVM.IssueInitiate.IsDeleted = false;
                //    _unitOfWork.IssueInitiate.Update(issueInitiateVM.IssueInitiate);
                //    _unitOfWork.Save();
                //    _logger.LogInformation("Edited By: " + User.Identity.Name);
                //}

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
            var claimsIdentity = User.Identity.Name;
            
            var allObj = _unitOfWork.IssueInitiate.GetAll(u => u.CreatedBy == claimsIdentity, includeProperties: "ProgramData,IssueSubtype");
            return Json(new { data = allObj });
        }


        #endregion
    }
}
