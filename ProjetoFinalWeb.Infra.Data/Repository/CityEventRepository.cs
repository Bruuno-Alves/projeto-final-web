using Dapper;
using MySqlConnector;
using ProjetoFinalWeb.Service.Entity;
using ProjetoFinalWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Infra.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly string _stringConnection;

        public CityEventRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        public List<CityEventEntity> SelectEvents()
        {
            string query = "SELECT * FROM CityEvent";
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query)).ToList();
        }

        public List<CityEventEntity> SelectEventsByTitle(string title)
        {

            string query = $"SELECT * FROM CityEvent WHERE Title LIKE ('%' +  @Title + '%') ";
            DynamicParameters parameters = new(new
            {
                title
            });
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query, parameters)).ToList();
        }

        public List<CityEventEntity> SelectEventsByDateAndLocal(DateTime dateHourEvent, string local)
        {

            string query = $"SELECT * FROM CityEvent WHERE CONVERT(DATE, DateHourEvent)= @DateHourEvent AND Local Like('%' +  @Local + '%') ";
            DynamicParameters parameters = new(new
            {
                dateHourEvent,
                local
            });
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query, parameters)).ToList();
        }

        public List<CityEventEntity> SelectEventsByPriceAndDate(decimal low, decimal high, DateTime dateHourEvent)
        {

            string query = $"SELECT * FROM CityEvent WHERE Price >= @low AND Price <= @high AND CONVERT(DATE, DateHourEvent)= @DateHourEvent";
            DynamicParameters parameters = new(new
            {
                low,
                high,
                dateHourEvent
            });
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query, parameters)).ToList();
        }

        public bool InsertCityEvent(CityEventEntity cityEvent)
        {
            string query = "INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, @Local, @Address, @Price, @Status)";

            DynamicParameters parameters = new(new
            {
                cityEvent.Title,
                cityEvent.Description,
                cityEvent.DateHourEvent,
                cityEvent.Local,
                cityEvent.Address,
                cityEvent.Price,
                cityEvent.Status
            });
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;
        }

        public bool DeleteCityEvent(long idEvent)
        {
            string query = "DELETE FROM CityEvent WHERE IdEvent = @IdEvent";

            DynamicParameters parameters = new(new
            {
                idEvent
            });
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;
        }
        public bool UpdateCityEvent(CityEventEntity cityEvent)
        {
            string query = @"UPDATE CityEvent set Title = @Title, Description = @Description,
                            DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address,
                            Price = @Price, Status = @Status
                            where IdEvent = @IdEvent";

            DynamicParameters parameters = new(cityEvent);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = conn.Execute(query, parameters);
            return linhasAfetadas > 0;
        }
    }
}
