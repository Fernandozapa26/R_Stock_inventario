using Inventario_Final.Entidades;
using Inventario_Final.Servicios;

namespace Inventario_Final.Formularios
{
    public partial class FrmInventario : Form
    {
        private readonly InventarioService _service = new();
        private readonly Usuario _usuarioActual;

        public FrmInventario(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarInventarioGeneral();
            CargarMovimientos();
        }

        // ─── Tab 1: Inventario general ─────────────────────────────────────────
        private void CargarInventarioGeneral()
        {
            try
            {
                var productos = _service.ObtenerInventarioCompleto();
                dgvInventario.DataSource = null;
                dgvInventario.DataSource = productos;
                ColorizarStockBajo();
                lblTotalProductos.Text = $"Total de productos: {productos.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorizarStockBajo()
        {
            foreach (DataGridViewRow fila in dgvInventario.Rows)
            {
                if (fila.Cells["Stock"].Value is int stock && stock <= 5)
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                    fila.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        // ─── Tab 2: Kardex ─────────────────────────────────────────────────────
        private void CargarMovimientos()
        {
            try
            {
                DateTime? desde = chkFiltroFecha.Checked ? (DateTime?)dtpDesde.Value.Date : null;
                DateTime? hasta = chkFiltroFecha.Checked ? (DateTime?)dtpHasta.Value.Date : null;

                var movimientos = _service.ObtenerHistorialFiltrado(desde, hasta);
                dgvMovimientos.DataSource = null;
                dgvMovimientos.DataSource = movimientos;
                lblTotalMovimientos.Text  = $"Movimientos encontrados: {movimientos.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar movimientos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Alertas ───────────────────────────────────────────────────────────
        private void MostrarAlertasStock()
        {
            var criticos = _service.ObtenerAlertasStockBajo(5);
            if (criticos.Count == 0)
            {
                MessageBox.Show("✅ No hay productos con stock crítico.", "Revisión de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string lista = string.Join("\n", criticos.Select(p =>
                $"• {p.Nombre}  ({p.Categoria})  —  Stock: {p.Stock}"));

            MessageBox.Show($"⚠️ Productos con stock ≤ 5 unidades:\n\n{lista}",
                "Alerta de Stock Bajo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ─── Exportar CSV ──────────────────────────────────────────────────────
        private void ExportarCSV()
        {
            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter   = "CSV (*.csv)|*.csv",
                    FileName = $"inventario_{DateTime.Now:yyyyMMdd_HHmm}.csv"
                };
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var productos = _service.ObtenerInventarioCompleto();
                var lineas    = new List<string> { "Id,Nombre,Categoria,Precio,Stock" };
                lineas.AddRange(productos.Select(p =>
                    $"{p.Id},{p.Nombre},{p.Categoria},{p.Precio:F2},{p.Stock}"));

                File.WriteAllLines(dialog.FileName, lineas);
                MessageBox.Show("Archivo exportado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Eventos ──────────────────────────────────────────────────────────
        private void btnRefrescarInventario_Click(object sender, EventArgs e) => CargarInventarioGeneral();
        private void btnRefrescarMovimientos_Click(object sender, EventArgs e) => CargarMovimientos();
        private void btnAlertaStock_Click(object sender, EventArgs e)         => MostrarAlertasStock();
        private void btnExportarCSV_Click(object sender, EventArgs e)         => ExportarCSV();

        private void chkFiltroFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFiltroFecha.Checked;
            dtpHasta.Enabled = chkFiltroFecha.Checked;
        }
    }
}
