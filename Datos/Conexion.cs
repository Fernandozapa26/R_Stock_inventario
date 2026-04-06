using Microsoft.Data.SqlClient;

namespace Inventario_Final.Datos
{
    /// <summary>
    /// Clase base de conexión a SQL Server.
    /// Todos los repositorios del proyecto usan este método.
    /// ⚠️ Ajusta el nombre del servidor si es necesario:
    ///    - SQL Server Express:    .\SQLEXPRESS
    ///    - SQL Developer:         .\SQLDEVELOPER
    ///    - Instancia por defecto: . ó localhost
    /// </summary>
    public class Conexion
    {
        private static readonly string _cadena =
            "Server=.\\SQLDEVELOPER;Database=InventarioDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadena);
        }
    }
}
