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
    public class EnlargedPunchesController : Controller
    {
      
        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public EnlargedPunchesController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }
        // GET: EnlargedPunches
        public IActionResult ChooseEnlargedPunch(int diametr, int oldId, string url)
        {
            var listEnlargedPunches = _dataManager.EnlargedPunches.GetPunchesByDiametr(diametr);

            var groupEnlargedPunches = _dataManager.EnlargedPunches.GetAllEnlargedPunch().GroupBy(d => d.DiametrHoleFirst);
            List<DropVIew> enlargedPunchesDrops = new List<DropVIew>();

            foreach (var item in groupEnlargedPunches)
            {
                enlargedPunchesDrops.Add(new DropVIew { Diametr = item.Key, OldId = oldId, Url = url });
            }


            ViewData["Drops"] = enlargedPunchesDrops;
            ViewData["Current"] = diametr;
            return View(listEnlargedPunches);



        }

        // GET: EnlargedPunches/DetailsView/5
        public  IActionResult DetailsView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var stamp = _dataManager.Stamps.GetStampByEnlargedPunchId(id);
            var detail = _dataManager.Details.GetDetailByName(stamp.detailName, true);
            var punch = _servicesManager.EnlargedPunches.GetEnlargedPunchViewById(id, detail.differHoles);


            ViewData["Name"] = stamp.Name;
            if (punch == null)
            {
                return NotFound();
            }

            return View(punch);
        }

        public IActionResult Index()
        {
            return View(_dataManager.EnlargedPunches.GetAllEnlargedPunch().OrderBy(c=>c.DiametrHoleFirst));
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var enlargedPunch = _dataManager.EnlargedPunches.GetEnlargedPunchById(id);
            if (enlargedPunch == null)
            {
                return NotFound();
            }

            return View(enlargedPunch);
        }


        // GET: EnlargedPunches/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,DiametrHoleFirst,DiametrHoleLast,DiametrSeat,DiametrFlange,HeightTottal,HeighSeat,HeighFlange")] EnlargedPunch enlargedPunch)
        {
            if (ModelState.IsValid)
            {
                _dataManager.EnlargedPunches.SaveEnlargedPunch(enlargedPunch);
                return RedirectToAction(nameof(Index));
            }
            return View(enlargedPunch);
        }

        // GET: EnlargedPunches/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var enlargedPunch = _dataManager.EnlargedPunches.GetEnlargedPunchById(id);
            if (enlargedPunch == null)
            {
                return NotFound();
            }
            return View(enlargedPunch);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,Name,DiametrHoleFirst,DiametrHoleLast,DiametrSeat,DiametrFlange,HeightTottal,HeighSeat,HeighFlange")] EnlargedPunch enlargedPunch)
        {
            if (id != enlargedPunch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.EnlargedPunches.SaveEnlargedPunch(enlargedPunch);
                return RedirectToAction(nameof(Index));
            }
            return View(enlargedPunch);
        }

        // GET: EnlargedPunches/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var enlargedPunch = _dataManager.EnlargedPunches.GetEnlargedPunchById(id);
           
            if (enlargedPunch == null)
            {
                return NotFound();
            }

            return View(enlargedPunch);
        }

        // POST: EnlargedPunches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var enlargedPunch = _dataManager.EnlargedPunches.GetEnlargedPunchById(id);
            _dataManager.EnlargedPunches.DeleteEnlargedPunch(enlargedPunch);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
