using BuissnesLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Controllers
{
    [Authorize]
    public class MatricesController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public MatricesController(DataManager dataManager)
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

            var matrix = _servicesManager.Matrices.GetMatrixViewByStampName(stampName);
                
            if (matrix == null)
            {
                return NotFound();
            }

            return View(matrix);
        }


        public IActionResult Edit(string stampName, string returnUrl )
        {
            ViewData["Url"] = returnUrl;
            if (stampName == null)
            {
                return NotFound();
            }

            var matrix = _dataManager.Matrices.GetMatrixByStampName(stampName);
            if (matrix == null)
            {
                return NotFound();
            }
            
            return View(matrix);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(string name, [Bind("Name,Length,Width,Hieght,StampName")] Matrix matrix)
        {
            if (name != matrix.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _dataManager.Matrices.SaveMatrix(matrix);

            }
            else
            {
                return RedirectToAction(nameof(Details));
            }



            return RedirectToAction(nameof(Details),new { @stampName=matrix.StampName });
        }
    }
}
