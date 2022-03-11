using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFBushingsRepository : IBushingsRepository
    {

        ApplicationDbContext _context;
        public EFBushingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteBushing(Bushing bushing)
        {
            _context.Bushings.Remove(bushing);
            _context.SaveChanges();
        }

        public List<Bushing> GetAllBushing()
        {
            return _context.Bushings.ToList();
        }

        public Bushing GetBushingById(int Id)
        {
            return _context.Bushings.Find(Id);
        }

        public List<Bushing> GetBushingsByDiametr(int diametr)
        {
            if (diametr != 0)
                return _context.Bushings.Where(d => d.ColumnDiametr == diametr).ToList();
            else
                return _context.Bushings.ToList();
        }

        public void SaveBushing(Bushing bushing)
        {
            if (bushing.Id == 0)

                _context.Bushings.Add(bushing);
            else
            {
                Bushing bushing1 = _context.Bushings.Find(bushing.Id);
                _context.Entry(bushing1).CurrentValues.SetValues(bushing);


            }
            _context.SaveChanges();
        }
    }
}
