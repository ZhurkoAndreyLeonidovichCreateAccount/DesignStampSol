using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFDetailRepository : IDetailsRepository
    {
      readonly  ApplicationDbContext _context;
        public EFDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteDetail(Detail detail)
        {
            _context.Details.Remove(detail);
            _context.SaveChanges();
        }

        

        public List<Detail> GetAllDetail(bool includeDifferHoles = false)
        {
            return _context.Details.ToList();
        }

        

        public Detail GetDetailByName(string Name, bool includeDifferHoles = false)
        {
            if (includeDifferHoles)
                return _context.Set<Detail>().Include(x => x.differHoles).AsNoTracking().FirstOrDefault(x => x.Name == Name);
            return _context.Details.Find(Name);
        }

        public void SaveDetail(Detail detail)
        {
            if(_context.Details.Find(detail.Name)==null)
           
                _context.Add(detail);
            else
            {
               

                Detail detail1 = _context.Details.Find(detail.Name);
                _context.Details.Update(detail1);
                detail1.Name = detail.Name;
                detail1.Length = detail.Length;
                detail1.Width = detail.Width;
                detail1.ShearingStress = detail.ShearingStress;
                detail1.Thickness = detail.Thickness;
                detail1.AmountDiametrHoles = detail.AmountDiametrHoles;

                //_context.Details.Update(detail1);

            }


            _context.SaveChanges();

            
        }

        public void EditDetail(Detail detail)
        {
            
        }

        
    }
}
