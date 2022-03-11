using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IPressesRepository
    {

        List<Press> GetAllPress();
        Press GetPressById(int Id);
        void SavePress(Press press);
        void DeletePress(Press press);
    }
}
