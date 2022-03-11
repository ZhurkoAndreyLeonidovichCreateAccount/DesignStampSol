using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
  public  interface IBushingsRepository
    {
        List<Bushing> GetAllBushing();
        Bushing GetBushingById(int Id);
        void SaveBushing(Bushing bushing);
        void DeleteBushing(Bushing bushing);
        List<Bushing> GetBushingsByDiametr(int diametr);
    }
}
