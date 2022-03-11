using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IPullersRepository
    {
        IEnumerable<Puller> GetAllPuller();
        Puller GetPullerByName(string Name);
        void SavePuller(Puller holder);
        void DeletePuller(Puller holder);
        Puller GetPullerByStampName(string stampName);
    }
}
