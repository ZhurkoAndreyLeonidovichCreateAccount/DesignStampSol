using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IPunchesIDRepository
    {
       
        PunchesID GetPunchIDById(int id);
        void SavePunchesID(PunchesID punches);
        void DeleteTopPlate(PunchesID punches);
        
    }
}
