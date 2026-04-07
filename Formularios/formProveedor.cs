using Inventario_Final.Datos.Productos;
using Inventario_Final.Datos.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventario_Final.Formularios
{
    public partial class formProveedor : Form
    {
        ProveedorDAO proveedorDAO = new ProveedorDAO();
        List<Proveedor> proveedores;
        int idProveedor;

        public formProveedor()
        {
            InitializeComponent();
            Constructor();
            CargarProveedores();
        }


        public Label lblTitulo;
        public Label lblNombre;
        public Label lblContacto;
        public Label lblTelefono;
        public Label lblCorreo;
        public Label lblDireccion;
        public TextBox txtNombre;
        public TextBox txtContacto;
        public TextBox txtTelefono;
        public TextBox txtCorreo;
        public TextBox txtDireccion;
        public Button btnGuardar;
        public Button btnEditar;
        public Button btnEliminar;
        public Button btnLimpiar;
        public DataGridView dgvProveedores;

        private void Constructor()
        {
            this.Text = "Sistema de inventarios ";
            this.Size = new System.Drawing.Size(1000, 800); //esto cambia el tamaño al formulario
            this.StartPosition = FormStartPosition.CenterScreen; //poicion del formulario

            // 🔹 TITULO
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "GESTIÓN DE PROVEEDORES";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(230, 10);

            // 🔹 LABELS
            lblNombre = new Label();
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 60);

            lblContacto = new Label();
            this.lblContacto.Text = "Contacto Empresa:";
            this.lblContacto.Location = new System.Drawing.Point(30, 100);

            lblTelefono = new Label();
            this.lblTelefono.Text = "Telefono:";
            this.lblTelefono.Location = new System.Drawing.Point(30, 140);

            lblCorreo = new Label();
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.Location = new System.Drawing.Point(30, 180);

            lblDireccion = new Label();
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.Location = new System.Drawing.Point(30, 220);



            // 🔹 TEXTBOX
            txtNombre = new TextBox();
            this.txtNombre.Location = new System.Drawing.Point(140, 60);
            this.txtNombre.Size = new System.Drawing.Size(200, 23);

            txtContacto = new TextBox();
            this.txtContacto.Location = new System.Drawing.Point(140, 100);
            this.txtContacto.Size = new System.Drawing.Size(200, 23);

            txtTelefono = new TextBox();
            this.txtTelefono.Location = new System.Drawing.Point(140, 140);
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);

            txtCorreo = new TextBox();
            this.txtCorreo.Location = new System.Drawing.Point(140, 180);
            this.txtCorreo.Size = new System.Drawing.Size(200, 23);

            txtDireccion = new TextBox();
            this.txtDireccion.Location = new System.Drawing.Point(140, 220);
            this.txtDireccion.Size = new System.Drawing.Size(200, 23);
            // txtStock.BackColor = Color.Yellow;

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
            dgvProveedores = new DataGridView();
            this.dgvProveedores.Location = new System.Drawing.Point(60, 360);
            this.dgvProveedores.Size = new System.Drawing.Size(840, 230);
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellClick);

            // 🔹 ADD CONTROLS
            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblDireccion);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtDireccion);

            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);

            this.Controls.Add(this.dgvProveedores);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.NombreEmpresa = txtNombre.Text;
                proveedor.ContactoNombre = txtContacto.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Correo = txtCorreo.Text;
                proveedor.Direccion = txtDireccion.Text;

                proveedorDAO.Guardar(proveedor);
                MessageBox.Show("Registro guardado correctamente");
                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);

            }

        }

        private void CargarProveedores()
        {

            proveedores = proveedorDAO.Listar();
            dgvProveedores.DataSource = proveedores;
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.Id_proveedor = idProveedor;
                proveedor.NombreEmpresa = txtNombre.Text;
                proveedor.ContactoNombre = txtContacto.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Correo = txtCorreo.Text;
                proveedor.Direccion = txtDireccion.Text;

                proveedorDAO.Editar(proveedor);
                MessageBox.Show("Registro actualizado correctamente");
                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            proveedorDAO.Eliminar(idProveedor);
            CargarProveedores();
            MessageBox.Show("Eliminando producto...");
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtContacto.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            idProveedor = proveedores[index].Id_proveedor;
            txtContacto.Text = proveedores[index].ContactoNombre;
            txtNombre.Text = proveedores[index].NombreEmpresa;
            txtTelefono.Text = proveedores[index].Telefono;
            txtCorreo.Text = proveedores[index].Correo;
            txtDireccion.Text = proveedores[index].Direccion;
        }


        private void formProveedor_Load(object sender, EventArgs e)
        {

        }

    }
}
