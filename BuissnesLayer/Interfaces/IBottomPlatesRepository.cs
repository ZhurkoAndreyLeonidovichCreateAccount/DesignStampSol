using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
  public  interface IBottomPlatesRepository
    {
        IEnumerable<BottomPlate> GetAllBottomPlate();
        BottomPlate GetBottomPlateByName(string Name);
        void SaveBottomPlate(BottomPlate plate);
        void DeleteBottomPlate(BottomPlate plate);
        BottomPlate GetBottomPlateByStampName(string stampName);
    }
}
