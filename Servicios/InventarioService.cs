using Inventario_Final.Entidades;
using Inventario_Final.Datos.Movimiento;
using Inventario_Final.Datos.Inventario;
using System.Security.Cryptography;
using System.Text;

namespace Inventario_Final.Servicios
{
    public class InventarioService
    {
        private MovimientoDAO _datos = new MovimientoDAO();

                private readonly InventarioRepository _repo = new();

        // ─── SEGURIDAD ────────────────────────────────────────────────────────

        /// <summary>
        /// Autentica al usuario. Devuelve el objeto Usuario o null si falla.
        /// </summary>
        public Usuario? Login(string nombreUsuario, string contrasenaPlana)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasenaPlana))
                return null;

            string hash = HashearSHA256(contrasenaPlana);
            return _repo.ValidarLogin(nombreUsuario.Trim(), hash);
        }

        public static string HashearSHA256(string texto)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(texto));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }

        // ─── STOCK BAJO ───────────────────────────────────────────────────────

        public List<Producto> ObtenerAlertasStockBajo(int umbral = 5)
            => _repo.ObtenerProductosStockBajo(umbral);

        public bool HayProductosEnStockCritico(int umbral = 5)
            => _repo.ObtenerProductosStockBajo(umbral).Count > 0;

        // ─── INVENTARIO ───────────────────────────────────────────────────────

        public List<Producto> ObtenerInventarioCompleto()
            => _repo.ObtenerInventarioGeneral();

        // ─── MOVIMIENTOS ─────────────────────────────────────────────────────

        public List<Movimiento> ObtenerHistorial(int productoId)
            => _repo.ObtenerHistorialPorProducto(productoId);

        public List<Movimiento> ObtenerHistorialFiltrado(DateTime? desde, DateTime? hasta)
            => _repo.ObtenerTodosLosMovimientos(desde, hasta);

        /// <summary>
        /// Registra un movimiento manual con validaciones de negocio.
        /// </summary>
        public (bool ok, string mensaje) RegistrarMovimientoManual(Movimiento movimiento)
        {
            if (movimiento.Cantidad <= 0)
                return (false, "La cantidad debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(movimiento.Tipo))
                return (false, "Debe especificar el tipo de movimiento.");

            movimiento.Fecha = DateTime.Now;
            _repo.RegistrarMovimiento(movimiento);
            return (true, "Movimiento registrado correctamente.");
        }

        public string ProcesarMovimiento(Entidades.Movimiento mov)
        {
            // Validaciones de negocio
            if (mov.Cantidad <= 0)
                return "La cantidad debe ser mayor a cero.";

            if (mov.IdProducto <= 0)
                return "Debe seleccionar un producto válido.";

            bool exito = _datos.RegistrarMovimiento(mov);

            return exito ? "Éxito" : "Error técnico al guardar el movimiento.";
        }
    }
}