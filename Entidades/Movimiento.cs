using System;

namespace Inventario_Final.Entidades
{
	public class Movimiento
	{
		public int IdMovimiento { get; set; }
		public int IdProducto { get; set; }
		public string TipoMovimiento { get; set; } // "Entrada", "Salida", "Merma"
		public int Cantidad { get; set; }
		public decimal Costo { get; set; }
		public DateTime Fecha { get; set; }
		public string Responsable { get; set; } // El extra que sugerimos

		// Propiedad de navegación para mostrar el nombre en la tabla
		public string NombreProducto { get; set; }
	}
}