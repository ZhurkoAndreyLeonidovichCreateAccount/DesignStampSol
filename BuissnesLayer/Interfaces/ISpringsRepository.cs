using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
  public  interface ISpringsRepository
    {
        List<Spring> GetAllSpring();
        Spring GetSpringById(int Id);
        void SaveSpring(Spring spring);
        void DeleteSpring(Spring spring);
        List<Spring> GetSpringsByDiametr(int diametr);
    }
}
