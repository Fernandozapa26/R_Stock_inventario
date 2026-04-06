using System;
using System.Windows.Forms;
using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

namespace Inventario_Final.Formularios.Productos.EntradaProductos
{
    public partial class FrmEntradaProductos : Form
    {
        public FrmEntradaProductos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Creamos el objeto con los datos de los TextBox
                var nuevoMov = new Entidades.Movimiento()
                {
                    IdProducto = int.Parse(txtIdProducto.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    Costo = decimal.Parse(txtCosto.Text),
                    TipoMovimiento = "Entrada" 
                };

                // Llamamos al servicio
                InventarioService service = new InventarioService();
                string resultado = service.ProcesarMovimiento(nuevoMov);

                if (resultado == "Éxito")
                {
                    MessageBox.Show("¡Inventario actualizado!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdProducto.Clear();
                    txtCantidad.Clear();
                    txtCosto.Clear();
                }
                else
                {
                    MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de datos: " + ex.Message);
            }
        }

        private void InitializeComponent()
        {

        }
    }
}