using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class EnlargedPunchService
    {
        private DataManager _dataManager;

        public EnlargedPunchService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }
        public List<EnlargedPunchView> GetEnlargedPunchesViewById(List<EnlargedPunchesID> punchesId, List<DifferHole> differs)
        {
            List<EnlargedPunchView> punchViews = new List<EnlargedPunchView>();
            foreach (var item in punchesId)
            {
                var punch = _dataManager.EnlargedPunches.GetEnlargedPunchById(item.EnlargedPunchID);
                var amount = differs.Where(d => d.Diametr > punch.DiametrHoleFirst&&d.Diametr<punch.DiametrHoleLast).FirstOrDefault();
                EnlargedPunchView enlargedPunchView = new EnlargedPunchView();
                enlargedPunchView.Id = punch.Id;
                enlargedPunchView.Name = punch.Name;
                enlargedPunchView.DiametrHoleFirst = punch.DiametrHoleFirst;
                enlargedPunchView.DiametrSeat = punch.DiametrSeat;
                enlargedPunchView.DiametrHoleLast = punch.DiametrHoleLast;
                enlargedPunchView.DiametrFlange = punch.DiametrFlange;
                enlargedPunchView.HeightTottal = punch.HeightTottal;
                enlargedPunchView.HeighSeat = punch.HeighSeat;
                enlargedPunchView.HeighFlange = punch.HeighFlange;
                enlargedPunchView.AmountEnlargedPunch = amount.AmountHole;
               
                punchViews.Add(enlargedPunchView);

            }

            return punchViews;


        }

        public EnlargedPunchView GetEnlargedPunchViewById(int id, List<DifferHole> differs)
        {
            EnlargedPunchView enlargedPunchView = new EnlargedPunchView();

            var punch = _dataManager.EnlargedPunches.GetEnlargedPunchById(id);
                var amount = differs.Where(d => d.Diametr > punch.DiametrHoleFirst && d.Diametr < punch.DiametrHoleLast).FirstOrDefault();
               
                enlargedPunchView.Id = punch.Id;
                enlargedPunchView.Name = punch.Name;
                enlargedPunchView.DiametrHoleFirst = punch.DiametrHoleFirst;
                enlargedPunchView.DiametrSeat = punch.DiametrSeat;
                enlargedPunchView.DiametrHoleLast = punch.DiametrHoleLast;
                enlargedPunchView.DiametrFlange = punch.DiametrFlange;
                enlargedPunchView.HeightTottal = punch.HeightTottal;
                enlargedPunchView.HeighSeat = punch.HeighSeat;
                enlargedPunchView.HeighFlange = punch.HeighFlange;
                enlargedPunchView.AmountEnlargedPunch = amount.AmountHole;





            return enlargedPunchView;

        }
    }
}
