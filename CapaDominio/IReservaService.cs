using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public interface IReservaService
    {
        Task<int> CrearReservaAsync(Reserva reserva);

    }
}
