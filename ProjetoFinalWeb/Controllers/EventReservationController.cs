using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalWeb.Service.Entity;
using ProjetoFinalWeb.Service.Interface;

namespace ProjetoFinalWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : Controller
    {
        public List<EventReservationEntity> EventReservationList { get; set; }

        public IEventReservationService _eventReservationService;

        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }

        [HttpGet("/EventReservation/GetReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<EventReservationEntity>> GetEventReservation()
        {
            var eventReservation = _eventReservationService.SelectReservation();
            if (eventReservation == null)
                return NotFound();
            return Ok(eventReservation);
        }

        [HttpGet("/EventReservation/GetReservationByPersonNameAndTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "cliente, admin")]
        public ActionResult<EventReservationEntity> GetEventReservationByPersonNameAndTitle(string personName, string title)
        {
            var eventReservation = _eventReservationService.SelectReservationByPersonNameAndTitle(personName, title);
            if (eventReservation == null)
                return NotFound();
            return Ok(eventReservation);
        }

        [HttpPost("/EventReservation/Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<EventReservationEntity> InsertEventReservation(EventReservationEntity eventReservation)
        {
            if (!_eventReservationService.InsertEventReservation(eventReservation))
                return BadRequest();

            return CreatedAtAction(nameof(InsertEventReservation), eventReservation);
        }

        [HttpPut("/EventReservation/Update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEventReservation(long id, long quantity)
        {
            if (!_eventReservationService.UpdateEventReservation(id, quantity))
                return NotFound("Reserva não encontrada.");

            return NoContent();
        }

        [HttpDelete("/EventReservation/Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<EventReservationEntity>> DeleteEventReservation(long id)
        {
            if (!_eventReservationService.DeleteEventReservation(id))
                return NotFound("Reserva não encontrada.");
            return NoContent();
        }
    }
}
