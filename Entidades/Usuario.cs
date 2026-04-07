namespace Inventario_Final.Entidades
{
    public class Usuario
    {
        public int    Id            { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena    { get; set; } = string.Empty;  // SHA-256
        public string Rol           { get; set; } = string.Empty;  // ADMIN | VENDEDOR
        public bool   Activo        { get; set; } = true;
    }
}
