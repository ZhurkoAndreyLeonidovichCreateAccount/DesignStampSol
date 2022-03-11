using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
   public class EFMatricesRepository: IMatricesRepository
    {
        ApplicationDbContext _context;
        public EFMatricesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteMatrix(Matrix matrixl)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Matrix> GetAllMatrix()
        {
            throw new NotImplementedException();
        }

        public Matrix GetMatrixByName(string name)
        {
           return _context.Matrices.Find(name);
        }

        public Matrix GetMatrixByStampName(string stampName)
        {
            return _context.Matrices.Where(d => d.StampName == stampName).FirstOrDefault();
        }

        public void SaveMatrix(Matrix matrix)
        {

            if (_context.Matrices.Find(matrix.Name) == null)

                _context.Matrices.Add(matrix);
            else
            {
                Matrix matrix1 = _context.Matrices.Find(matrix.Name);
                _context.Entry(matrix1).CurrentValues.SetValues(matrix);

               

            }
            _context.SaveChanges();
        }
    }
}
