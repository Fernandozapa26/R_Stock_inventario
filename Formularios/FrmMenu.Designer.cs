namespace Inventario_Final.Formularios
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Panel  pnlSidebar;
        private Panel  pnlHeader;
        private Panel  pnlAlerta;
        private Panel  pnlContent;
        private Label  lblTitulo;
        private Label  lblBienvenida;
        private Label  lblAlerta;
        private Label  lblVersionInfo;
        private Button btnProductos;
        private Button btnVentas;
        private Button btnInventario;
        private Button btnCerrarSesion;
        private Label  lblWelcomeIcon;
        private Label  lblWelcomeMsg;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar      = new Panel();
            pnlHeader       = new Panel();
            pnlAlerta       = new Panel();
            pnlContent      = new Panel();
            lblTitulo       = new Label();
            lblBienvenida   = new Label();
            lblAlerta       = new Label();
            lblVersionInfo  = new Label();
            btnProductos    = new Button();
            btnVentas       = new Button();
            btnInventario   = new Button();
            btnCerrarSesion = new Button();
            lblWelcomeIcon  = new Label();
            lblWelcomeMsg   = new Label();

            // ── Formulario ──────────────────────────────────────────────────
            Text          = "Stock Manager – Menú Principal";
            Size          = new Size(940, 600);
            MinimumSize   = new Size(800, 500);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor     = Color.FromArgb(245, 247, 250);
            Load         += FrmMenu_Load;

            // ── Sidebar ─────────────────────────────────────────────────────
            pnlSidebar.Dock      = DockStyle.Left;
            pnlSidebar.Width     = 220;
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 60);

            lblTitulo.Text      = "📦 Stock Manager";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font      = new Font("Segoe UI", 13, FontStyle.Bold);
            lblTitulo.Size      = new Size(220, 70);
            lblTitulo.Location  = new Point(0, 0);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            CrearBotonSidebar(btnProductos,    "📦  Productos",          80,  btnProductos_Click);
            CrearBotonSidebar(btnVentas,        "🛒  Ventas",            135, btnVentas_Click);
            CrearBotonSidebar(btnInventario,    "📊  Inventario / Kardex",190, btnInventario_Click);

            btnCerrarSesion.Text      = "🚪  Cerrar Sesión";
            btnCerrarSesion.Location  = new Point(0, 500);
            btnCerrarSesion.Size      = new Size(220, 50);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Font      = new Font("Segoe UI", 10);
            btnCerrarSesion.BackColor = Color.FromArgb(120, 20, 20);
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Padding   = new Padding(18, 0, 0, 0);
            btnCerrarSesion.Cursor    = Cursors.Hand;
            btnCerrarSesion.Click    += btnCerrarSesion_Click;

            lblVersionInfo.Text      = "v1.0  |  2026";
            lblVersionInfo.ForeColor = Color.FromArgb(100, 100, 130);
            lblVersionInfo.Font      = new Font("Segoe UI", 7.5f);
            lblVersionInfo.Location  = new Point(10, 558);
            lblVersionInfo.AutoSize  = true;

            pnlSidebar.Controls.AddRange(new Control[]
            {
                lblTitulo, btnProductos, btnVentas,
                btnInventario, btnCerrarSesion, lblVersionInfo
            });

            // ── Header ──────────────────────────────────────────────────────
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 52;
            pnlHeader.BackColor = Color.White;

            lblBienvenida.Text      = "";
            lblBienvenida.Font      = new Font("Segoe UI", 9);
            lblBienvenida.ForeColor = Color.DimGray;
            lblBienvenida.Dock      = DockStyle.Fill;
            lblBienvenida.TextAlign = ContentAlignment.MiddleLeft;
            lblBienvenida.Padding   = new Padding(18, 0, 0, 0);
            pnlHeader.Controls.Add(lblBienvenida);

            // ── Alerta stock bajo ────────────────────────────────────────────
            pnlAlerta.Dock      = DockStyle.Top;
            pnlAlerta.Height    = 38;
            pnlAlerta.BackColor = Color.FromArgb(255, 243, 205);
            pnlAlerta.Visible   = false;

            lblAlerta.Text      = "";
            lblAlerta.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            lblAlerta.ForeColor = Color.FromArgb(130, 77, 14);
            lblAlerta.Dock      = DockStyle.Fill;
            lblAlerta.TextAlign = ContentAlignment.MiddleLeft;
            lblAlerta.Padding   = new Padding(12, 0, 0, 0);
            pnlAlerta.Controls.Add(lblAlerta);

            // ── Área de contenido central ────────────────────────────────────
            pnlContent.Dock      = DockStyle.Fill;
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Padding   = new Padding(40);

            lblWelcomeIcon.Text      = "📦";
            lblWelcomeIcon.Font      = new Font("Segoe UI", 48);
            lblWelcomeIcon.AutoSize  = true;
            lblWelcomeIcon.Location  = new Point(220, 100);
            lblWelcomeIcon.BackColor = Color.Transparent;

            lblWelcomeMsg.Text      = "Selecciona un módulo del menú lateral para comenzar.";
            lblWelcomeMsg.Font      = new Font("Segoe UI", 13);
            lblWelcomeMsg.ForeColor = Color.FromArgb(120, 120, 140);
            lblWelcomeMsg.AutoSize  = true;
            lblWelcomeMsg.Location  = new Point(80, 200);
            lblWelcomeMsg.BackColor = Color.Transparent;

            pnlContent.Controls.AddRange(new Control[] { lblWelcomeIcon, lblWelcomeMsg });

            Controls.AddRange(new Control[] { pnlContent, pnlAlerta, pnlHeader, pnlSidebar });
        }

        private static void CrearBotonSidebar(Button btn, string texto, int y, EventHandler handler)
        {
            btn.Text      = texto;
            btn.Location  = new Point(0, y);
            btn.Size      = new Size(220, 50);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.Font      = new Font("Segoe UI", 10);
            btn.BackColor = Color.FromArgb(30, 30, 60);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding   = new Padding(18, 0, 0, 0);
            btn.Cursor    = Cursors.Hand;
            btn.Click    += handler;
        }
    }
}
