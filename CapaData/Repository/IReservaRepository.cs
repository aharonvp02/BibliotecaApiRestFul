using CapaModelo;

namespace CapaData.Repository
{
    public  interface IReservaRepository
    {
        Task<int> CrearReserva(Reserva reserva);
    }
}
