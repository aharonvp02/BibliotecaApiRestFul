using CapaModelo;

namespace CapaDominio
{
    public interface ILibroService
    {
        Task<int> CrearLibroAsync(Libro libro);
    }
}
