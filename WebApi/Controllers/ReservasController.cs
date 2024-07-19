using CapaDominio;
using CapaModelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaServicio;
        public ReservasController(IReservaService reservaServicio)
        {
            _reservaServicio = reservaServicio;
        }

        [HttpPost("RegistroReserva")]
        public async Task<IActionResult> CrearPedido([FromBody] Reserva reserva)
        {
            if (reserva == null)
            {
                return BadRequest("Reserva no válida.");
            }

            try
            {
                var reservaId = await _reservaServicio.CrearReservaAsync(reserva);
                if (reservaId < 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al crear la reserva" });
                }

                return Ok(new { message = "Reserva creada exitosamente", reservaId });
            }
            catch (InvalidOperationException ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }


    }
}
