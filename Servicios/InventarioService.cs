using Inventario_Final.Entidades;
using Inventario_Final.Datos.Movimiento;

namespace Inventario_Final.Servicios
{
    public class InventarioService
    {
        private MovimientoDAO _datos = new MovimientoDAO();

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