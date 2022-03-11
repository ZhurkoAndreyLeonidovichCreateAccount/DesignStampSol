using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IDetailsRepository
    {
        List<Detail> GetAllDetail(bool includeDifferHoles = false);
        Detail GetDetailByName(string Name, bool includeDifferHoles = false);
        void SaveDetail(Detail detail);
        void DeleteDetail(Detail detail);
       
    }
}
