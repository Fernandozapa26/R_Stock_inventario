using Inventario_Final.Formularios;

namespace Inventario_Final
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormSalidaProductos());

            // Ciclo: al cerrar sesión vuelve al login
            while (true)
            {
                var login = new FrmLogin();

                if (login.ShowDialog() != DialogResult.OK || login.UsuarioActual is null)
                    break; // Canceló → cerrar app

                Application.Run(new FrmMenu(login.UsuarioActual));
            }
        }
    }
}