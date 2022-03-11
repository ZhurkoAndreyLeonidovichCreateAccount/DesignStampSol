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
    public class PullersController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public PullersController(DataManager dataManager)
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

            var holder = _servicesManager.Pullers.GetPullerViewByStampName(stampName);

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

            var puller = _dataManager.Pullers.GetPullerByStampName(stampName);
            if (puller == null)
            {
                return NotFound();
            }

            return View(puller);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(string name, [Bind("Name,Length,Width,Hieght,StampName")] Puller puller)
        {

            if (name != puller.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _dataManager.Pullers.SavePuller(puller);

            }
            else
            {
                return RedirectToAction(nameof(Details));
            }



            return RedirectToAction(nameof(Details), new { @stampName = puller.StampName });
        }

       
    }
}
