using CapaModelo;
using Dapper;
using System.Data;

namespace CapaData.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly Conexion _conexion;
        public LibroRepository(Conexion conexionbd)
        {
            _conexion = conexionbd;
        }

        public async Task<int> CrearLibro(Libro libro)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("@Titulo", libro.Titulo, DbType.String);
                    parametros.Add("@Autor", libro.Autor, DbType.String);
                    parametros.Add("@CategoriaID", libro.CategoriaID, DbType.Int32);
                    parametros.Add("@EstanteID", libro.EstanteID, DbType.Int32);

                    parametros.Add("@LibroID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await conexion.ExecuteAsync("sp_CrearLibro", parametros, commandType: CommandType.StoredProcedure);
                    return parametros.Get<int>("@LibroID");
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
