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
    public class PunchMatricesController : Controller
    {
       readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public PunchMatricesController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        public  IActionResult Details(string stampName)
        {
            if (stampName == null)
            {
                return NotFound();
            }

            var punchMatrix = _servicesManager.PunchMatrices.GetPunchMatrixViewByStampName(stampName);

            if (punchMatrix == null)
            {
                return NotFound();
            }

            return View(punchMatrix);
        }


        public IActionResult Edit(string stampName, string returnUrl)
        {
            ViewData["Url"] = returnUrl;
            if (stampName == null)
            {
                return NotFound();
            }

            var punchMatrix = _dataManager.PunchMatrices.GetPunchMatrixByStampName(stampName);
            if (punchMatrix == null)
            {
                return NotFound();
            }
           
            return View(punchMatrix);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(string name, [Bind("Name,Length,Width,Hieght,FlangeHieght,FlangeWidth,StampName")] PunchMatrix punchMatrix)
        {
            if (name != punchMatrix.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _dataManager.PunchMatrices.SavePunchMatrix(punchMatrix);

            }
            else
            {
                return RedirectToAction(nameof(Details), new { @stampName = punchMatrix.StampName });
            }



            return RedirectToAction(nameof(Details), new { @stampName = punchMatrix.StampName });
        }

    }
}
