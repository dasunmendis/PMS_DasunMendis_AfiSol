using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMS_DAL;
using PMS_DAL.Repository;

namespace PMS_Web.Controllers
{
    [Authorize]
    public class DesignationsController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult ViewDesignations()
        {
            var designations = _unitOfWork.DesignationRepository.Get();
            return View(designations.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var designation = _unitOfWork.DesignationRepository.GetById(id);
            if (designation == null)
                return HttpNotFound();
            return View(designation);
        }

         [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SSID,Designation1,Basic,OT1,OT2,Intensive,CreatedBy,CreatedDate")] Designation designation)
        {
            try
            {
                designation.CreatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _unitOfWork.DesignationRepository.Insert(designation);
                    _unitOfWork.Save();
                    return RedirectToAction("ViewDesignations");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(designation);
        }

         [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var designation = _unitOfWork.DesignationRepository.GetById(id);
            if (designation == null)
                return HttpNotFound();
            return View(designation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SSID,Designation1,Basic,OT1,OT2,Intensive,CreatedBy,CreatedDate")] Designation designation)
        {
            try
            {
                designation.CreatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    _unitOfWork.DesignationRepository.Update(designation);
                    _unitOfWork.Save();
                    return RedirectToAction("ViewDesignations");
                }
            }
            catch (DataException )
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(designation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var designation = _unitOfWork.DesignationRepository.GetById(id);
            if (designation == null)
                return HttpNotFound();
            return View(designation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var designation = _unitOfWork.DesignationRepository.GetById(id);
            _unitOfWork.DesignationRepository.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("ViewDesignations");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
