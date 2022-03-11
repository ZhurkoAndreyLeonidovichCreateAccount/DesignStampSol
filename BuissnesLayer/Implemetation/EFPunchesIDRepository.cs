using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
  public  class EFPunchesIDRepository : IPunchesIDRepository
    {
        ApplicationDbContext _context;
        public EFPunchesIDRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteTopPlate(PunchesID punches)
        {
            throw new NotImplementedException();
        }

        public PunchesID GetPunchIDById(int id)
        {
           return _context.PunchesID.Where(c => c.PunchID == id).FirstOrDefault();
        }

        public void SavePunchesID(PunchesID punches)
        {

            if (_context.PunchesID.Find(punches.ID) == null)

                _context.PunchesID.Add(punches);
            else
            {
                PunchesID punches1 = _context.PunchesID.Find(punches.ID);
                _context.Entry(punches1).CurrentValues.SetValues(punches);
               
            }
            _context.SaveChanges();
        }
    }

}
