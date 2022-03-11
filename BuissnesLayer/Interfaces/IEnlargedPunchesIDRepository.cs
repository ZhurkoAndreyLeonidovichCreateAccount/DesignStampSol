using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IEnlargedPunchesIDRepository
    {
        EnlargedPunchesID GetEnlargedPunchIDById(int id);
        void SaveEnlargedPunchesID(EnlargedPunchesID punches);
        void DeleteEnlargedPunches(EnlargedPunchesID punches);
    }
}
