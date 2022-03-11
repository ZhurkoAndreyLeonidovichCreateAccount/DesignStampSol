using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
   public interface IHoldersRepository
    {
        IEnumerable<Holder> GetAllholder(bool includeMaterials = false);
        Holder GetholderByName(string Name);
        void SaveHolder(Holder holder);
        void Deleteholder(Holder holder);
        Holder GetHolderByStampName(string stampName);
    }
}
