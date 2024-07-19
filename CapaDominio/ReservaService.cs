using CapaData.Repository;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<int> CrearReservaAsync(Reserva reserva)
        {
            // Lógica de negocio
            var resultado = await _reservaRepository.CrearReserva(reserva);

            if (resultado == 0)
            {
                throw new InvalidOperationException("Error al crear la reserva. Por favor, inténtelo de nuevo.");
            }

            return resultado;
        }
    }
}
