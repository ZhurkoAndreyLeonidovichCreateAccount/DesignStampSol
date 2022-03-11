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
    public class PressesController : Controller
    {

        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public PressesController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }



        public IActionResult ChoosePress(int oldId, string url)
        {


            var allPresses = _dataManager.Presses.GetAllPress();


            ViewData["OldID"] = oldId;

            return View(allPresses.OrderBy(p => p.Ppress));

        }

        // GET: Presses/DetailsView/5
        public IActionResult DetailsView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var stamp = _dataManager.Stamps.GetStampByPressId(id);
            var press = _servicesManager.Presses.GetPressViewById(id, stamp.Name);


            ViewData["Name"] = stamp.Name;
            if (press == null)
            {
                return NotFound();
            }

            return View(press);
        }

        // GET: Presses
        public IActionResult Index()
        {
            return View(_dataManager.Presses.GetAllPress());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var press = _dataManager.Presses.GetPressById(id);
            if (press == null)
            {
                return NotFound();
            }

            return View(press);
        }

        // GET: Presses/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Ppress,PressRamStroke,LengthAdapt,WidthAdapt")] Press press)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Presses.SavePress(press);
                return RedirectToAction(nameof(Index));
            }
            return View(press);
        }

        // GET: Presses/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var press = _dataManager.Presses.GetPressById(id);
            if (press == null)
            {
                return NotFound();
            }
            return View(press);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Ppress,PressRamStroke,LengthAdapt,WidthAdapt")] Press press)
        {
            if (id != press.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.Presses.SavePress(press);
                return RedirectToAction(nameof(Index));
            }
            return View(press);
        }

        // GET: Presses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var press = _dataManager.Presses.GetPressById(id);
            if (press == null)
            {
                return NotFound();
            }

            return View(press);
        }

        // POST: Presses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var press = _dataManager.Presses.GetPressById(id);
            _dataManager.Presses.DeletePress(press);
            return RedirectToAction(nameof(Index));
        }

    }   
}
