using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
  public  interface ICoversRepository
    {
        List<Cover> GetAllCover();
        Cover GetCoverById(int Id);
        void SaveCover(Cover cover);
        void DeleteCover(Cover cover);
        List<Cover> GetCoversByDiametr(int diametr);
    }
}
