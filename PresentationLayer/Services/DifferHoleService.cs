using BuissnesLayer;
using DataLayer.Entities;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Services
{
   public class DifferHoleService
    {
        private DataManager _dataManager;

        public DifferHoleService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<DifferHole> ListDifferHoleViewtoDB(List<DifferHoleView> differHolesView)
        {
            DifferHole differHole;
            List<DifferHole> differHoles = new List<DifferHole>();
            foreach (var item in differHolesView)
            {
                 differHole = new DifferHole();
                differHole.AmountHole = item.AmountHole;
                differHole.Diametr = item.Diametr;
                differHoles.Add(differHole);

            }
            return differHoles;
        }
    }
}
