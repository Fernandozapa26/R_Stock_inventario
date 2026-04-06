namespace Inventario_Final.Formularios
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        private Panel   pnlHeader;
        private Label   lblTitulo;
        private Label   lblSubtitulo;
        private Panel   pnlBody;
        private Label   lblUsuarioLbl;
        private TextBox txtUsuario;
        private Label   lblClaveLbl;
        private TextBox txtClave;
        private Label   lblError;
        private Button  btnIngresar;
        private Button  btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader    = new Panel();
            lblTitulo    = new Label();
            lblSubtitulo = new Label();
            pnlBody      = new Panel();
            lblUsuarioLbl= new Label();
            txtUsuario   = new TextBox();
            lblClaveLbl  = new Label();
            txtClave     = new TextBox();
            lblError     = new Label();
            btnIngresar  = new Button();
            btnCancelar  = new Button();

            // ── Formulario ──────────────────────────────────────────────────
            Text            = "Stock Manager – Inicio de Sesión";
            Size            = new Size(400, 480);
            StartPosition   = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            BackColor       = Color.WhiteSmoke;
            AcceptButton    = btnIngresar;
            CancelButton    = btnCancelar;

            // ── Header ──────────────────────────────────────────────────────
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 100;
            pnlHeader.BackColor = Color.FromArgb(30, 30, 60);

            lblTitulo.Text      = "📦 Stock Manager";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font      = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.AutoSize  = true;
            lblTitulo.Location  = new Point(20, 15);

            lblSubtitulo.Text      = "Sistema de Control de Inventario";
            lblSubtitulo.ForeColor = Color.LightSteelBlue;
            lblSubtitulo.Font      = new Font("Segoe UI", 9);
            lblSubtitulo.AutoSize  = true;
            lblSubtitulo.Location  = new Point(22, 55);

            pnlHeader.Controls.AddRange(new Control[] { lblTitulo, lblSubtitulo });

            // ── Body ────────────────────────────────────────────────────────
            pnlBody.Location  = new Point(30, 120);
            pnlBody.Size      = new Size(330, 310);
            pnlBody.BackColor = Color.WhiteSmoke;

            lblUsuarioLbl.Text     = "Usuario";
            lblUsuarioLbl.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
            lblUsuarioLbl.Location = new Point(0, 10);
            lblUsuarioLbl.AutoSize = true;

            txtUsuario.Location         = new Point(0, 30);
            txtUsuario.Size             = new Size(330, 28);
            txtUsuario.Font             = new Font("Segoe UI", 10);
            txtUsuario.PlaceholderText  = "Ingrese su usuario";

            lblClaveLbl.Text     = "Contraseña";
            lblClaveLbl.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
            lblClaveLbl.Location = new Point(0, 75);
            lblClaveLbl.AutoSize = true;

            txtClave.Location              = new Point(0, 95);
            txtClave.Size                  = new Size(330, 28);
            txtClave.Font                  = new Font("Segoe UI", 10);
            txtClave.UseSystemPasswordChar = true;
            txtClave.PlaceholderText       = "Ingrese su contraseña";
            txtClave.KeyDown              += txtClave_KeyDown;

            lblError.Text      = "";
            lblError.ForeColor = Color.Crimson;
            lblError.Font      = new Font("Segoe UI", 8.5f);
            lblError.Location  = new Point(0, 135);
            lblError.Size      = new Size(330, 35);
            lblError.Visible   = false;

            btnIngresar.Text      = "Ingresar";
            btnIngresar.Location  = new Point(0, 180);
            btnIngresar.Size      = new Size(155, 40);
            btnIngresar.BackColor = Color.FromArgb(30, 30, 60);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Font      = new Font("Segoe UI", 10, FontStyle.Bold);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.Cursor    = Cursors.Hand;
            btnIngresar.Click    += btnIngresar_Click;

            btnCancelar.Text      = "Cancelar";
            btnCancelar.Location  = new Point(170, 180);
            btnCancelar.Size      = new Size(160, 40);
            btnCancelar.BackColor = Color.Gainsboro;
            btnCancelar.ForeColor = Color.DimGray;
            btnCancelar.Font      = new Font("Segoe UI", 10);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Cursor    = Cursors.Hand;
            btnCancelar.Click    += btnCancelar_Click;

            pnlBody.Controls.AddRange(new Control[]
            {
                lblUsuarioLbl, txtUsuario,
                lblClaveLbl,   txtClave,
                lblError,
                btnIngresar,   btnCancelar
            });

            Controls.AddRange(new Control[] { pnlHeader, pnlBody });
        }
    }
}
