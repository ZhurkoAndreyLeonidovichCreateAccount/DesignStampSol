using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IStampsRepository
    {
        List<Stamp> GetAllStamp();
        Stamp GetStampByName(string name, bool includes=false);
        void SaveStamp(Stamp stamp);
       
        Stamp GetStampByColumnId(int id);
        Stamp GetStampByBushingId(int id);
        Stamp GetStampByCoverId(int id);
        Stamp GetStampByPunchId(int id);
        Stamp GetStampByEnlargedPunchId(int id);
        Stamp GetStampBySpringId(int id);
        Stamp GetStampByPressId(int id);
        Stamp GetStampByDetailName(string name);
        void DeleteStamp(string stampName);
       
    }
}
