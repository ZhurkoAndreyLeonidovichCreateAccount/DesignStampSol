using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IMatricesRepository
    {
        IEnumerable<Matrix> GetAllMatrix();
        Matrix GetMatrixByName(string name);
        void SaveMatrix(Matrix matrix);
        void DeleteMatrix(Matrix matrix);
        Matrix GetMatrixByStampName(string stampName);
    }
}
