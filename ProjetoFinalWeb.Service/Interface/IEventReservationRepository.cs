using ProjetoFinalWeb.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Service.Interface
{
    public interface IEventReservationRepository
    {
        List<EventReservationEntity> SelectReservation();
        List<EventReservationEntity> SelectReservationByPersonNameAndTitle(string personName, string title);
        bool InsertEventReservation(EventReservationEntity eventReservation);
        bool UpdateEventReservation(long idReservation, long quantity);
        bool DeleteEventReservation(long idReservation);
    }
}
