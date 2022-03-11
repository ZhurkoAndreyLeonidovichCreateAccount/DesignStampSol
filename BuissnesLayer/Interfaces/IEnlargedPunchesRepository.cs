using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IEnlargedPunchesRepository
    {
        List<EnlargedPunch> GetAllEnlargedPunch();
        EnlargedPunch GetEnlargedPunchById(int Id);
        void SaveEnlargedPunch(EnlargedPunch enlargedPunch);
        void DeleteEnlargedPunch(EnlargedPunch enlargedPunch);
        List<EnlargedPunch> GetPunchesByDiametr(int diametr);
    }
}
