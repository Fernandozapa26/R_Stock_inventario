using Inventario_Final.Entidades;
using Microsoft.Data.SqlClient;

namespace Inventario_Final.Datos.Inventario
{
    /// <summary>
    /// Repositorio del Integrante 3.
    /// Consultas: historial de movimientos, usuarios, stock bajo e inventario general.
    /// </summary>
    public class InventarioRepository
    {
        // ─── USUARIOS ──────────────────────────────────────────────────────────

        public Usuario? ValidarLogin(string nombreUsuario, string contrasenaHash)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            const string sql = @"
                SELECT Id, NombreUsuario, Contrasena, Rol, Activo
                FROM Usuarios
                WHERE NombreUsuario = @user
                  AND Contrasena    = @pass
                  AND Activo        = 1";

            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@user", nombreUsuario);
            cmd.Parameters.AddWithValue("@pass", contrasenaHash);
            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;

            return new Usuario
            {
                Id            = dr.GetInt32(0),
                NombreUsuario = dr.GetString(1),
                Contrasena    = dr.GetString(2),
                Rol           = dr.GetString(3),
                Activo        = dr.GetBoolean(4)
            };
        }

        // ─── MOVIMIENTOS ───────────────────────────────────────────────────────

        public void RegistrarMovimiento(Movimiento m)
        {
            using var con = Conexion.ObtenerConexion();
            con.Open();
            const string sql = @"
                INSERT INTO Movimientos
                    (ProductoId, Tipo, Cantidad, StockAnterior, StockNuevo, Fecha, Observacion, UsuarioResponsable)
                VALUES
                    (@prodId, @tipo, @cant, @anterior, @nuevo, @fecha, @obs, @usuario)";

            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@prodId",   m.ProductoId);
            cmd.Parameters.AddWithValue("@tipo",     m.Tipo);
            cmd.Parameters.AddWithValue("@cant",     m.Cantidad);
            cmd.Parameters.AddWithValue("@anterior", m.StockAnterior);
            cmd.Parameters.AddWithValue("@nuevo",    m.StockNuevo);
            cmd.Parameters.AddWithValue("@fecha",    m.Fecha);
            cmd.Parameters.AddWithValue("@obs",      (object?)m.Observacion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@usuario",  (object?)m.UsuarioResponsable ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public List<Movimiento> ObtenerHistorialPorProducto(int productoId)
        {
            var lista = new List<Movimiento>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            const string sql = @"
                SELECT m.Id, m.ProductoId, p.Nombre, m.Tipo, m.Cantidad,
                       m.StockAnterior, m.StockNuevo, m.Fecha, m.Observacion, m.UsuarioResponsable
                FROM Movimientos m
                INNER JOIN Productos p ON p.Id = m.ProductoId
                WHERE m.ProductoId = @prodId
                ORDER BY m.Fecha DESC";

            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@prodId", productoId);
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(MapearMovimiento(dr));
            return lista;
        }

        public List<Movimiento> ObtenerTodosLosMovimientos(DateTime? desde = null, DateTime? hasta = null)
        {
            var lista = new List<Movimiento>();
            using var con = Conexion.ObtenerConexion();
            con.Open();

            var sql = @"
                SELECT m.Id, m.ProductoId, p.Nombre, m.Tipo, m.Cantidad,
                       m.StockAnterior, m.StockNuevo, m.Fecha, m.Observacion, m.UsuarioResponsable
                FROM Movimientos m
                INNER JOIN Productos p ON p.Id = m.ProductoId
                WHERE 1=1";

            if (desde.HasValue) sql += " AND m.Fecha >= @desde";
            if (hasta.HasValue) sql += " AND m.Fecha <= @hasta";
            sql += " ORDER BY m.Fecha DESC";

            using var cmd = new SqlCommand(sql, con);
            if (desde.HasValue) cmd.Parameters.AddWithValue("@desde", desde.Value);
            if (hasta.HasValue) cmd.Parameters.AddWithValue("@hasta", hasta.Value.AddDays(1).AddSeconds(-1));
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(MapearMovimiento(dr));
            return lista;
        }

        // ─── INVENTARIO ────────────────────────────────────────────────────────

        public List<Producto> ObtenerProductosStockBajo(int umbral = 5)
        {
            var lista = new List<Producto>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "SELECT Id, Nombre, Categoria, Precio, Stock FROM Productos WHERE Stock <= @u ORDER BY Stock ASC", con);
            cmd.Parameters.AddWithValue("@u", umbral);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(new Producto { Id=dr.GetInt32(0), Nombre=dr.GetString(1),
                    Categoria=dr.IsDBNull(2)?"":dr.GetString(2), Precio=dr.GetDecimal(3), Stock=dr.GetInt32(4) });
            return lista;
        }

        public List<Producto> ObtenerInventarioGeneral()
        {
            var lista = new List<Producto>();
            using var con = Conexion.ObtenerConexion();
            con.Open();
            using var cmd = new SqlCommand(
                "SELECT Id, Nombre, Categoria, Precio, Stock FROM Productos ORDER BY Nombre", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(new Producto { Id=dr.GetInt32(0), Nombre=dr.GetString(1),
                    Categoria=dr.IsDBNull(2)?"":dr.GetString(2), Precio=dr.GetDecimal(3), Stock=dr.GetInt32(4) });
            return lista;
        }

        // ─── PRIVADOS ──────────────────────────────────────────────────────────

        private static Movimiento MapearMovimiento(SqlDataReader dr) => new()
        {
            Id                 = dr.GetInt32(0),
            ProductoId         = dr.GetInt32(1),
            NombreProducto     = dr.GetString(2),
            Tipo               = dr.GetString(3),
            Cantidad           = dr.GetInt32(4),
            StockAnterior      = dr.GetInt32(5),
            StockNuevo         = dr.GetInt32(6),
            Fecha              = dr.GetDateTime(7),
            Observacion        = dr.IsDBNull(8) ? "" : dr.GetString(8),
            UsuarioResponsable = dr.IsDBNull(9) ? "" : dr.GetString(9)
        };
    }
}
