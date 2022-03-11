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
    public class BushingsController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public BushingsController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        // GET: Bushings
        public IActionResult ChooseBushing(int diametr, int oldId, string url)
        {
            var listBushing = _dataManager.Bushings.GetBushingsByDiametr(diametr);

            var groupBushing = _dataManager.Bushings.GetAllBushing().GroupBy(d => d.ColumnDiametr);
            List<DropVIew> bushingDrops = new List<DropVIew>();

            foreach (var item in groupBushing)
            {
                bushingDrops.Add(new DropVIew { Diametr = item.Key, OldId = oldId, Url = url });
            }


            ViewData["Drops"] = bushingDrops;
            ViewData["Current"] = diametr;
            return View(listBushing);
        }

        public IActionResult DetailsView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bushing = _servicesManager.Bushings.GetBushingViewById(id);

            var stamp = _dataManager.Stamps.GetStampByBushingId(id);
            ViewData["Name"] = stamp.Name;
            if (bushing == null)
            {
                return NotFound();
            }

            return View(bushing);
        }

        public IActionResult Index()
        {
            return View(_dataManager.Bushings.GetAllBushing());
        }

        // GET: Bushings/DetailsView/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bushing = _dataManager.Bushings.GetBushingById(id);
            if (bushing == null)
            {
                return NotFound();
            }

            return View(bushing);
        }

        // GET: Bushings/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,PressedDiametr,FlangeDiametr,ColumnDiametr,TotalHeight,DepthHeight")] Bushing bushing)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Bushings.SaveBushing(bushing);
                return RedirectToAction(nameof(Index));
            }
            return View(bushing);
        }

        // GET: Bushings/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bushing = _dataManager.Bushings.GetBushingById(id);
            if (bushing == null)
            {
                return NotFound();
            }
            return View(bushing);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PressedDiametr,FlangeDiametr,ColumnDiametr,TotalHeight,DepthHeight")] Bushing bushing)
        {
            if (id != bushing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.Bushings.SaveBushing(bushing);
                return RedirectToAction(nameof(Index));
            }
            return View(bushing);
        }

        // GET: Bushings/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var bushing = _dataManager.Bushings.GetBushingById(id);
            if (bushing == null)
            {
                return NotFound();
            }

            return View(bushing);
        }

        // POST: Bushings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bushing = _dataManager.Bushings.GetBushingById(id);
            _dataManager.Bushings.DeleteBushing(bushing);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
