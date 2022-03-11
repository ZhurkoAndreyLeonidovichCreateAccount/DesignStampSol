using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface ITopPlatesRepository
    {
        IEnumerable<TopPlate> GetAllTopPlate();
        TopPlate GetTopPlateByName(string Name);
        void SaveTopPlate(TopPlate plate);
        void DeleteTopPlate(TopPlate plate);
        TopPlate GetTopPlateByStampName(string stampName);
    }
}
