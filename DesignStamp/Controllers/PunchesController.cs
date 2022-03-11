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
    public class PunchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public PunchesController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }


        // GET: Punches/DetailsView/5
        public IActionResult ChoosePunch(int diametr, int oldId, string url)
        {
            var listCover = _dataManager.Punches.GetPunchesByDiametr(diametr);

            var groupCover = _dataManager.Punches.GetAllPunch().GroupBy(d => d.DiametrHole);
            List<DropVIew> coverDrops = new List<DropVIew>();

            foreach (var item in groupCover)
            {
                coverDrops.Add(new DropVIew { Diametr = item.Key, OldId = oldId, Url = url });
            }


            ViewData["Drops"] = coverDrops;
            ViewData["Current"] = diametr;
            return View(listCover.OrderBy(c => c.DiametrHole).OrderBy(c => c.HeightTottal));
         
        }

        public IActionResult DetailsView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var stamp = _dataManager.Stamps.GetStampByPunchId(id);
            var detail = _dataManager.Details.GetDetailByName(stamp.detailName, true);
            var punch = _servicesManager.Punches.GetPunchViewById(id, detail.differHoles);

           
            ViewData["Name"] = stamp.Name;
            if (punch == null)
            {
                return NotFound();
            }

            return View(punch);
        }
        public IActionResult Index()
        {
            return View(_dataManager.Punches.GetAllPunch().OrderBy(p=>p.DiametrHole));
        }
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var punch = _dataManager.Punches.GetPunchById(id);
            if (punch == null)
            {
                return NotFound();
            }

            return View(punch);
        }
        // GET: Punches/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Name,DiametrHole,DiametrSeat,DiametrFlange,HeightTottal,HeighSeat,HeighFlange,HeightHole")] Punch punch)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Punches.SavePunch(punch);
                return RedirectToAction(nameof(Index));
            }
            return View(punch);
        }

        // GET: Punches/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var punch = _dataManager.Punches.GetPunchById(id);
            if (punch == null)
            {
                return NotFound();
            }
            return View(punch);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,DiametrHole,DiametrSeat,DiametrFlange,HeightTottal,HeighSeat,HeighFlange,HeightHole")] Punch punch)
        {
            if (id != punch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.Punches.SavePunch(punch);
                return RedirectToAction(nameof(Index));
            }
            return View(punch);
        }

        // GET: Punches/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var punch = _dataManager.Punches.GetPunchById(id);
            if (punch == null)
            {
                return NotFound();
            }

            return View(punch);
        }

        // POST: Punches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var punch = _dataManager.Punches.GetPunchById(id);
            _dataManager.Punches.DeletePunch(punch);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
