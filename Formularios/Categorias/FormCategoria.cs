using Inventario_Final.Datos.categoria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventario_Final.Formularios.Categorias
{
    public partial class FormCategoria : Form
    {

        private List<Categoria> categorias = new List<Categoria>();

        public FormCategoria()
        {

            InitializeComponent();
            ConstruirFormulario();
            CargarCategorias();
            CargarComboCategorias();

            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");
            cbEstado.SelectedIndex = 0;

        }

        TextBox txtNombre;
        Button btnGuardar, btnEliminar;
        DataGridView dgvCategorias;
        Label lblNombre;
        ComboBox cbCategoria;
        ComboBox cbEstado;


        private void ConstruirFormulario()
        {
            this.Text = "Gestión de Categorías";
            this.Size = new System.Drawing.Size(600, 500);

            // LABEL
            lblNombre = new Label();
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 60);

            // 🔹 COMBO CATEGORIA
            cbCategoria = new ComboBox();
            cbCategoria.Location = new System.Drawing.Point(50, 90);
            cbCategoria.Width = 200;

            // 🔹 COMBO ESTADO
            cbEstado = new ComboBox();
            cbEstado.Location = new System.Drawing.Point(50, 130);
            cbEstado.Width = 200;

            // TEXTBOX
            txtNombre = new TextBox();
            txtNombre.Location = new System.Drawing.Point(120, 60);
            txtNombre.Width = 200;

            // BOTONES
            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new System.Drawing.Point(380, 60);
            btnGuardar.Size = new System.Drawing.Size(100, 33);
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new System.Drawing.Point(380, 100);
            btnEliminar.Size = new System.Drawing.Size(100, 33);
            btnEliminar.Click += btnEliminar_Click;

            //DATAGRID
            dgvCategorias = new DataGridView();
            dgvCategorias.Location = new System.Drawing.Point(50, 220);
            dgvCategorias.Size = new System.Drawing.Size(480, 250);
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.CellClick += dgvCategorias_CellClick;

            // AGREGAR CONTROLES
            this.Controls.Add(txtNombre);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnEliminar);
            this.Controls.Add(dgvCategorias);
            this.Controls.Add(lblNombre);
            this.Controls.Add(cbCategoria);
            this.Controls.Add(cbEstado);
        }

        // CARGAR
        private void CargarCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();
            categorias = dao.Listar();
            dgvCategorias.DataSource = categorias;
        }

        private void CargarComboCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();

            cbCategoria.DataSource = dao.Listar();
            cbCategoria.DisplayMember = "Nombre"; // lo que ve el usuario
            cbCategoria.ValueMember = "Id";       // valor real
        }


        // GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaDAO dao = new CategoriaDAO();
                dao.Guardar(txtNombre.Text);

                MessageBox.Show("Categoría guardada");

                txtNombre.Clear();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategorias.CurrentRow != null)
                {
                    Categoria c = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

                    CategoriaDAO dao = new CategoriaDAO();
                    dao.Eliminar(c.Id);

                    MessageBox.Show("Categoría eliminada");

                    CargarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // CLICK EN TABLA
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Categoria c = categorias[e.RowIndex];
                txtNombre.Text = c.Nombre;
            }
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
