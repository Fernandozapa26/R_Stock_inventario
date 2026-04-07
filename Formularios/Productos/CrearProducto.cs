using Inventario_Final.Datos.categoria;
using Inventario_Final.Datos.Productos;
using Inventario_Final.Datos.Proveedores;
using Inventario_Final.Entidades;
using Inventario_Final.Servicios;
using System;
using System.Collections; //base de datos 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventario_Final.Formularios.Productos
{
    public partial class CrearProducto : Form
    {

        ProductoDAO daoProducto = new ProductoDAO();
        List<Producto> productos;
        int idProduct;
        ProductoService serviceProducto = new ProductoService();

        // aquí
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Producto produc = new Producto();
                produc.Nombre = txtNombre.Text;
                produc.Precio_Costo = decimal.Parse(txtPrecio.Text);
                produc.Precio_Venta = decimal.Parse(txtPrecioVenta.Text);
                produc.Stock = int.Parse(txtStock.Text);

                produc.IdProveedor = Convert.ToInt32(cbProveedor.SelectedValue);
                produc.IdCategoria = Convert.ToInt32(cbCategoria.SelectedValue);

                Boolean valiStock = serviceProducto.stockValidar(produc.Stock);
                if (valiStock == true){
                    daoProducto.Guardar(produc);
                    MessageBox.Show("Registro guardado correctamente");
                } else {
                    MessageBox.Show("Stock incorrecto");
                }
           
                

                CargarProductos();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);

            }

        }

        private void CargarProductos()
        {
            
            productos = daoProducto.Listar();
            dgvProductos.DataSource = productos;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto produc = new Producto();
                produc.Id_producto = idProduct; // importante
                produc.Nombre = txtNombre.Text;
                produc.Precio_Costo = decimal.Parse(txtPrecio.Text);
                produc.Precio_Venta = decimal.Parse(txtPrecioVenta.Text);
                produc.Stock = int.Parse(txtStock.Text);
                produc.IdCategoria = Convert.ToInt32(cbCategoria.SelectedValue);

                daoProducto.EditarProducto(produc);

                MessageBox.Show("Producto editado correctamente");

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void CargarCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();

            cbCategoria.DataSource = dao.Listar();
            cbCategoria.DisplayMember = "Nombre"; // lo que ve el usuario
            cbCategoria.ValueMember = "Id";       // valor real (ID)
        }

        private void CargarProveedores()
        {
            ProveedorDAO dao = new ProveedorDAO();

            cbProveedor.DataSource = dao.Listar();
            cbProveedor.DisplayMember = "NombreEmpresa";
            cbProveedor.ValueMember = "Id_proveedor";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            daoProducto.EliminarProducto(idProduct);
            CargarProductos();
            MessageBox.Show("Eliminando producto...");
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
            cbCategoria.SelectedIndex = -1;
            idProduct = 0;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            idProduct = productos[index].Id_producto;
            txtNombre.Text = productos[index].Nombre;
            txtPrecio.Text = productos[index].Precio_Costo.ToString();
            txtPrecioVenta.Text = productos[index].Precio_Venta.ToString();
            txtStock.Text = productos[index].Stock.ToString();
            

        }
        
        public Label lblTitulo ;
        public Label lblProveedor ;
        public Label lblNombre;
        public Label lblPrecio ;
        public Label lblPrecioVenta ;
        public Label lblStock;
        public Label lblCategoria ;
        public TextBox txtNombre ;
        public TextBox txtPrecio ;
        public TextBox txtPrecioVenta ;
        public TextBox txtStock ;
        public ComboBox cbCategoria ;
        public Button btnGuardar ;
        public Button btnEditar;
        public Button btnEliminar ;
        public Button btnLimpiar ;
        public DataGridView dgvProductos ;
        public ComboBox cbProveedor ;


        public CrearProducto()
        {
            InitializeComponent();
            Constructor();
            CargarProductos();
            CargarCategorias();
            CargarProveedores();

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
            this.lblPrecio.Text = "Precio costo:";
            this.lblPrecio.Location = new System.Drawing.Point(30, 140);


            lblPrecioVenta = new Label();
            this.lblPrecioVenta.Text = " Precio venta:";
            this.lblPrecioVenta.Location = new System.Drawing.Point(30, 180);

            lblStock = new Label();
            this.lblStock.Text = "Stock:";
            this.lblStock.Location = new System.Drawing.Point(30, 220);
          
            this.lblStock.BackColor = System.Drawing.Color.LightYellow;

            lblProveedor = new Label();
            this.lblProveedor.Text = "Proveedor:";
            this.lblProveedor.Location = new System.Drawing.Point(30, 260);


            // 🔹 TEXTBOX
            txtNombre = new TextBox();
            this.txtNombre.Location = new System.Drawing.Point(140, 60);
            this.txtNombre.Size = new System.Drawing.Size(200, 23);

            txtPrecio = new TextBox();
            this.txtPrecio.Location = new System.Drawing.Point(140, 140);
            this.txtPrecio.Size = new System.Drawing.Size(200, 23);

            txtPrecioVenta = new TextBox();
            this.txtPrecioVenta.Location = new System.Drawing.Point(140, 180);
            this.txtPrecioVenta.Size = new System.Drawing.Size(200, 20);

            txtStock = new TextBox();
            this.txtStock.Location = new System.Drawing.Point(140, 220);
            this.txtStock.Size = new System.Drawing.Size(200, 23);
            // txtStock.BackColor = Color.Yellow;


            // 🔹 COMBOBOX
            cbCategoria = new ComboBox();
            this.cbCategoria.Location = new System.Drawing.Point(140, 100);
            this.cbCategoria.Size = new System.Drawing.Size(200, 23);

            cbProveedor = new ComboBox();
            this.cbProveedor.Location = new System.Drawing.Point(140, 260);
            this.cbProveedor.Size = new System.Drawing.Size(200, 23);

            // 🔹 BOTONES
            btnGuardar = new Button();
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(400, 60);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.Size = new System.Drawing.Size(100, 33);

            btnEditar = new Button();
            this.btnEditar.Text = "Editar";
            this.btnEditar.Location = new System.Drawing.Point(400, 100);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnEditar.Size = new System.Drawing.Size(100, 33);

            btnEliminar = new Button();
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(400, 140);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.Size = new System.Drawing.Size(100, 33);

            btnLimpiar = new Button();
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Location = new System.Drawing.Point(400, 180);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnLimpiar.Size = new System.Drawing.Size(100, 33);

            // 🔹 DATAGRIDVIEW
            dgvProductos = new DataGridView();
            this.dgvProductos.Location = new System.Drawing.Point(60, 360);
            this.dgvProductos.Size = new System.Drawing.Size(840, 230);
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // 🔹 ADD CONTROLS
            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblProveedor);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtStock);

            this.Controls.Add(this.cbCategoria);

            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cbProveedor);

            this.Controls.Add(this.dgvProductos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CrearProducto_Load(object sender, EventArgs e)
        {

        }
    }
}

