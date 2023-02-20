using Dapper;
using MySqlConnector;
using ProjetoFinalWeb.Service.Entity;
using ProjetoFinalWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly string _stringConnection;

        public EventReservationRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        public List<EventReservationEntity> SelectReservation()
        {
            string query = "SELECT*FROM EventReservation";
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<EventReservationEntity>(query)).ToList();
        }

        public List<EventReservationEntity> SelectReservationByPersonNameAndTitle(string personName, string title)
        {
            string query = @$"SELECT * FROM EventReservation e INNER JOIN CityEvent c ON
                        e.PersonName = @PersonName AND c.Title LIKE ('%' + @Title + '%')
                        WHERE e.IdEvent = c.IdEvent";

            DynamicParameters parameters = new(new
            {
                title,
                personName
            });
            using MySqlConnection conn = new(_stringConnection);
            return conn.Query<EventReservationEntity>(query, parameters).ToList();
        }

        public bool InsertEventReservation(EventReservationEntity eventReservation)
        {
            string query = "INSERT INTO EventReservation VALUES(@IdEvent, @PersonName, @Quantity)";

            DynamicParameters parameters = new(new
            {
                eventReservation.IdEvent,
                eventReservation.PersonName,
                eventReservation.Quantity
            });
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;
        }
        public bool UpdateEventReservation(long idReservation, long quantity)
        {
            string query = "UPDATE EventReservation SET Quantity = @Quantity WHERE IdReservation = @IdReservation";

            DynamicParameters parameters = new(new
            {
                idReservation,
                quantity
            });
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;
        }
        public bool DeleteEventReservation(long idReservation)
        {
            string query = "DELETE FROM EventReservation WHERE IdReservation = @IdReservation";

            DynamicParameters parameters = new(new
            {
                idReservation
            });
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;
        }
    }
}
