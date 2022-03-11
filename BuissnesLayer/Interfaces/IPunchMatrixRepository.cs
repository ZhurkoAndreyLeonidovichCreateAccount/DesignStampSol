using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
  public interface IPunchMatrixRepository
    {
        IEnumerable<PunchMatrix> GetAllPuncMatrix(bool includeMaterials = false);
        PunchMatrix GetPuncMatrixByName(string Name);
        void SavePunchMatrix(PunchMatrix punchMatrix);
        void DeletePunchMatrix(PunchMatrix punchMatrix);
        PunchMatrix GetPunchMatrixByStampName(string stampName);
    }
}
