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
using Microsoft.AspNetCore.Authorization;

namespace DesignStamp.Controllers
{
    [Authorize]
    public class HoldersController : Controller
    {
       readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public HoldersController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }


        public IActionResult Details(string stampName)
        {
            if (stampName == null)
            {
                return NotFound();
            }

            var holder = _servicesManager.Holders.GetHolderViewByStampName(stampName);

            if (holder == null)
            {
                return NotFound();
            }

            return View(holder);
        }


        public IActionResult Edit(string stampName, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            if (stampName == null)
            {
                return NotFound();
            }

            var holder = _dataManager.Holders.GetHolderByStampName(stampName);
            if (holder == null)
            {
                return NotFound();
            }
            
            return View(holder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string name, [Bind("Name,Length,Width,TotalHieght,BodyHieght,StampName,")] Holder holder)
        {
            if (name != holder.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _dataManager.Holders.SaveHolder(holder);

            }
            else
            {
                return RedirectToAction(nameof(Details), new { @stampName = holder.StampName });
            }



            return RedirectToAction(nameof(Details), new { @stampName = holder.StampName });
        }
    }
}
