using CapaDominio;
using CapaModelo;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost("RegistroLibro")]
        public async Task<IActionResult> CrearLibro([FromBody] Libro libro)
        {
            if (libro == null)
            {
                return BadRequest("Libro no válido.");
            }

            var libroId = await _libroService.CrearLibroAsync(libro);

            if (libroId == 0)
            {
                return StatusCode(500, "No se pudo crear el libro.");
            }

            return Ok(new { message = "Reserva libro exitosamente", libroId });
        }



    }
}
