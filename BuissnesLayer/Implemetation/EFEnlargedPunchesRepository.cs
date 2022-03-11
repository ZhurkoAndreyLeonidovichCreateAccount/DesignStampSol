using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFEnlargedPunchesRepository : IEnlargedPunchesRepository
    {
        ApplicationDbContext _context;

        public EFEnlargedPunchesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteEnlargedPunch(EnlargedPunch enlargedPunch)
        {
            _context.EnlargedPunches.Remove(enlargedPunch);
            _context.SaveChanges();
        }

        public List<EnlargedPunch> GetAllEnlargedPunch()
        {
            return _context.EnlargedPunches.ToList();
        }

        public EnlargedPunch GetEnlargedPunchById(int Id)
        {
            return _context.EnlargedPunches.Find(Id);
        }

        public List<EnlargedPunch> GetPunchesByDiametr(int diametr)
        {
            if (diametr != 0)
                return _context.EnlargedPunches.Where(d => d.DiametrHoleFirst == diametr).ToList();
            else
                return _context.EnlargedPunches.ToList();
        }

        public void SaveEnlargedPunch(EnlargedPunch enlargedPunch)
        {
            if (enlargedPunch.Id == 0)

                _context.EnlargedPunches.Add(enlargedPunch);
            else
            {
                EnlargedPunch enlargedPunch1 = _context.EnlargedPunches.Find(enlargedPunch.Id);
                _context.Entry(enlargedPunch1).CurrentValues.SetValues(enlargedPunch);


            }
            _context.SaveChanges();
        }
    }
}
