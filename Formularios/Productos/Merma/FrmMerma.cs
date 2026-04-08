using Inventario_Final.Datos.Productos;
using Inventario_Final.Entidades;
using Inventario_Final.Servicios;
using System;
using System.Windows.Forms;

namespace Inventario_Final.Formularios.Merma
{
    public partial class FormMerma : Form
    {
        private Label lblTitulo, lblIdProducto, lblCantidad, lblCosto;
        private TextBox txtIdProducto, txtCantidad, txtCosto;
        private Button btnGuardar;

        public FormMerma()
        {
            ConstructorGrafico();
        }

        private void ConstructorGrafico()
        {
            this.Text = "Reporte de Mermas";
            this.Size = new System.Drawing.Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitulo = new Label
            {
                Text = "REGISTRO DE PRODUCTO DAÑADO",
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(110, 20)
            };

            lblIdProducto = new Label { Text = "ID Producto:", Location = new System.Drawing.Point(50, 80) };
            txtIdProducto = new TextBox { Location = new System.Drawing.Point(180, 80), Size = new System.Drawing.Size(200, 23) };

            lblCantidad = new Label { Text = "Cantidad Dañada:", Location = new System.Drawing.Point(50, 130) };
            txtCantidad = new TextBox { Location = new System.Drawing.Point(180, 130), Size = new System.Drawing.Size(200, 23) };

            lblCosto = new Label { Text = "Costo Perdido:", Location = new System.Drawing.Point(50, 180) };
            txtCosto = new TextBox { Location = new System.Drawing.Point(180, 180), Size = new System.Drawing.Size(200, 23) };

            btnGuardar = new Button
            {
                Text = "Registrar Merma",
                Location = new System.Drawing.Point(180, 240),
                Size = new System.Drawing.Size(150, 40),
                BackColor = System.Drawing.Color.Salmon
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
                    TipoMovimiento = "Merma", 
                    Fecha = DateTime.Now
                };

                InventarioService service = new InventarioService();
                ProductoDAO productoDAO = new ProductoDAO();
                int idProducto = int.Parse(txtIdProducto.Text);
                int stock = productoDAO.BuscarProducto(idProducto).Stock;
                if (stock - int.Parse(txtCantidad.Text) >= 0)
                {
                    string res = service.ProcesarMovimiento(mov);
                    MessageBox.Show(res == "Éxito" ? "¡Merma reportada con éxito!" : res);
                }
                else{
                    MessageBox.Show("No existe stock suficiente");
                }
                
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}