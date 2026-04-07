

public class Producto
{
    public int Id_producto { get; set; }
    public string Nombre { get; set; }
    public decimal Precio_Costo { get; set; }
    public decimal Precio_Venta { get; set; }
    public int Stock { get; set; }

    public int IdCategoria { get; set; } 
    public string CategoriaNombre { get; set; } 

    public int IdProveedor { get; set; }
    public string ProveedorNombre { get; set; }
    
}
