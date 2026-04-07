// Archivo original del repositorio - conservado para compatibilidad
// El punto de entrada principal ahora es Program.cs

using Inventario_Final.Datos.Productos;
using Inventario_Final.Entidades;

namespace Inventario_Final
{
    /// <summary>
    /// Clase de prueba para crear productos desde consola (uso en desarrollo).
    /// </summary>
    internal class ProgramCrearProducto
    {
        internal static void EjecutarPrueba()
        {
            var dao = new ProductoDAO();

            var nuevo = new Producto
            {
                Nombre    = "Producto de prueba",
                Categoria = "Test",
                Precio    = 9999m,
                Stock     = 10
            };

            dao.Insertar(nuevo);
            Console.WriteLine("Producto de prueba insertado correctamente.");

            var lista = dao.Listar();
            foreach (var p in lista)
                Console.WriteLine($"[{p.Id}] {p.Nombre} - Stock: {p.Stock} - Precio: {p.Precio:C}");
        }
    }
}
