using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IColumnsRepository
    {
        List<Column> GetAllColumn();
        Column GetColumnById(int Id);
        void SaveColumn(Column column);
        void DeleteColumn(Column column);
        public List<Column> GetColumnsByDiametr(int diametr);


    }
}
