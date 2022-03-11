using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFCoversRepository : ICoversRepository
    {

       readonly ApplicationDbContext _context;
        public EFCoversRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteCover(Cover cover)
        {
            _context.Covers.Remove(cover);
            _context.SaveChanges();
        }

        public List<Cover> GetAllCover()
        {
            return _context.Covers.ToList(); 
        }

        public Cover GetCoverById(int Id)
        {
           return _context.Covers.Find(Id);
        }

        public List<Cover> GetCoversByDiametr(int diametr)
        {
            if (diametr != 0)
                return _context.Covers.Where(d => d.Diametr == diametr).ToList();
            else
                return _context.Covers.ToList();
        }

        public void SaveCover(Cover cover)
        {
            if (cover.Id == 0)

                _context.Covers.Add(cover);
            else
            {
                Cover cover1 = _context.Covers.Find(cover.Id);
                _context.Entry(cover1).CurrentValues.SetValues(cover);


            }
            _context.SaveChanges();
        }
    }
}
