using ProjetoFinalWeb.Service.Entity;
using ProjetoFinalWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Service.Service
{
    public class CityEventService : ICityEventService
    {
        public ICityEventRepository _cityEventRepository;
        public IEventReservationRepository _eventReservationRepository;
        public CityEventService(ICityEventRepository cityEventRepository, IEventReservationRepository eventReservationRepository)
        {
            _cityEventRepository = cityEventRepository;
            _eventReservationRepository = eventReservationRepository;
        }

        public List<CityEventEntity> SelectEvents()
        {
            return _cityEventRepository.SelectEvents();
        }

        public List<CityEventEntity> SelectEventsByTitle(string title)
        {
            return _cityEventRepository.SelectEventsByTitle(title);
        }
        public List<CityEventEntity> SelectEventsByDateAndLocal(DateTime dateHourEvent, string local)
        {
            return _cityEventRepository.SelectEventsByDateAndLocal(dateHourEvent, local);
        }
        public List<CityEventEntity> SelectEventsByPriceAndDate(decimal low, decimal high, DateTime dateHourEvent)
        {
            return _cityEventRepository.SelectEventsByPriceAndDate(low, high, dateHourEvent);
        }

        public bool InsertCityEvent(CityEventEntity cityEvent)
        {
            return _cityEventRepository.InsertCityEvent(cityEvent);
        }
        public bool DeleteCityEvent(long idEvent)
        {
            var eventReservationList = _eventReservationRepository.SelectReservation().ToList();
            if (!eventReservationList.Any(x => x.IdEvent == idEvent))
            {
                return _cityEventRepository.DeleteCityEvent(idEvent);
            }
            var cityEventList = _cityEventRepository.SelectEvents().ToList();
            var active = cityEventList.FirstOrDefault(x => x.IdEvent == idEvent);
            active.Status = false;
            return _cityEventRepository.UpdateCityEvent(active);
        }
        public bool UpdateCityEvent(CityEventEntity cityEvent)
        {
            return _cityEventRepository.UpdateCityEvent(cityEvent);
        }
    }
}
