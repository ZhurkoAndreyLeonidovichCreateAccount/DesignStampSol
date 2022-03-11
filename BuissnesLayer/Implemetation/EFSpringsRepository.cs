using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFSpringsRepository : ISpringsRepository
    {

        ApplicationDbContext _context;
        public EFSpringsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteSpring(Spring spring)
        {
            _context.Springs.Remove(spring);
            _context.SaveChanges();
        }

        public List<Spring> GetAllSpring()
        {
            return _context.Springs.ToList();
        }

        public Spring GetSpringById(int Id)
        {
            return _context.Springs.Find(Id);
        }

        public List<Spring> GetSpringsByDiametr(int diametr)
        {
            if (diametr != 0)
                return _context.Springs.Where(d => d.Diametr == diametr).ToList();
            else
                return _context.Springs.ToList();
        }
    

        public void SaveSpring(Spring spring)
        {
            if (spring.Id == 0)

                _context.Springs.Add(spring);
            else
            {
                Spring spring1 = _context.Springs.Find(spring.Id);
                _context.Entry(spring1).CurrentValues.SetValues(spring);


            }
            _context.SaveChanges();
        }
    }
}
