using DesignStamp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignStamp.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Calculation", Action="Index", Text="Начать расчет"},
            new MenuItem{ Controller="Stamps", Action="GetAllStamps", Text="Расчитанные штампы"},
            new MenuItem{ Controller="Details", Action="GetAllDetails", Text="Сохраненные детали"},
            new MenuItem{ Controller="Admin", Action="Index", Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            //Получение значений сегментов маршрута
            var controller = ViewContext.RouteData.Values["controller"];
            var action = ViewContext.RouteData.Values["action"];
            var area = ViewContext.RouteData.Values["area"];

            foreach (var item in _menuItems)
            {
                // Название контроллера совпадает?
                
                var _matchController = controller?.Equals(item.Controller) ?? false;
                if((string)controller=="Admin")
                {
                    if((string)action != "Index")
                    {
                        _matchController = false;
                    }
                  
                }
                // Название зоны совпадает?
                var _matchArea = area?.Equals(item.Area) ?? false;
                // Если есть совпадение, то сделать элемент меню активным 
                // (применить соответствующий класс CSS)
                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
}
