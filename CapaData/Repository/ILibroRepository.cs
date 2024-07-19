using CapaModelo;

namespace CapaData.Repository
{
    public interface ILibroRepository
    {
        Task<int> CrearLibro(Libro libro);

    }
}
