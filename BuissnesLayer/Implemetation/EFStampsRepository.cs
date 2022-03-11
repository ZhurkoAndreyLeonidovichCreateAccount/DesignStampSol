using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFStampsRepository : IStampsRepository
    {
        ApplicationDbContext _context;
        public EFStampsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       

        public List<Stamp> GetAllStamp()
        {
            return _context.Stamps.Include(c=>c.press).ToList();
        }

        public Stamp GetStampByBushingId(int id)
        {
            return _context.Stamps.Where(b => b.BushingId == id).FirstOrDefault();
        }

        public Stamp GetStampByColumnId(int id)
        {
           return _context.Stamps.Where(s => s.ColumnId == id).FirstOrDefault();
        }

        public Stamp GetStampByCoverId(int id)
        {
            return _context.Stamps.Where(c => c.CoverId == id).FirstOrDefault();
        }
        public Stamp GetStampBySpringId(int id)
        {
            return _context.Stamps.Where(c => c.SpringId == id).FirstOrDefault();
        }

        public Stamp GetStampByPunchId(int id)
        {
           var punch= _context.PunchesID.Where(c => c.PunchID == id).FirstOrDefault();
            return _context.Stamps.Find(punch.StampName);
        }

        public Stamp GetStampByEnlargedPunchId(int id)
        {
            var enlargedPunch = _context.EnlargedPunchesID.Where(c => c.EnlargedPunchID == id).FirstOrDefault();
            return _context.Stamps.Find(enlargedPunch.StampName);
        }

        public Stamp GetStampByPressId(int id)
        {
            return _context.Stamps.Where(c => c.PressId == id).FirstOrDefault();
        }

        public Stamp GetStampByName(string name, bool includes=false)
        {
            Stamp stamp;
            if (includes)
            {
                stamp = _context.Stamps
               .Include(s => s.bushing)
               .Include(s => s.column)
               .Include(s => s.detail).Include(s=>s.detail.differHoles)
               .Include(s => s.spring)
               .Include(s => s.EnlargedPunchesId)
               .Include(s => s.PunchesId)
               .Include(s => s.cover)
               .Include(s=>s.press)
               .FirstOrDefault(m => m.Name == name);
            }

            else
              stamp=  _context.Stamps.Find(name);

            return stamp;
        }

        

        public void SaveStamp(Stamp stamp)
        {
            if (_context.Stamps.Find(stamp.Name) == null)

                _context.Stamps.Add(stamp);
            else
            {
                Stamp stamp1 = _context.Stamps.Find(stamp.Name);
                _context.Entry(stamp1).CurrentValues.SetValues(stamp);
              
            }
            _context.SaveChanges();
        }

        public void DeleteStamp(string stampName)
        {
            
            var matrix=_context.Matrices.Where(m => m.StampName == stampName).FirstOrDefault();
            _context.Matrices.Remove(matrix);

            var punchMatrix = _context.PunchMatrices.Where(p => p.StampName == stampName).FirstOrDefault();
            _context.PunchMatrices.Remove(punchMatrix);

            var holder = _context.Holders.Where(h => h.StampName == stampName).FirstOrDefault();
            _context.Holders.Remove(holder);

            var puller=_context.Pullers.Where(h => h.StampName == stampName).FirstOrDefault();
            _context.Pullers.Remove(puller);

            var bottomPlate = _context.BottomPlates.Where(h => h.StampName == stampName).FirstOrDefault();
            _context.BottomPlates.Remove(bottomPlate);
            var topPlate=_context.TopPlates.Where(h => h.StampName == stampName).FirstOrDefault();
            _context.TopPlates.Remove(topPlate);
            var allForce=_context.AllForces.Where(h => h.StampName == stampName).FirstOrDefault();
            _context.AllForces.Remove(allForce);

            var punchesID = _context.PunchesID.Where(p => p.StampName == stampName).ToList();

            foreach (var item in punchesID)
            {
                _context.PunchesID.Remove(item);
            }

            var enlargedPunchesID = _context.EnlargedPunchesID.Where(p => p.StampName == stampName).ToList();

            foreach (var item in enlargedPunchesID)
            {
                _context.EnlargedPunchesID.Remove(item);
            }

            var stamp = _context.Stamps.Find(stampName);
            _context.Stamps.Remove(stamp);
            _context.SaveChanges();

        }

        public Stamp GetStampByDetailName(string name)
        {
          return  _context.Stamps.Where(s => s.detailName == name).FirstOrDefault();
        }
    }
}
