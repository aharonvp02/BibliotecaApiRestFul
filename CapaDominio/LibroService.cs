using CapaData.Repository;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }


        public async Task<int> CrearLibroAsync(Libro libro)
        {
            // Lógica de negocio
            var resultado = await _libroRepository.CrearLibro(libro);

            if (resultado == 0)
            {
                throw new InvalidOperationException("Error al crear libro. Por favor, inténtelo de nuevo.");
            }

            return resultado;
        }
    }
}
