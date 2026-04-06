using Inventario_Final.Datos.Productos;
using Inventario_Final.Entidades;

namespace Inventario_Final.Servicios
{
    /// <summary>
    /// Servicio de Productos - Integrante 1.
    /// </summary>
    public class ProductoService
    {
        private readonly ProductoDAO _dao = new();

        public List<Producto> ObtenerTodos() => _dao.Listar();

        public (bool ok, string mensaje) Crear(Producto p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                return (false, "El nombre no puede estar vacío.");
            if (p.Stock < 0)
                return (false, "El stock no puede ser negativo.");
            if (p.Precio < 0)
                return (false, "El precio no puede ser negativo.");
            _dao.Insertar(p);
            return (true, "Producto creado correctamente.");
        }

        public (bool ok, string mensaje) Actualizar(Producto p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                return (false, "El nombre no puede estar vacío.");
            if (p.Stock < 0)
                return (false, "El stock no puede ser negativo.");
            if (p.Precio < 0)
                return (false, "El precio no puede ser negativo.");
            _dao.Editar(p);
            return (true, "Producto actualizado correctamente.");
        }

        public void Eliminar(int id) => _dao.Eliminar(id);
    }
}