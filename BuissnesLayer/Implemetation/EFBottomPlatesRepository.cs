using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFBottomPlatesRepository : IBottomPlatesRepository
    {

        ApplicationDbContext _context;
        public EFBottomPlatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteBottomPlate(BottomPlate plate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BottomPlate> GetAllBottomPlate()
        {
            throw new NotImplementedException();
        }

        public BottomPlate GetBottomPlateByName(string Name)
        {
            throw new NotImplementedException();
        }

        public BottomPlate GetBottomPlateByStampName(string stampName)
        {
          return  _context.BottomPlates.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public void SaveBottomPlate(BottomPlate plate)
        {

            if (_context.BottomPlates.Find(plate.Name) == null)

                _context.BottomPlates.Add(plate);
            else
            {
                BottomPlate plate1 = _context.BottomPlates.Find(plate.Name);
                _context.Entry(plate1).CurrentValues.SetValues(plate);

              
            }
            _context.SaveChanges();
        }
    }
}
