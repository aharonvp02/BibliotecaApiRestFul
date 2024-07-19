using CapaModelo;
using Dapper;
using System.Data;

namespace CapaData.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly Conexion _conexion;
        public ReservaRepository(Conexion conexionbd)
        {
            _conexion = conexionbd;
        }


        public async Task<int> CrearReserva(Reserva reserva)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@UsuarioID", reserva.UsuarioId, DbType.Int32);
                    parametros.Add("@LibroID", reserva.LibroId, DbType.Int32);
                    parametros.Add("@FechaReserva", reserva.FechaReserva, DbType.Date);
                    parametros.Add("@EstadoReservaID", reserva.EstadoReservaID, DbType.Int32);

                    parametros.Add("@ReservaID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await conexion.ExecuteAsync("sp_CrearReserva", parametros, commandType: CommandType.StoredProcedure);
                    return parametros.Get<int>("@ReservaID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_CrearReserva: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return 0;

            }
        }
    }
}
