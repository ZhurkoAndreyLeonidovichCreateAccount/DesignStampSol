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
    public class CoversController : Controller
    {
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public CoversController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        // GET: Covers
        public IActionResult ChooseCover(int diametr, int oldId, string url)
        {
            var listCover = _dataManager.Covers.GetCoversByDiametr(diametr);

            var groupCover = _dataManager.Covers.GetAllCover().GroupBy(d => d.Diametr);
            List<DropVIew> coverDrops = new List<DropVIew>();

            foreach (var item in groupCover)
            {
                coverDrops.Add(new DropVIew { Diametr = item.Key, OldId = oldId, Url = url });
            }


            ViewData["Drops"] = coverDrops;
            ViewData["Current"] = diametr;
            return View(listCover);
           
        }

        // GET: Covers/DetailsView/5
        public IActionResult DetailsView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cover = _servicesManager.Covers.GetCoverViewById(id);

            var stamp = _dataManager.Stamps.GetStampByCoverId(id);
            ViewData["Name"] = stamp.Name;
            if (cover == null)
            {
                return NotFound();
            }

            return View(cover);
        }

        public IActionResult Index()
        {
            return View(_dataManager.Covers.GetAllCover());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cover = _dataManager.Covers.GetCoverById(id);
            if (cover == null)
            {
                return NotFound();
            }

            return View(cover);
        }
        // GET: Covers/Create
        public IActionResult Create()
        {
            return View();
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,TotalHeight,PressHeight,Diametr")] Cover cover)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Covers.SaveCover(cover);
                return RedirectToAction(nameof(Index));
            }
            return View(cover);
        }

        // GET: Covers/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cover = _dataManager.Covers.GetCoverById(id);
            if (cover == null)
            {
                return NotFound();
            }
            return View(cover);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,TotalHeight,PressHeight,Diametr")] Cover cover)
        {
            if (id != cover.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.Covers.SaveCover(cover);
                return RedirectToAction(nameof(Index));
            }
            return View(cover);
        }

        // GET: Covers/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var cover = _dataManager.Covers.GetCoverById(id);
            if (cover == null)
            {
                return NotFound();
            }

            return View(cover);
        }

        // POST: Covers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cover = _dataManager.Covers.GetCoverById(id);
            _dataManager.Covers.DeleteCover(cover);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
