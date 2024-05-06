namespace ADVIA2120
{
    partial class frmAdvia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvia));
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lstResultados = new System.Windows.Forms.ListView();
            this.colResultado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.ubtnOcultar = new System.Windows.Forms.Button();
            this.ulblPanel = new System.Windows.Forms.Label();
            this.utxtEstatus = new System.Windows.Forms.TextBox();
            this.utxtHandShaking = new System.Windows.Forms.TextBox();
            this.utxtParidad = new System.Windows.Forms.TextBox();
            this.utxtBitsParo = new System.Windows.Forms.TextBox();
            this.utxtBitsDatos = new System.Windows.Forms.TextBox();
            this.utxtVelocidad = new System.Windows.Forms.TextBox();
            this.utxtPuerto = new System.Windows.Forms.TextBox();
            this.utxtEquipo = new System.Windows.Forms.TextBox();
            this.ulblDatosRecibido = new System.Windows.Forms.Label();
            this.ulblBitsParo = new System.Windows.Forms.Label();
            this.ulblBitsDatos = new System.Windows.Forms.Label();
            this.ulblEstatus = new System.Windows.Forms.Label();
            this.ulblEncabezado = new System.Windows.Forms.Label();
            this.ulblVelocidad = new System.Windows.Forms.Label();
            this.ulblHandshaking = new System.Windows.Forms.Label();
            this.ulblParidad = new System.Windows.Forms.Label();
            this.ulblEquipo = new System.Windows.Forms.Label();
            this.ulblPuerto = new System.Windows.Forms.Label();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.savDialog = new System.Windows.Forms.SaveFileDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(572, 328);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(65, 25);
            this.btnCopiar.TabIndex = 175;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(643, 328);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(65, 25);
            this.btnLimpiar.TabIndex = 163;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lstResultados
            // 
            this.lstResultados.BackColor = System.Drawing.Color.Black;
            this.lstResultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResultado});
            this.lstResultados.FullRowSelect = true;
            this.lstResultados.HideSelection = false;
            this.lstResultados.LabelWrap = false;
            this.lstResultados.Location = new System.Drawing.Point(248, 65);
            this.lstResultados.MultiSelect = false;
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.ShowGroups = false;
            this.lstResultados.Size = new System.Drawing.Size(460, 251);
            this.lstResultados.TabIndex = 174;
            this.lstResultados.TileSize = new System.Drawing.Size(168, 30);
            this.lstResultados.UseCompatibleStateImageBehavior = false;
            this.lstResultados.View = System.Windows.Forms.View.Details;
            // 
            // colResultado
            // 
            this.colResultado.Text = "";
            this.colResultado.Width = 500;
            // 
            // gbPanel
            // 
            this.gbPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbPanel.Controls.Add(this.ubtnOcultar);
            this.gbPanel.Controls.Add(this.ulblPanel);
            this.gbPanel.Location = new System.Drawing.Point(20, 270);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(219, 83);
            this.gbPanel.TabIndex = 173;
            this.gbPanel.TabStop = false;
            // 
            // ubtnOcultar
            // 
            this.ubtnOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubtnOcultar.Location = new System.Drawing.Point(18, 32);
            this.ubtnOcultar.Name = "ubtnOcultar";
            this.ubtnOcultar.Size = new System.Drawing.Size(88, 36);
            this.ubtnOcultar.TabIndex = 1;
            this.ubtnOcultar.Text = "Ocultar";
            this.ubtnOcultar.UseVisualStyleBackColor = true;
            this.ubtnOcultar.Click += new System.EventHandler(this.ubtnOcultar_Click);
            // 
            // ulblPanel
            // 
            this.ulblPanel.AutoSize = true;
            this.ulblPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblPanel.ForeColor = System.Drawing.Color.Black;
            this.ulblPanel.Location = new System.Drawing.Point(62, 13);
            this.ulblPanel.Name = "ulblPanel";
            this.ulblPanel.Size = new System.Drawing.Size(83, 13);
            this.ulblPanel.TabIndex = 0;
            this.ulblPanel.Text = "Panel Control";
            // 
            // utxtEstatus
            // 
            this.utxtEstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtEstatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtEstatus.Location = new System.Drawing.Point(94, 244);
            this.utxtEstatus.Name = "utxtEstatus";
            this.utxtEstatus.ReadOnly = true;
            this.utxtEstatus.Size = new System.Drawing.Size(145, 20);
            this.utxtEstatus.TabIndex = 172;
            // 
            // utxtHandShaking
            // 
            this.utxtHandShaking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtHandShaking.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtHandShaking.Location = new System.Drawing.Point(94, 218);
            this.utxtHandShaking.Name = "utxtHandShaking";
            this.utxtHandShaking.ReadOnly = true;
            this.utxtHandShaking.Size = new System.Drawing.Size(145, 20);
            this.utxtHandShaking.TabIndex = 171;
            // 
            // utxtParidad
            // 
            this.utxtParidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtParidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtParidad.Location = new System.Drawing.Point(94, 192);
            this.utxtParidad.Name = "utxtParidad";
            this.utxtParidad.ReadOnly = true;
            this.utxtParidad.Size = new System.Drawing.Size(145, 20);
            this.utxtParidad.TabIndex = 170;
            // 
            // utxtBitsParo
            // 
            this.utxtBitsParo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtBitsParo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtBitsParo.Location = new System.Drawing.Point(94, 166);
            this.utxtBitsParo.Name = "utxtBitsParo";
            this.utxtBitsParo.ReadOnly = true;
            this.utxtBitsParo.Size = new System.Drawing.Size(145, 20);
            this.utxtBitsParo.TabIndex = 169;
            // 
            // utxtBitsDatos
            // 
            this.utxtBitsDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtBitsDatos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtBitsDatos.Location = new System.Drawing.Point(94, 140);
            this.utxtBitsDatos.Name = "utxtBitsDatos";
            this.utxtBitsDatos.ReadOnly = true;
            this.utxtBitsDatos.Size = new System.Drawing.Size(145, 20);
            this.utxtBitsDatos.TabIndex = 168;
            // 
            // utxtVelocidad
            // 
            this.utxtVelocidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtVelocidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtVelocidad.Location = new System.Drawing.Point(94, 114);
            this.utxtVelocidad.Name = "utxtVelocidad";
            this.utxtVelocidad.ReadOnly = true;
            this.utxtVelocidad.Size = new System.Drawing.Size(145, 20);
            this.utxtVelocidad.TabIndex = 167;
            // 
            // utxtPuerto
            // 
            this.utxtPuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtPuerto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtPuerto.Location = new System.Drawing.Point(94, 89);
            this.utxtPuerto.Name = "utxtPuerto";
            this.utxtPuerto.ReadOnly = true;
            this.utxtPuerto.Size = new System.Drawing.Size(145, 20);
            this.utxtPuerto.TabIndex = 166;
            // 
            // utxtEquipo
            // 
            this.utxtEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtEquipo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtEquipo.Location = new System.Drawing.Point(94, 65);
            this.utxtEquipo.Name = "utxtEquipo";
            this.utxtEquipo.ReadOnly = true;
            this.utxtEquipo.Size = new System.Drawing.Size(145, 20);
            this.utxtEquipo.TabIndex = 165;
            // 
            // ulblDatosRecibido
            // 
            this.ulblDatosRecibido.AutoSize = true;
            this.ulblDatosRecibido.BackColor = System.Drawing.Color.Transparent;
            this.ulblDatosRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblDatosRecibido.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblDatosRecibido.Location = new System.Drawing.Point(244, 41);
            this.ulblDatosRecibido.Name = "ulblDatosRecibido";
            this.ulblDatosRecibido.Size = new System.Drawing.Size(138, 20);
            this.ulblDatosRecibido.TabIndex = 164;
            this.ulblDatosRecibido.Text = "Datos Recibidos ";
            // 
            // ulblBitsParo
            // 
            this.ulblBitsParo.AutoSize = true;
            this.ulblBitsParo.BackColor = System.Drawing.Color.Transparent;
            this.ulblBitsParo.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblBitsParo.Location = new System.Drawing.Point(17, 170);
            this.ulblBitsParo.Name = "ulblBitsParo";
            this.ulblBitsParo.Size = new System.Drawing.Size(49, 13);
            this.ulblBitsParo.TabIndex = 162;
            this.ulblBitsParo.Text = "Bits Paro";
            // 
            // ulblBitsDatos
            // 
            this.ulblBitsDatos.AutoSize = true;
            this.ulblBitsDatos.BackColor = System.Drawing.Color.Transparent;
            this.ulblBitsDatos.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblBitsDatos.Location = new System.Drawing.Point(17, 144);
            this.ulblBitsDatos.Name = "ulblBitsDatos";
            this.ulblBitsDatos.Size = new System.Drawing.Size(55, 13);
            this.ulblBitsDatos.TabIndex = 161;
            this.ulblBitsDatos.Text = "Bits Datos";
            // 
            // ulblEstatus
            // 
            this.ulblEstatus.AutoSize = true;
            this.ulblEstatus.BackColor = System.Drawing.Color.Transparent;
            this.ulblEstatus.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblEstatus.Location = new System.Drawing.Point(16, 249);
            this.ulblEstatus.Name = "ulblEstatus";
            this.ulblEstatus.Size = new System.Drawing.Size(42, 13);
            this.ulblEstatus.TabIndex = 160;
            this.ulblEstatus.Text = "Estatus";
            // 
            // ulblEncabezado
            // 
            this.ulblEncabezado.AutoSize = true;
            this.ulblEncabezado.BackColor = System.Drawing.Color.Transparent;
            this.ulblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblEncabezado.ForeColor = System.Drawing.Color.White;
            this.ulblEncabezado.Location = new System.Drawing.Point(14, 21);
            this.ulblEncabezado.Name = "ulblEncabezado";
            this.ulblEncabezado.Size = new System.Drawing.Size(101, 31);
            this.ulblEncabezado.TabIndex = 158;
            this.ulblEncabezado.Text = "ADVIA";
            // 
            // ulblVelocidad
            // 
            this.ulblVelocidad.AutoSize = true;
            this.ulblVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.ulblVelocidad.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblVelocidad.Location = new System.Drawing.Point(16, 118);
            this.ulblVelocidad.Name = "ulblVelocidad";
            this.ulblVelocidad.Size = new System.Drawing.Size(54, 13);
            this.ulblVelocidad.TabIndex = 157;
            this.ulblVelocidad.Text = "Velocidad";
            // 
            // ulblHandshaking
            // 
            this.ulblHandshaking.AutoSize = true;
            this.ulblHandshaking.BackColor = System.Drawing.Color.Transparent;
            this.ulblHandshaking.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblHandshaking.Location = new System.Drawing.Point(16, 223);
            this.ulblHandshaking.Name = "ulblHandshaking";
            this.ulblHandshaking.Size = new System.Drawing.Size(70, 13);
            this.ulblHandshaking.TabIndex = 156;
            this.ulblHandshaking.Text = "Handshaking";
            // 
            // ulblParidad
            // 
            this.ulblParidad.AutoSize = true;
            this.ulblParidad.BackColor = System.Drawing.Color.Transparent;
            this.ulblParidad.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblParidad.Location = new System.Drawing.Point(16, 197);
            this.ulblParidad.Name = "ulblParidad";
            this.ulblParidad.Size = new System.Drawing.Size(43, 13);
            this.ulblParidad.TabIndex = 155;
            this.ulblParidad.Text = "Paridad";
            // 
            // ulblEquipo
            // 
            this.ulblEquipo.AutoSize = true;
            this.ulblEquipo.BackColor = System.Drawing.Color.Transparent;
            this.ulblEquipo.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblEquipo.Location = new System.Drawing.Point(16, 65);
            this.ulblEquipo.Name = "ulblEquipo";
            this.ulblEquipo.Size = new System.Drawing.Size(43, 13);
            this.ulblEquipo.TabIndex = 154;
            this.ulblEquipo.Text = "Equipo ";
            // 
            // ulblPuerto
            // 
            this.ulblPuerto.AutoSize = true;
            this.ulblPuerto.BackColor = System.Drawing.Color.Transparent;
            this.ulblPuerto.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblPuerto.Location = new System.Drawing.Point(16, 92);
            this.ulblPuerto.Name = "ulblPuerto";
            this.ulblPuerto.Size = new System.Drawing.Size(38, 13);
            this.ulblPuerto.TabIndex = 153;
            this.ulblPuerto.Text = "Puerto";
            // 
            // port
            // 
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "ADVIA2120";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReiniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(501, 328);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(65, 25);
            this.btnReiniciar.TabIndex = 176;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmAdvia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(730, 396);
            this.ControlBox = false;
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lstResultados);
            this.Controls.Add(this.gbPanel);
            this.Controls.Add(this.utxtEstatus);
            this.Controls.Add(this.utxtHandShaking);
            this.Controls.Add(this.utxtParidad);
            this.Controls.Add(this.utxtBitsParo);
            this.Controls.Add(this.utxtBitsDatos);
            this.Controls.Add(this.utxtVelocidad);
            this.Controls.Add(this.utxtPuerto);
            this.Controls.Add(this.utxtEquipo);
            this.Controls.Add(this.ulblDatosRecibido);
            this.Controls.Add(this.ulblBitsParo);
            this.Controls.Add(this.ulblBitsDatos);
            this.Controls.Add(this.ulblEstatus);
            this.Controls.Add(this.ulblEncabezado);
            this.Controls.Add(this.ulblVelocidad);
            this.Controls.Add(this.ulblHandshaking);
            this.Controls.Add(this.ulblParidad);
            this.Controls.Add(this.ulblEquipo);
            this.Controls.Add(this.ulblPuerto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdvia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Shown += new System.EventHandler(this.frm_shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_MouseUp);
            this.gbPanel.ResumeLayout(false);
            this.gbPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListView lstResultados;
        private System.Windows.Forms.ColumnHeader colResultado;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.Button ubtnOcultar;
        private System.Windows.Forms.Label ulblPanel;
        private System.Windows.Forms.TextBox utxtEstatus;
        private System.Windows.Forms.TextBox utxtHandShaking;
        private System.Windows.Forms.TextBox utxtParidad;
        private System.Windows.Forms.TextBox utxtBitsParo;
        private System.Windows.Forms.TextBox utxtBitsDatos;
        private System.Windows.Forms.TextBox utxtVelocidad;
        private System.Windows.Forms.TextBox utxtPuerto;
        private System.Windows.Forms.TextBox utxtEquipo;
        internal System.Windows.Forms.Label ulblDatosRecibido;
        internal System.Windows.Forms.Label ulblBitsParo;
        internal System.Windows.Forms.Label ulblBitsDatos;
        internal System.Windows.Forms.Label ulblEstatus;
        private System.Windows.Forms.Label ulblEncabezado;
        internal System.Windows.Forms.Label ulblVelocidad;
        internal System.Windows.Forms.Label ulblHandshaking;
        internal System.Windows.Forms.Label ulblParidad;
        internal System.Windows.Forms.Label ulblEquipo;
        internal System.Windows.Forms.Label ulblPuerto;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.SaveFileDialog savDialog;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Timer timer;
    }
}

