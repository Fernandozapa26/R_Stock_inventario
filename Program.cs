using System;
using System.Windows.Forms;
// Referencias a las carpetas de los formularios
using Inventario_Final.Formularios.EntradaProductos;
using Inventario_Final.Formularios.SalidaProductos; 
using Inventario_Final.Formularios.Merma;           

namespace Inventario_Final
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- ELIGE CUÁL EJECUTAR ---

            // 1. Para probar Entradas:
            //Application.Run(new FrmEntradaProductos());

            // 2. Para probar Salidas (Ventas):
            // Application.Run(new FormSalidaProductos());

            // 3. Para probar Mermas:
            Application.Run(new FormMerma());
        }
    }
}