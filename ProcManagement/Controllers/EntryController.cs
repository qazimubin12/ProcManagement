using Microsoft.AspNet.Identity;
using ProcManagement.Entities;
using ProcManagement.Services;
using ProcManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcManagement.Controllers
{
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index(string SearchTerm = "")
        {
            EntryListingViewModel model = new EntryListingViewModel();
            model.SearchTerm  = SearchTerm;
            model.Entries = BaseServices.Instance.GetEntry().Where(x => x.UserID == User.Identity.GetUserId()).ToList();
            return View(model);
        }


        [HttpGet]
        public ActionResult Action(int ID = 0)
        {
            EntryActionViewModel model = new EntryActionViewModel();
            model.Hospitals = BaseServices.Instance.GetHospital().Where(x=>x.UserID == User.Identity.GetUserId()).Select(X=>X.Name).ToList();
            if (ID != 0)
            {
                
                var entry = BaseServices.Instance.GetEntryById(ID);
                model.ID = entry.ID;
                model.Age = entry.Age;
                model.Procedure = entry.Procedure;
                model.Name = entry.Name;
                model.Hospital = entry.Hospital;
                model.Date = entry.Date;
                model.Sex = entry.Sex;
            }
            return View(model);
            
        }

        [HttpPost]
        public ActionResult Action(EntryActionViewModel model)
        {
            if (model.ID != 0)
            {
                var hospital = BaseServices.Instance.GetHospital().Where(x => x.Name == model.Name && x.UserID == User.Identity.GetUserId()).FirstOrDefault();
                if(hospital == null)
                {
                    var Hospital = new Hospital();
                    Hospital.Name = model.Name;
                    Hospital.UserID = User.Identity.GetUserId();
                    BaseServices.Instance.CreateHospital(Hospital);

                }

                var entry = BaseServices.Instance.GetEntryById(model.ID);
                entry.Name = model.Name;
                entry.Age = model.Age;
                entry.Procedure = model.Procedure;
                entry.Hospital = model.Hospital;
                entry.UserID = User.Identity.GetUserId();
                entry.Date = model.Date;
                entry.Sex = model.Sex;
                BaseServices.Instance.UpdateEntry(entry);
            }
            else
            {
                var hospital = BaseServices.Instance.GetHospital().Where(x => x.Name == model.Name && x.UserID == User.Identity.GetUserId()).FirstOrDefault();
                if (hospital == null)
                {
                    var Hospital = new Hospital();
                    Hospital.Name = model.Name;
                    Hospital.UserID = User.Identity.GetUserId();
                    BaseServices.Instance.CreateHospital(Hospital);

                }

                var entry = new Entry();
                entry.Name = model.Name;
                entry.Age = model.Age;
                entry.UserID = User.Identity.GetUserId();
                entry.Procedure = model.Procedure;
                entry.Hospital = model.Hospital;
                entry.Date = model.Date;
                entry.Sex = model.Sex;
                BaseServices.Instance.CreateEntry(entry);

            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            EntryActionViewModel model = new EntryActionViewModel();
            var Product = BaseServices.Instance.GetEntryById(ID);
            model.ID = Product.ID;
            return PartialView("_Delete", model);
        }
        [HttpPost]
        public ActionResult Delete(EntryActionViewModel model)
        {
            if (model.ID != 0)
            {
                var Entry = BaseServices.Instance.GetEntryById(model.ID);
                BaseServices.Instance.DeleteEntry(Entry.ID);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

     

    }
}