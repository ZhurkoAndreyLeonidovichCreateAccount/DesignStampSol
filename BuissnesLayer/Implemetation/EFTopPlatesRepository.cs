using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFTopPlatesRepository : ITopPlatesRepository
    {

        ApplicationDbContext _context;
        public EFTopPlatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteTopPlate(TopPlate plate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TopPlate> GetAllTopPlate()
        {
            throw new NotImplementedException();
        }

        public TopPlate GetTopPlateByName(string Name)
        {
            throw new NotImplementedException();
        }

        public TopPlate GetTopPlateByStampName(string stampName)
        {
           return _context.TopPlates.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public void SaveTopPlate(TopPlate plate)
        {

            if (_context.TopPlates.Find(plate.Name) == null)

                _context.TopPlates.Add(plate);
            else
            {
                TopPlate plate1 = _context.TopPlates.Find(plate.Name);
                _context.Entry(plate1).CurrentValues.SetValues(plate);


            }
            _context.SaveChanges();
        }
    }
}
