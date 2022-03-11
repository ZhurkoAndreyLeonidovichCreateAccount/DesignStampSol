using BuissnesLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Controllers
{
    [Authorize]
    public class StampsController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesManager;
        public StampsController(DataManager dataManager)
        {

            _datamanager = dataManager;
            _servicesManager = new ServicesManager(_datamanager);
        }

        public IActionResult GetAllStamps(string stampName=null)
        {
        //    if (details.Count() == 0)
        //        ViewData["Flag"] = 1;
        //    else
                
            List<Stamp> stamps;
            ViewData["Flag"] = 2;
            if (stampName == null)
            {
                stamps = _datamanager.Stamps.GetAllStamp();
                if(stamps.Count()==0)
                    ViewData["Flag"] = 0;
            }
                
            else
            {
                stamps = _datamanager.Stamps.GetAllStamp().Where(s => s.Name == stampName).ToList();
                if(stamps.Count() == 0)
                ViewData["Flag"] = 1;
            }
               

            return View(stamps);
        }

        public IActionResult GetStamp(string stampName, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            var stamp = _servicesManager.Stamps.GetViewStampByName(stampName);

            return View(stamp);
        }

        public IActionResult DeleteStamp(string stampName, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            if (stampName == null)
            {
                return NotFound();
            }

            var stamp=_datamanager.Stamps.GetStampByName(stampName,true);
            

            return View(stamp);
           

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string Name)
        {
            _datamanager.Stamps.DeleteStamp(Name);

            return View();

        }



        public IActionResult EditColumn(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampColumnToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampByColumnId(id).Name });
        }

        public IActionResult EditBushing(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampBushingToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampByBushingId(id).Name });
        }

        public IActionResult EditCover(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampCoverToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampByCoverId(id).Name });
        }

        public IActionResult EditPunch(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampPunchToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampByPunchId(id).Name });
        }

        public IActionResult EditSpring(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampSpringToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampBySpringId(id).Name });
        }

        public IActionResult EditEnlargedPunch(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampEnlargedPunchToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampByEnlargedPunchId(id).Name });
        }

        public IActionResult EditPress(int id, int oldId)
        {
            _servicesManager.Stamps.SaveStampPressToDb(id, oldId);
            return RedirectToAction(nameof(GetStamp), new { @stampName = _datamanager.Stamps.GetStampByPressId(id).Name });
        }


        public IActionResult GetAllForce(string stampName )
        {
            var force = _servicesManager.AllForces.GetAllForceViewByStampName(stampName);

            return View(force);
        }
        [AcceptVerbs("Get", "Post")]
    public IActionResult CheckStamp(string stampName)
        {
            var stamp = _datamanager.Stamps.GetStampByName(stampName);
            if (stamp == null)
                return Json(true);
            return Json(false);
        }
    }
}
