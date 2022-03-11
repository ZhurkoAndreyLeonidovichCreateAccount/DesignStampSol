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
    public class TopPlatesController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public TopPlatesController(DataManager dataManager)
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

            var topPlate = _servicesManager.TopPlates.GetTopPlateViewByStampName(stampName);

            if (topPlate == null)
            {
                return NotFound();
            }

            return View(topPlate);
        }
        public IActionResult Edit(string stampName, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            if (stampName == null)
            {
                return NotFound();
            }

            var topPlate = _dataManager.TopPlates.GetTopPlateByStampName(stampName);
            if (topPlate == null)
            {
                return NotFound();
            }

            return View(topPlate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string name, [Bind("Name,TotalLength,СastLength,СastWidth,СastHeight,TotalWidth,Hieght,SfelfWidth,SfelfHeight,StampName")] TopPlate topPlate)
        {
            if (name != topPlate.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _dataManager.TopPlates.SaveTopPlate(topPlate);

            }
            else
            {
                return RedirectToAction(nameof(Details), new { @stampName = topPlate.StampName });
            }



            return RedirectToAction(nameof(Details), new { @stampName = topPlate.StampName });
        }


    }

      
    
}
