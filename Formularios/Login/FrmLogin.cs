using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

namespace Inventario_Final.Formularios
{
    public partial class FrmLogin : Form
    {
        private readonly InventarioService _service = new();

        /// <summary>Usuario autenticado, leído por Program.cs después del ShowDialog.</summary>
        public Usuario? UsuarioActual { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave   = txtClave.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                MostrarError("Por favor complete todos los campos.");
                return;
            }

            try
            {
                var u = _service.Login(usuario, clave);

                if (u is null)
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                UsuarioActual = u;
                DialogResult  = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión:\n" + ex.Message);
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnIngresar_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MostrarError(string msg)
        {
            lblError.Text    = msg;
            lblError.Visible = true;
        }
    }
}
