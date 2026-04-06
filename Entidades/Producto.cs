
namespace Inventario_Final.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio_Costo { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Stock { get; set; }

        public decimal Precio { get; set; }

        public string Categoria { get; set; } = string.Empty;

        public int IdCategoria { get; set; }  // 🔥 CLAVE
        public string CategoriaNombre { get; set; } // 🔥 para mostrar
    }
}