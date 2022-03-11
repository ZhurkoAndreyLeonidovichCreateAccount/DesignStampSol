using BuissnesLayer;
using DesignStamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Services
{
    public class SpringService
    {
        private DataManager _dataManager;

        public SpringService(DataManager dataManager)
        {
            _dataManager = dataManager;

        }

        public SpringView GetSpringViewById(int id,double Qremoving)
        {
            var spring = _dataManager.Springs.GetSpringById(id);
            SpringView springView = new SpringView();
            springView.Id = spring.Id;
            springView.Name = spring.Name;
            springView.Diametr = spring.Diametr;          
            springView.LengthScrew = spring.LengthScrew;
            springView.Pspring = spring.Pspring;
            springView.Stroke = spring.Stroke;
            springView.Tmin = spring.Tmin;
            springView.Tmax = spring.Tmax;
            springView.MinAmountSpring = Math.Round(Qremoving / spring.Pspring, MidpointRounding.AwayFromZero);
            return springView;
        }
    }
}
