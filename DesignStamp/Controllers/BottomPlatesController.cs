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
    public class BottomPlatesController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public BottomPlatesController(DataManager dataManager)
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

            var bottomPlate = _servicesManager.BottomPlates.GetBottomPlateViewByStampName(stampName);

            if (bottomPlate == null)
            {
                return NotFound();
            }

            return View(bottomPlate);
        }

        public IActionResult Edit(string stampName, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            if (stampName == null)
            {
                return NotFound();
            }

            var bottomPlate = _dataManager.BottomPlates.GetBottomPlateByStampName(stampName);
            if (bottomPlate == null)
            {
                return NotFound();
            }

            return View(bottomPlate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string name, [Bind("Name,Length,Width,Hieght,StampName")] BottomPlate bottomPlate)
        {

            if (name != bottomPlate.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _dataManager.BottomPlates.SaveBottomPlate(bottomPlate);

            }
            else
            {
                return RedirectToAction(nameof(Details), new { @stampName = bottomPlate.StampName });
            }



            return RedirectToAction(nameof(Details), new { @stampName = bottomPlate.StampName });
        }

      
    }
}
