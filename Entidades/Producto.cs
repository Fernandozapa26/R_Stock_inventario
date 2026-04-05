

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio_Costo { get; set; }
    public decimal Precio_Venta { get; set; }
    public int Stock { get; set; }

    public int IdCategoria { get; set; }  // 🔥 CLAVE
    public string CategoriaNombre { get; set; } // 🔥 para mostrar
}