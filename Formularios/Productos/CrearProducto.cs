using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Inventario_Final.Datos.Productos; //base de datos 

namespace Inventario_Final.Formularios.Productos
{
    public partial class CrearProducto : Form
    {
        string conexion = "Server=localhost;Database=InventarioDB;Trusted_Connection=True;";

        // aquí va 👇
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string categoria = cbCategoria.Text;
            decimal precio = decimal.Parse(txtPrecio.Text);
            int stock =int.Parse(txtStock.Text);

            ProductoDAO coneccionProducto = new ProductoDAO();
            coneccionProducto.Guardar(nombre, categoria, precio, stock);
           
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editando producto...");
        }
        
            private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eliminando producto...");
        }
        
                 private void Limpiar(object sender, EventArgs e)
        {
            MessageBox.Show("Limpiar producto...");
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Click en la tabla");
        }

        public Label lblTitulo;
        public Label lblNombre;
        public Label lblPrecio;
        public Label lblStock;
        public Label lblCategoria;
        public TextBox txtNombre;
        public TextBox txtPrecio;
        public TextBox txtStock;
        public ComboBox cbCategoria;
        public Button btnGuardar;
        public Button btnEditar;
        public Button btnEliminar;
        public Button btnLimpiar;
        public DataGridView dgvProductos; 

        public CrearProducto()
        {
            InitializeComponent();
            Constructor();
        }



        private void Constructor()
        {
            this.Text = "Sistema de inventarios ";
            this.Size = new System.Drawing.Size(1000, 800); //esto cambia el tamaño al formulario
            this.StartPosition = FormStartPosition.CenterScreen; //poicion del formulario

            // 🔹 TITULO
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "GESTIÓN DE PRODUCTOS";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(230, 10);

            // 🔹 LABELS
            lblNombre = new Label();
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 60);

            lblCategoria = new Label();
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.Location = new System.Drawing.Point(30, 100);

            lblPrecio = new Label();
            this.lblPrecio.Text = "Precio:";
            this.lblPrecio.Location = new System.Drawing.Point(30, 140);

            lblStock = new Label();
            this.lblStock.Text = "Stock:";
            this.lblStock.Location = new System.Drawing.Point(30, 180);

            // 🔹 TEXTBOX
            txtNombre = new TextBox();
            this.txtNombre.Location = new System.Drawing.Point(120, 60);
            this.txtNombre.Size = new System.Drawing.Size(200, 23);

            txtPrecio = new TextBox();
            this.txtPrecio.Location = new System.Drawing.Point(120, 140);
            this.txtPrecio.Size = new System.Drawing.Size(200, 23);

            txtStock = new TextBox();
            this.txtStock.Location = new System.Drawing.Point(120, 180);
            this.txtStock.Size = new System.Drawing.Size(200, 23);

            // 🔹 COMBOBOX
            cbCategoria = new ComboBox();
            this.cbCategoria.Location = new System.Drawing.Point(120, 100);
            this.cbCategoria.Size = new System.Drawing.Size(200, 23);

            // 🔹 BOTONES
            btnGuardar = new Button();
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(400, 60);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            btnEditar = new Button();
            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(400, 100);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            btnEliminar = new Button();
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(400, 140);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            btnLimpiar = new Button();
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location = new System.Drawing.Point(400, 180);
            this.btnLimpiar.Click += new System.EventHandler(this.Limpiar);

            // 🔹 DATAGRIDVIEW
            dgvProductos = new DataGridView();
            this.dgvProductos.Location = new System.Drawing.Point(30, 230);
            this.dgvProductos.Size = new System.Drawing.Size(740, 230);
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // 🔹 ADD CONTROLS
            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblStock);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtStock);

            this.Controls.Add(this.cbCategoria);

            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);

            this.Controls.Add(this.dgvProductos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


    }
}

