namespace Inventario_Final.Formularios
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl        tabControl;
        private TabPage           tabInventario;
        private TabPage           tabKardex;

        // Tab inventario
        private DataGridView dgvInventario;
        private Button       btnRefrescarInventario;
        private Button       btnAlertaStock;
        private Button       btnExportarCSV;
        private Label        lblTotalProductos;

        // Tab kardex
        private DataGridView   dgvMovimientos;
        private CheckBox       chkFiltroFecha;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button         btnRefrescarMovimientos;
        private Label          lblDesde;
        private Label          lblHasta;
        private Label          lblTotalMovimientos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl              = new TabControl();
            tabInventario           = new TabPage();
            tabKardex               = new TabPage();
            dgvInventario           = new DataGridView();
            dgvMovimientos          = new DataGridView();
            btnRefrescarInventario  = new Button();
            btnAlertaStock          = new Button();
            btnExportarCSV          = new Button();
            lblTotalProductos       = new Label();
            chkFiltroFecha          = new CheckBox();
            dtpDesde                = new DateTimePicker();
            dtpHasta                = new DateTimePicker();
            btnRefrescarMovimientos = new Button();
            lblDesde                = new Label();
            lblHasta                = new Label();
            lblTotalMovimientos     = new Label();

            // ── Formulario ──────────────────────────────────────────────────
            Text          = "📊 Inventario General y Kardex";
            Size          = new Size(950, 620);
            StartPosition = FormStartPosition.CenterParent;
            BackColor     = Color.WhiteSmoke;
            Load         += FrmInventario_Load;

            // ── TabControl ──────────────────────────────────────────────────
            tabControl.Dock     = DockStyle.Fill;
            tabControl.Font     = new Font("Segoe UI", 9.5f);
            tabControl.Controls.AddRange(new TabPage[] { tabInventario, tabKardex });

            // ══════════════════════════════════════════════════════════════
            // TAB 1: Inventario General
            // ══════════════════════════════════════════════════════════════
            tabInventario.Text    = "📦 Inventario General";
            tabInventario.Padding = new Padding(5);

            var pnlToolInv = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 50,
                BackColor = Color.White,
                Padding   = new Padding(5, 8, 5, 5)
            };

            ConfigurarBoton(btnRefrescarInventario, "🔄 Refrescar", new Point(8, 8), Color.FromArgb(30, 30, 60));
            btnRefrescarInventario.Click += btnRefrescarInventario_Click;

            ConfigurarBoton(btnAlertaStock, "⚠️ Stock Bajo", new Point(130, 8), Color.FromArgb(200, 150, 0));
            btnAlertaStock.Click += btnAlertaStock_Click;

            ConfigurarBoton(btnExportarCSV, "📥 Exportar CSV", new Point(252, 8), Color.FromArgb(40, 130, 60));
            btnExportarCSV.Click += btnExportarCSV_Click;

            lblTotalProductos.Text      = "";
            lblTotalProductos.AutoSize  = true;
            lblTotalProductos.Font      = new Font("Segoe UI", 9);
            lblTotalProductos.ForeColor = Color.DimGray;
            lblTotalProductos.Location  = new Point(390, 17);

            pnlToolInv.Controls.AddRange(new Control[]
                { btnRefrescarInventario, btnAlertaStock, btnExportarCSV, lblTotalProductos });

            ConfigurarGrid(dgvInventario);
            dgvInventario.Dock = DockStyle.Fill;

            tabInventario.Controls.AddRange(new Control[] { dgvInventario, pnlToolInv });

            // ══════════════════════════════════════════════════════════════
            // TAB 2: Kardex / Movimientos
            // ══════════════════════════════════════════════════════════════
            tabKardex.Text    = "📋 Kardex de Movimientos";
            tabKardex.Padding = new Padding(5);

            var pnlToolKardex = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 50,
                BackColor = Color.White
            };

            chkFiltroFecha.Text     = "Filtrar por fecha:";
            chkFiltroFecha.Location = new Point(10, 15);
            chkFiltroFecha.AutoSize = true;
            chkFiltroFecha.Font     = new Font("Segoe UI", 9);
            chkFiltroFecha.CheckedChanged += chkFiltroFecha_CheckedChanged;

            lblDesde.Text     = "Desde:";
            lblDesde.Location = new Point(155, 16);
            lblDesde.AutoSize = true;
            lblDesde.Font     = new Font("Segoe UI", 9);

            dtpDesde.Location = new Point(200, 12);
            dtpDesde.Size     = new Size(120, 26);
            dtpDesde.Format   = DateTimePickerFormat.Short;
            dtpDesde.Enabled  = false;
            dtpDesde.Value    = DateTime.Today.AddDays(-30);

            lblHasta.Text     = "Hasta:";
            lblHasta.Location = new Point(330, 16);
            lblHasta.AutoSize = true;
            lblHasta.Font     = new Font("Segoe UI", 9);

            dtpHasta.Location = new Point(375, 12);
            dtpHasta.Size     = new Size(120, 26);
            dtpHasta.Format   = DateTimePickerFormat.Short;
            dtpHasta.Enabled  = false;
            dtpHasta.Value    = DateTime.Today;

            ConfigurarBoton(btnRefrescarMovimientos, "🔄 Buscar", new Point(505, 10), Color.FromArgb(30, 30, 60));
            btnRefrescarMovimientos.Click += btnRefrescarMovimientos_Click;

            lblTotalMovimientos.Text      = "";
            lblTotalMovimientos.AutoSize  = true;
            lblTotalMovimientos.Font      = new Font("Segoe UI", 9);
            lblTotalMovimientos.ForeColor = Color.DimGray;
            lblTotalMovimientos.Location  = new Point(630, 16);

            pnlToolKardex.Controls.AddRange(new Control[]
            {
                chkFiltroFecha, lblDesde, dtpDesde, lblHasta, dtpHasta,
                btnRefrescarMovimientos, lblTotalMovimientos
            });

            ConfigurarGrid(dgvMovimientos);
            dgvMovimientos.Dock = DockStyle.Fill;

            tabKardex.Controls.AddRange(new Control[] { dgvMovimientos, pnlToolKardex });

            Controls.Add(tabControl);
        }

        // ─── Helpers de diseño ─────────────────────────────────────────────────
        private static void ConfigurarBoton(Button btn, string texto, Point ubicacion, Color color)
        {
            btn.Text      = texto;
            btn.Location  = ubicacion;
            btn.Size      = new Size(112, 30);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            btn.Cursor    = Cursors.Hand;
        }

        private static void ConfigurarGrid(DataGridView dgv)
        {
            dgv.ReadOnly              = true;
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor       = Color.White;
            dgv.BorderStyle           = BorderStyle.None;
            dgv.RowHeadersVisible     = false;
            dgv.Font                  = new Font("Segoe UI", 9);
            dgv.GridColor             = Color.FromArgb(230, 230, 235);
            dgv.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(30, 30, 60);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(5, 0, 0, 0);
            dgv.EnableHeadersVisualStyles                = false;
            dgv.ColumnHeadersHeight                      = 36;
            dgv.RowTemplate.Height                       = 28;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 242, 248);
        }
    }
}
