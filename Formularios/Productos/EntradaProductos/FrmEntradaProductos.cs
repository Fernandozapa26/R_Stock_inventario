using System;
using System.Windows.Forms;
using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

namespace Inventario_Final.Formularios.EntradaProductos
{
    public partial class FrmEntradaProductos : Form
    {
        // Definición de controles
        private Label lblTitulo, lblIdProducto, lblCantidad, lblCosto;
        private TextBox txtIdProducto, txtCantidad, txtCosto;
        private Button btnGuardar;

        public FrmEntradaProductos()
        {
     
            ConstructorGrafico();
        }

        private void ConstructorGrafico()
        {
            this.Text = "Registro de Entradas";
            this.Size = new System.Drawing.Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitulo = new Label
            {
                Text = "ENTRADA DE PRODUCTOS",
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(150, 20)
            };

            lblIdProducto = new Label { Text = "ID Producto:", Location = new System.Drawing.Point(50, 80) };
            txtIdProducto = new TextBox { Location = new System.Drawing.Point(180, 80), Size = new System.Drawing.Size(200, 23) };

            lblCantidad = new Label { Text = "Cantidad:", Location = new System.Drawing.Point(50, 130) };
            txtCantidad = new TextBox { Location = new System.Drawing.Point(180, 130), Size = new System.Drawing.Size(200, 23) };

            lblCosto = new Label { Text = "Costo:", Location = new System.Drawing.Point(50, 180) };
            txtCosto = new TextBox { Location = new System.Drawing.Point(180, 180), Size = new System.Drawing.Size(200, 23) };

            btnGuardar = new Button
            {
                Text = "Guardar Entrada",
                Location = new System.Drawing.Point(180, 240),
                Size = new System.Drawing.Size(150, 40),
                BackColor = System.Drawing.Color.LightGreen
            };
            btnGuardar.Click += new EventHandler(btnGuardar_Click);

            this.Controls.AddRange(new Control[] { lblTitulo, lblIdProducto, txtIdProducto, lblCantidad, txtCantidad, lblCosto, txtCosto, btnGuardar });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var mov = new Movimiento
                {
                    IdProducto = int.Parse(txtIdProducto.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    Costo = decimal.Parse(txtCosto.Text),
                    TipoMovimiento = "Entrada",
                    Fecha = DateTime.Now
                };

                InventarioService service = new InventarioService();
                string res = service.ProcesarMovimiento(mov);
                MessageBox.Show(res == "Éxito" ? "¡Stock actualizado!" : res);
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}