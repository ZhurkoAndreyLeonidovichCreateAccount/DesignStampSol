using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFAllForcesRepository : IAllForcesRepository
    {
        ApplicationDbContext _context;
        public EFAllForcesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteAllForce(AllForce force)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AllForce> GetAllAllForce()
        {
            throw new NotImplementedException();
        }

        public AllForce GetAllForceById(int id)
        {
            throw new NotImplementedException();
        }

        public AllForce GetAllForceByStampName(string stampName)
        {
            return _context.AllForces.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public void SaveAllForce(AllForce force)
        {

            if (force.Id == 0)

                _context.AllForces.Add(force);
            else
            {
                var force1 = _context.AllForces.Find(force.Id);
               _context.AllForces.Update(force1);
               
            }
            _context.SaveChanges();
        }
    }
}
