using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

namespace Inventario_Final.Formularios
{
    public partial class FrmMenu : Form
    {
        private readonly InventarioService _service = new();
        private readonly Usuario _usuarioActual;

        public FrmMenu(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = $"Bienvenido, {_usuarioActual.NombreUsuario}   |   Rol: {_usuarioActual.Rol}";
            VerificarAlertaStock();
        }

        private void VerificarAlertaStock()
        {
            bool hay = _service.HayProductosEnStockCritico();
            pnlAlerta.Visible = hay;
            if (hay)
                lblAlerta.Text = "⚠️  Hay productos con stock crítico (≤ 5 unidades). Revise el módulo de Inventario.";
        }

        // ─── Navegación ───────────────────────────────────────────────────────

        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Integrante 1 conecta aquí su FrmProductos
            // new FrmProductos().ShowDialog();
            MessageBox.Show("Módulo de Productos (Integrante 1 — pendiente de integrar).",
                "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            // Integrante 2 conecta aquí su FrmVentas
            // new FrmVentas().ShowDialog();
            MessageBox.Show("Módulo de Ventas (Integrante 2 — pendiente de integrar).",
                "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            var frm = new FrmInventario(_usuarioActual);
            frm.ShowDialog();
            VerificarAlertaStock(); // Refresca alerta al volver
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
