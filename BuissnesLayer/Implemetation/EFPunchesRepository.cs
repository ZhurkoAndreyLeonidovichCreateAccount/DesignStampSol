using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFPunchesRepository : IPunchesRepository
    {

        ApplicationDbContext _context;
        public EFPunchesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeletePunch(Punch punch)
        {
            _context.Punches.Remove(punch);
            _context.SaveChanges();
        }

        public List<Punch> GetAllPunch()
        {
            return _context.Punches.ToList();
        }

        public Punch GetPunchById(int Id)
        {
           return _context.Punches.Find(Id);
        }

        public List<Punch> GetPunchesByDiametr(int diametr)
        {
            if (diametr != 0)
                return _context.Punches.Where(d => d.DiametrHole == diametr).ToList();
            else
                return _context.Punches.ToList();
        }

        public void SavePunch(Punch punch)
        {
           if(punch.Id==0)
            {
                _context.Punches.Add(punch);
            }
            else
            {
                Punch punch1 = _context.Punches.Find(punch.Id);
                _context.Entry(punch1).CurrentValues.SetValues(punch);
            }
            _context.SaveChanges();
        }
    }
}
