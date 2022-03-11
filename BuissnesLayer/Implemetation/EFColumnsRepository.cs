using BuissnesLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLayer.Implemetation
{
    public class EFColumnsRepository : IColumnsRepository
    {

        ApplicationDbContext _context;
        public EFColumnsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteColumn(Column column)
        {
            _context.Columns.Remove(column);
            _context.SaveChanges();
        }

        public List<Column> GetAllColumn()
        {
            return _context.Columns.ToList();
        }

        public Column GetColumnById(int Id)
        {
            return _context.Columns.Find(Id);
        }

        public List<Column> GetColumnsByDiametr(int diametr)
        {
            if(diametr!=0)
            return _context.Columns.Where(d => d.Diametr == diametr).ToList();
            else
                return _context.Columns.ToList();
        }



        public void SaveColumn(Column column)
        {
            if (column.Id == 0)

                _context.Columns.Add(column);
            else
            {
                Column column1 = _context.Columns.Find(column.Id);
                _context.Entry(column1).CurrentValues.SetValues(column);


            }
            _context.SaveChanges();
        }
    }
}
