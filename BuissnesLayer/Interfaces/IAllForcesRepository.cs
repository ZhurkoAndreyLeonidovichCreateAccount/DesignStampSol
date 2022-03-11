using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IAllForcesRepository
    {
        IEnumerable<AllForce> GetAllAllForce();
        AllForce GetAllForceById(int id);
        void SaveAllForce(AllForce force);
        void DeleteAllForce(AllForce force);
        AllForce GetAllForceByStampName(string stampName);
       
    }
}
