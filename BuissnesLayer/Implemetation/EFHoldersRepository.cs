using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFHoldersRepository : IHoldersRepository
    {
        ApplicationDbContext _context;

        public EFHoldersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Deleteholder(Holder holder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Holder> GetAllholder(bool includeMaterials = false)
        {
            
            throw new NotImplementedException();
        }

        public Holder GetholderByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Holder GetHolderByStampName(string stampName)
        {
           return _context.Holders.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public void SaveHolder(Holder holder)
        {
            if (_context.Holders.Find(holder.Name) == null)

                _context.Holders.Add(holder);
            else
            {
                Holder holder1 = _context.Holders.Find(holder.Name);
                _context.Entry(holder1).CurrentValues.SetValues(holder);

               

            }
            _context.SaveChanges();
        }
    }
}
