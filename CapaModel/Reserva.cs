using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaReserva { get; set; }
        public int EstadoReservaID { get; set; }
    }
}
