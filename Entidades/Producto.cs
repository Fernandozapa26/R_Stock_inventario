
namespace Inventario_Final.Entidades
{
    public class Producto
    {
        // Compatibilidad: ambas versiones
        public int Id { get; set; } // Usado en una versión
        public int Id_producto { get; set; } // Usado en otra versión

        public string Nombre { get; set; } = string.Empty;

        // Compatibilidad de precios
        public decimal Precio { get; set; } // Usado en una versión
        public decimal Precio_Costo { get; set; } // Usado en otra versión
        public decimal Precio_Venta { get; set; } // Usado en otra versión

        // Compatibilidad de stock
        public int Stock { get; set; }

        // Compatibilidad de categoría
        public string Categoria { get; set; } = string.Empty; // Usado en una versión
        public int IdCategoria { get; set; } // Usado en otra versión
        public string CategoriaNombre { get; set; } = string.Empty; // Usado en otra versión

        // Compatibilidad de proveedor
        public int IdProveedor { get; set; } // Usado en otra versión
        public string ProveedorNombre { get; set; } = string.Empty; // Usado en otra versión
    }
}
