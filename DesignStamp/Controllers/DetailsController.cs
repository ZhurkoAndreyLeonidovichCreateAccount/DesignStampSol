using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Entities;
using BuissnesLayer;
using DesignStamp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DesignStamp.Controllers
{
    [Authorize]
    public class DetailsController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public DetailsController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        // GET: DetailsView
        public IActionResult GetAllDetails(string name)
        {
            List<Detail> details = _dataManager.Details.GetAllDetail();
            if (details.Count() == 0)
                ViewData["Flag"] = 1;
            else
                ViewData["Flag"] = 0;


            List<DetailView> detailViews=new List<DetailView>();
            foreach (var item in details)
            {
                var stamp = _dataManager.Stamps.GetStampByDetailName(item.Name);
                string StampName = stamp?.Name ?? "Нету штампа";
                detailViews.Add(new DetailView { Name = item.Name, StampName = StampName });
            }

            if (name != null)
                detailViews= detailViews.Where(s => s.Name == name).ToList();


            return View(detailViews);
        }

        // GET: DetailsView/DetailsView/5
        public IActionResult Details(string name, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            if (name == null)
            {
                return NotFound();
            }

            var detail = _dataManager.Details.GetDetailByName(name,true);

            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }


        // POST: DetailsView/Delete/5
       
        public IActionResult Delete(string name, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            var detail = _dataManager.Details.GetDetailByName(name,true);
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string Name)
        {
            var stamp = _dataManager.Stamps.GetStampByDetailName(Name);
            if (stamp != null)
                _dataManager.Stamps.DeleteStamp(stamp.Name);
            var detail = _dataManager.Details.GetDetailByName(Name, true);
            _dataManager.Details.DeleteDetail(detail);
            //return RedirectToAction(nameof(GetAllDetails));

            return View();

        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckDetail (string Name)
        {
            var detail = _dataManager.Details.GetDetailByName(Name);
            if (detail == null)
                return Json(true);
            return Json(false);
        }
    }
}
