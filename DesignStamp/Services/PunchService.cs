using BuissnesLayer;
using DataLayer.Entities;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class PunchService
    {
        private DataManager _dataManager;

        public PunchService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public void SavePunchesToPucnhesID(List<Punch> punches, string StampName)
        {

            
        }

        public List<PunchView> GetPunchesViewById(List<PunchesID> punchesId, List<DifferHole> differs)
        {
            List<PunchView> punchViews = new List<PunchView>();    
                foreach (var item in punchesId)
                {
                    var punch = _dataManager.Punches.GetPunchById(item.PunchID);
                    var amount = differs.Where(d=>d.Diametr==punch.DiametrHole).FirstOrDefault();
                    PunchView punchView = new PunchView();
                    punchView.Id = punch.Id;
                    punchView.Name = punch.Name;
                    punchView.DiametrHole = punch.DiametrHole;
                    punchView.DiametrSeat = punch.DiametrSeat;
                    punchView.DiametrFlange = punch.DiametrFlange;
                    punchView.HeightHole = punch.HeightHole;
                    punchView.HeighSeat = punch.HeighSeat;
                    punchView.HeightTottal = punch.HeightTottal;
                    punchView.AmountPunch = amount.AmountHole;
                    punchView.HeighFlange = punch.HeighFlange;
                    punchViews.Add(punchView);

                }

            return punchViews;


        }

        public PunchView GetPunchViewById(int id, List<DifferHole> differs)
        {
            PunchView punchView = new PunchView();
           
                var punch = _dataManager.Punches.GetPunchById(id);
                var amount = differs.Where(d => d.Diametr == punch.DiametrHole).FirstOrDefault();
                punchView.Id = punch.Id;
                punchView.Name = punch.Name;
                punchView.DiametrHole = punch.DiametrHole;
                punchView.DiametrSeat = punch.DiametrSeat;
                punchView.DiametrFlange = punch.DiametrFlange;
                punchView.HeightHole = punch.HeightHole;
                punchView.HeighSeat = punch.HeighSeat;
                punchView.HeightTottal = punch.HeightTottal;
                punchView.AmountPunch = amount.AmountHole;
                punchView.HeighFlange = punch.HeighFlange;
              

           

            return punchView;


        }

    }
}
