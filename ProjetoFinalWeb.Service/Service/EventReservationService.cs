using ProjetoFinalWeb.Service.Entity;
using ProjetoFinalWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Service.Service
{
    public class EventReservationService : IEventReservationService
    {
        public IEventReservationRepository _eventReservationRepository;
        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }

        public List<EventReservationEntity> SelectReservation()
        {
            return _eventReservationRepository.SelectReservation();
        }

        public List<EventReservationEntity> SelectReservationByPersonNameAndTitle(string personName, string title)
        {
            return _eventReservationRepository.SelectReservationByPersonNameAndTitle(personName, title);
        }

        public bool InsertEventReservation(EventReservationEntity eventReservation)
        {
            return _eventReservationRepository.InsertEventReservation(eventReservation);
        }
        public bool UpdateEventReservation(long reservationId, long quantity)
        {

            return _eventReservationRepository.UpdateEventReservation(reservationId, quantity);
        }
        public bool DeleteEventReservation(long idReservation)
        {
            return _eventReservationRepository.DeleteEventReservation(idReservation);
        }
    }
}
