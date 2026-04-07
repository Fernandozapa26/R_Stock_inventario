using System;

namespace Inventario_Final.Entidades
{
	public class Movimiento
	{
		public int Id { get; set; }

		public string Tipo { get; set; } = string.Empty;
		public int IdMovimiento { get; set; }
		public int IdProducto { get; set; }
		public string TipoMovimiento { get; set; } = string.Empty; // "Entrada", "Salida", "Merma"
		public int Cantidad { get; set; }
		public decimal Costo { get; set; }
		public DateTime Fecha { get; set; }
		public string Responsable { get; set; } = string.Empty; // El extra que sugerimos

		// Propiedad de navegación para mostrar el nombre en la tabla
		public string NombreProducto { get; set; } = string.Empty;
		public int StockAnterior { get; set; }
		public int StockNuevo { get; set; }

		public string Observacion { get; set; } = string.Empty;

		public string UsuarioResponsable { get; set; } = string.Empty;
	}
}