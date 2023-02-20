using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalWeb.Service.Entity
{
    public class EventReservationEntity
    {
        public long IdReservation { get; set; }

        [Required(ErrorMessage = "O id do evento precisa ser colodado")]
        public long IdEvent { get; set; }

        [Required(ErrorMessage = "O nome de quem fez a reserva é necessario para o cadastro")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "A quantidade de convites é necessária para o cadastro")]
        public long Quantity { get; set; }
    }
}
