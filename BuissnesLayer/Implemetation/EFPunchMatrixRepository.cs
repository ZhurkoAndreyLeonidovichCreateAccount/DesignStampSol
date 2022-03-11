using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFPunchMatrixRepository : IPunchMatrixRepository
    {
        ApplicationDbContext _context;
        public EFPunchMatrixRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeletePunchMatrix(PunchMatrix punchMatrix)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PunchMatrix> GetAllPuncMatrix(bool includeMaterials = false)
        {
            throw new NotImplementedException();
        }

        public PunchMatrix GetPunchMatrixByStampName(string stampName)
        {
            return _context.PunchMatrices.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public PunchMatrix GetPuncMatrixByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void SavePunchMatrix(PunchMatrix punchMatrix)
        {
           

                if (_context.PunchMatrices.Find(punchMatrix.Name) == null)

                    _context.PunchMatrices.Add(punchMatrix);
                else
                {
                PunchMatrix punchMatrix1 = _context.PunchMatrices.Find(punchMatrix.Name);
                    _context.Entry(punchMatrix1).CurrentValues.SetValues(punchMatrix);
                  

                }
            _context.SaveChanges();

        }
    }
}
