using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFEnlargedPunchesIDRepository : IEnlargedPunchesIDRepository
    {
        ApplicationDbContext _context;
        public EFEnlargedPunchesIDRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteEnlargedPunches(EnlargedPunchesID punches)
        {
            throw new NotImplementedException();
        }

        public EnlargedPunchesID GetEnlargedPunchIDById(int id)
        {
            return _context.EnlargedPunchesID.Where(c => c.EnlargedPunchID == id).FirstOrDefault();
        }

        public void SaveEnlargedPunchesID(EnlargedPunchesID punches)
        {

            if (_context.EnlargedPunchesID.Find(punches.ID) == null)

                _context.EnlargedPunchesID.Add(punches);
            else
            {
                EnlargedPunchesID punches1 = _context.EnlargedPunchesID.Find(punches.ID);
                _context.Entry(punches1).CurrentValues.SetValues(punches);

            }
            _context.SaveChanges();
        }
    }
}
