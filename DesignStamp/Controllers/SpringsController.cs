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
    public class SpringsController : Controller
    {
      
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public SpringsController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

       

        // GET: Springs
        public IActionResult ChooseSpring(int diametr, int oldId, string url)
        {
            var listColumn = _dataManager.Springs.GetSpringsByDiametr(diametr);

            var groupColumn = _dataManager.Springs.GetAllSpring().GroupBy(d => d.Diametr);
            List<DropVIew> springDrops = new List<DropVIew>();

            foreach (var item in groupColumn)
            {
                springDrops.Add(new DropVIew { Diametr = item.Key, OldId = oldId, Url = url });
            }




            ViewData["Drops"] = springDrops;
            ViewData["Current"] = diametr;
            return View(listColumn);
        }

        // GET: Springs/DetailsView/5
        public IActionResult DetailsView(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }

            var stamp = _dataManager.Stamps.GetStampBySpringId(id);
            var stampView = _servicesManager.Stamps.GetViewStampByName(stamp.Name);
            var spring = _servicesManager.Springs.GetSpringViewById(id, stampView.AllForce.Qremoval);

           
            ViewData["Name"] = stamp.Name;
            if (spring == null)
            {
                return NotFound();
            }

            return View(spring);
        }

        public IActionResult Index()
        {
            return View(_dataManager.Springs.GetAllSpring());
        }


        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var spring = _dataManager.Springs.GetSpringById(id);
            if (spring == null)
            {
                return NotFound();
            }

            return View(spring);
        }


        // GET: Springs/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Pspring,Diametr,Tmin,Tmax,Stroke,LengthScrew")] Spring spring)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Springs.SaveSpring(spring);
                return RedirectToAction(nameof(Index));
            }
            return View(spring);
        }

        // GET: Springs/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var spring = _dataManager.Springs.GetSpringById(id);
            if (spring == null)
            {
                return NotFound();
            }
            return View(spring);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Pspring,Diametr,Tmin,Tmax,Stroke,LengthScrew")] Spring spring)
        {
            if (id != spring.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.Springs.SaveSpring(spring);
                return RedirectToAction(nameof(Index));
            }
            return View(spring);
        }

        // GET: Springs/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var spring = _dataManager.Springs.GetSpringById(id);
            if (spring == null)
            {
                return NotFound();
            }

            return View(spring);
        }

        // POST: Springs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var spring = _dataManager.Springs.GetSpringById(id);
            _dataManager.Springs.DeleteSpring(spring);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
