using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFPullersRepository : IPullersRepository
    {
        ApplicationDbContext _context;
        public EFPullersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeletePuller(Puller holder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Puller> GetAllPuller()
        {
            throw new NotImplementedException();
        }

        public Puller GetPullerByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Puller GetPullerByStampName(string stampName)
        {
            return _context.Pullers.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public void SavePuller(Puller holder)
        {
            if (_context.Pullers.Find(holder.Name) == null)

                _context.Pullers.Add(holder);
            else
            {
                Puller puller1 = _context.Pullers.Find(holder.Name);
                _context.Entry(puller1).CurrentValues.SetValues(holder);

               

            }

            _context.SaveChanges();
        }
    }
}
