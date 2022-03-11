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
    public class ColumnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        readonly private DataManager _dataManager;
        readonly private ServicesManager _servicesManager;

        public ColumnsController(DataManager dataManager)
        {

            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

      
        // GET: Columns
        public IActionResult ChooseColumn(int diametr, int oldId, string url)
        {
            var listColumn = _dataManager.Columns.GetColumnsByDiametr(diametr);

            var groupColumn = _dataManager.Columns.GetAllColumn().GroupBy(d => d.Diametr);
            List<DropVIew> columnDrops = new List<DropVIew>();

            foreach (var item in groupColumn)
            {
                columnDrops.Add(new DropVIew { Diametr = item.Key, OldId = oldId, Url=url });
            }
                    

            ViewData["Drops"] = columnDrops;
            ViewData["Current"] = diametr;
            return View(listColumn);
        }

        // GET: Columns/DetailsView/5
        public IActionResult DetailsView(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var column = _servicesManager.Columns.GetColumnViewById(id);
            
            var stamp = _dataManager.Stamps.GetStampByColumnId(id);
            ViewData["Name"] = stamp.Name;
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        public IActionResult Index()
        {
           
            return View(_dataManager.Columns.GetAllColumn());
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var column = _dataManager.Columns.GetColumnById(id);
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        // GET: Columns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Columns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Diametr,Height,HeightDepth")] Column column)
        {
            if (ModelState.IsValid)
            {
               
                _dataManager.Columns.SaveColumn(column);
                return RedirectToAction(nameof(Index));
            }
            return View(column);
        }

        // GET: Columns/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var column = _dataManager.Columns.GetColumnById(id);
            if (column == null)
            {
                return NotFound();
            }
            return View(column);
        }

        // POST: Columns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Diametr,Height,HeightDepth")] Column column)
        {
            if (id != column.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataManager.Columns.SaveColumn(column);
                return RedirectToAction(nameof(Index));
            }
            return View(column);
        }

        // GET: Columns/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var column = _dataManager.Columns.GetColumnById(id);
            if (column == null)
            {
                return NotFound();
            }

            return View(column);
        }

        // POST: Columns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var column = _dataManager.Columns.GetColumnById(id);
            _dataManager.Columns.DeleteColumn(column);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
