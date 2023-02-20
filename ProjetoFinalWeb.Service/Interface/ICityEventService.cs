using ProjetoFinalWeb.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Service.Interface
{
    public interface ICityEventService
    {
        List<CityEventEntity> SelectEvents();
        List<CityEventEntity> SelectEventsByTitle(string title);
        List<CityEventEntity> SelectEventsByDateAndLocal(DateTime dateHourEvent, string local);
        List<CityEventEntity> SelectEventsByPriceAndDate(decimal low, decimal high, DateTime dateHourEvent);
        bool InsertCityEvent(CityEventEntity cityEvent);
        bool DeleteCityEvent(long id);
        bool UpdateCityEvent(CityEventEntity cityEvent);
    }
}
