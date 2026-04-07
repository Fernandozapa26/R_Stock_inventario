using Inventario_Final.Formularios;
using Inventario_Final.Entidades;

namespace Inventario_Final
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var frmLogin = new FrmLogin())
            {
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    Usuario? usuarioActual = frmLogin.UsuarioActual;
                    if (usuarioActual != null)
                    {
                        Application.Run(new FrmMenu(usuarioActual));
                    }
                }
            }
        }
    }
}