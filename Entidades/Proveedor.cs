namespace Inventario_Final.Entidades
{
    public class Proveedor
    {
        // Compatibilidad: ambas versiones
        public int Id { get; set; } // Usado en una versión
        public int Id_proveedor { get; set; } // Usado en otra versión

        // Compatibilidad de nombres
        public string Nombre { get; set; } = string.Empty; // Usado en una versión
        public string NombreEmpresa { get; set; } = string.Empty; // Usado en otra versión
        public string ContactoNombre { get; set; } = string.Empty; // Usado en otra versión

        // Compatibilidad de contacto
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Usado en una versión
        public string Correo { get; set; } = string.Empty; // Usado en otra versión
    }
}
