using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IPunchesRepository
    {
        List<Punch> GetAllPunch();
        Punch GetPunchById(int Id);
        void SavePunch(Punch punch);
        void DeletePunch(Punch punch);
        List<Punch> GetPunchesByDiametr(int diametr);
    }
}
