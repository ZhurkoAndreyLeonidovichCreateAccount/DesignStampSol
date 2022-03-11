using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFPresesRepository :IPressesRepository
    {
        ApplicationDbContext _context;
        public EFPresesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeletePress(Press press)
        {
            _context.Pressess.Remove(press);
            _context.SaveChanges();
        }

        public List<Press> GetAllPress()
        {
           return _context.Pressess.ToList();
        }

        public Press GetPressById(int Id)
        {
            return _context.Pressess.Find(Id);
        }

        public void SavePress(Press press)
        {

            if (press.Id==0)

                _context.Pressess.Add(press);
            else
            {
                Press press1 = _context.Pressess.Find(press.Id);
                _context.Entry(press1).CurrentValues.SetValues(press);



            }
            _context.SaveChanges();
        }
    }
}
