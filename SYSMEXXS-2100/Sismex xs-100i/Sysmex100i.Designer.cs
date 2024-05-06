namespace Sismex_xs_100i
{
    partial class Sysmex100i
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        string _argumentos = string.Empty;
        /// <summary>
        /// 
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
        /// 
        public Sysmex100i(string[] args)
        {
          
            InitializeComponent();
            if (args != null)
            {
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    if (_argumentos != string.Empty) _argumentos += "";
                    _argumentos += args[i];
                 }
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sysmex100i));
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstResultados = new System.Windows.Forms.ListView();
            this.colResultado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ubtnOcultar = new System.Windows.Forms.Button();
            this.utbnCerrar = new System.Windows.Forms.Button();
            this.lblPanel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.utxtEquipo = new System.Windows.Forms.TextBox();
            this.utxtPuerto = new System.Windows.Forms.TextBox();
            this.utxtVelocidad = new System.Windows.Forms.TextBox();
            this.utxtBitsDatos = new System.Windows.Forms.TextBox();
            this.utxtBitsParo = new System.Windows.Forms.TextBox();
            this.utxtParidad = new System.Windows.Forms.TextBox();
            this.utxtHandShaking = new System.Windows.Forms.TextBox();
            this.utxtEstatus = new System.Windows.Forms.TextBox();
            this.ulblBitsParo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ulblEstatus = new System.Windows.Forms.Label();
            this.ulblVelocidad = new System.Windows.Forms.Label();
            this.ulblHandshaking = new System.Windows.Forms.Label();
            this.ulblParidad = new System.Windows.Forms.Label();
            this.ulblEquipo = new System.Windows.Forms.Label();
            this.ulblPuerto = new System.Windows.Forms.Label();
            this.savDialog = new System.Windows.Forms.SaveFileDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.PortName = "COM2";
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sismex_xs_100i.Properties.Resources._default;
            this.pictureBox1.Location = new System.Drawing.Point(765, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 105;
            this.pictureBox1.TabStop = false;
            // 
            // lstResultados
            // 
            this.lstResultados.BackColor = System.Drawing.Color.Black;
            this.lstResultados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colResultado});
            this.lstResultados.FullRowSelect = true;
            this.lstResultados.HideSelection = false;
            this.lstResultados.LabelWrap = false;
            this.lstResultados.Location = new System.Drawing.Point(337, 70);
            this.lstResultados.Margin = new System.Windows.Forms.Padding(4);
            this.lstResultados.MultiSelect = false;
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.ShowGroups = false;
            this.lstResultados.Size = new System.Drawing.Size(560, 352);
            this.lstResultados.TabIndex = 104;
            this.lstResultados.TileSize = new System.Drawing.Size(168, 30);
            this.lstResultados.UseCompatibleStateImageBehavior = false;
            this.lstResultados.View = System.Windows.Forms.View.Details;
            // 
            // colResultado
            // 
            this.colResultado.Text = "";
            this.colResultado.Width = 500;
            // 
            // btnCopiar
            // 
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(720, 431);
            this.btnCopiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(87, 31);
            this.btnCopiar.TabIndex = 103;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(812, 431);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 31);
            this.btnLimpiar.TabIndex = 102;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SeaShell;
            this.label3.Location = new System.Drawing.Point(332, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 25);
            this.label3.TabIndex = 101;
            this.label3.Text = "Datos Recibidos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ubtnOcultar);
            this.panel1.Controls.Add(this.utbnCerrar);
            this.panel1.Controls.Add(this.lblPanel);
            this.panel1.Location = new System.Drawing.Point(48, 332);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 91);
            this.panel1.TabIndex = 100;
            // 
            // ubtnOcultar
            // 
            this.ubtnOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubtnOcultar.ForeColor = System.Drawing.Color.Black;
            this.ubtnOcultar.Location = new System.Drawing.Point(17, 31);
            this.ubtnOcultar.Margin = new System.Windows.Forms.Padding(4);
            this.ubtnOcultar.Name = "ubtnOcultar";
            this.ubtnOcultar.Size = new System.Drawing.Size(117, 41);
            this.ubtnOcultar.TabIndex = 2;
            this.ubtnOcultar.Text = "Ocultar";
            this.ubtnOcultar.UseVisualStyleBackColor = true;
            this.ubtnOcultar.Click += new System.EventHandler(this.ubtnOcultar_Click);
            // 
            // utbnCerrar
            // 
            this.utbnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utbnCerrar.ForeColor = System.Drawing.Color.Black;
            this.utbnCerrar.Location = new System.Drawing.Point(143, 31);
            this.utbnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.utbnCerrar.Name = "utbnCerrar";
            this.utbnCerrar.Size = new System.Drawing.Size(117, 41);
            this.utbnCerrar.TabIndex = 1;
            this.utbnCerrar.Text = "Cerrar";
            this.utbnCerrar.UseVisualStyleBackColor = true;
            this.utbnCerrar.Click += new System.EventHandler(this.utbnCerrar_Click);
            // 
            // lblPanel
            // 
            this.lblPanel.AutoSize = true;
            this.lblPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanel.ForeColor = System.Drawing.Color.Black;
            this.lblPanel.Location = new System.Drawing.Point(81, 11);
            this.lblPanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(106, 17);
            this.lblPanel.TabIndex = 0;
            this.lblPanel.Text = "Panel Control";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(41, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 31);
            this.label5.TabIndex = 99;
            this.label5.Text = "SYSMEX XE 2100";
            // 
            // utxtEquipo
            // 
            this.utxtEquipo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtEquipo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtEquipo.Location = new System.Drawing.Point(148, 75);
            this.utxtEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.utxtEquipo.Name = "utxtEquipo";
            this.utxtEquipo.ReadOnly = true;
            this.utxtEquipo.Size = new System.Drawing.Size(181, 22);
            this.utxtEquipo.TabIndex = 98;
            // 
            // utxtPuerto
            // 
            this.utxtPuerto.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtPuerto.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtPuerto.Location = new System.Drawing.Point(148, 107);
            this.utxtPuerto.Margin = new System.Windows.Forms.Padding(4);
            this.utxtPuerto.Name = "utxtPuerto";
            this.utxtPuerto.ReadOnly = true;
            this.utxtPuerto.Size = new System.Drawing.Size(181, 22);
            this.utxtPuerto.TabIndex = 97;
            // 
            // utxtVelocidad
            // 
            this.utxtVelocidad.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtVelocidad.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtVelocidad.Location = new System.Drawing.Point(148, 140);
            this.utxtVelocidad.Margin = new System.Windows.Forms.Padding(4);
            this.utxtVelocidad.Name = "utxtVelocidad";
            this.utxtVelocidad.ReadOnly = true;
            this.utxtVelocidad.Size = new System.Drawing.Size(181, 22);
            this.utxtVelocidad.TabIndex = 96;
            // 
            // utxtBitsDatos
            // 
            this.utxtBitsDatos.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtBitsDatos.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtBitsDatos.Location = new System.Drawing.Point(148, 172);
            this.utxtBitsDatos.Margin = new System.Windows.Forms.Padding(4);
            this.utxtBitsDatos.Name = "utxtBitsDatos";
            this.utxtBitsDatos.ReadOnly = true;
            this.utxtBitsDatos.Size = new System.Drawing.Size(181, 22);
            this.utxtBitsDatos.TabIndex = 95;
            // 
            // utxtBitsParo
            // 
            this.utxtBitsParo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtBitsParo.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtBitsParo.Location = new System.Drawing.Point(148, 204);
            this.utxtBitsParo.Margin = new System.Windows.Forms.Padding(4);
            this.utxtBitsParo.Name = "utxtBitsParo";
            this.utxtBitsParo.ReadOnly = true;
            this.utxtBitsParo.Size = new System.Drawing.Size(181, 22);
            this.utxtBitsParo.TabIndex = 94;
            // 
            // utxtParidad
            // 
            this.utxtParidad.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtParidad.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtParidad.Location = new System.Drawing.Point(148, 236);
            this.utxtParidad.Margin = new System.Windows.Forms.Padding(4);
            this.utxtParidad.Name = "utxtParidad";
            this.utxtParidad.ReadOnly = true;
            this.utxtParidad.Size = new System.Drawing.Size(181, 22);
            this.utxtParidad.TabIndex = 93;
            // 
            // utxtHandShaking
            // 
            this.utxtHandShaking.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtHandShaking.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtHandShaking.Location = new System.Drawing.Point(148, 268);
            this.utxtHandShaking.Margin = new System.Windows.Forms.Padding(4);
            this.utxtHandShaking.Name = "utxtHandShaking";
            this.utxtHandShaking.ReadOnly = true;
            this.utxtHandShaking.Size = new System.Drawing.Size(181, 22);
            this.utxtHandShaking.TabIndex = 92;
            // 
            // utxtEstatus
            // 
            this.utxtEstatus.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.utxtEstatus.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.utxtEstatus.Location = new System.Drawing.Point(148, 300);
            this.utxtEstatus.Margin = new System.Windows.Forms.Padding(4);
            this.utxtEstatus.Name = "utxtEstatus";
            this.utxtEstatus.ReadOnly = true;
            this.utxtEstatus.Size = new System.Drawing.Size(181, 22);
            this.utxtEstatus.TabIndex = 91;
            // 
            // ulblBitsParo
            // 
            this.ulblBitsParo.AutoSize = true;
            this.ulblBitsParo.BackColor = System.Drawing.Color.Transparent;
            this.ulblBitsParo.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblBitsParo.Location = new System.Drawing.Point(45, 212);
            this.ulblBitsParo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblBitsParo.Name = "ulblBitsParo";
            this.ulblBitsParo.Size = new System.Drawing.Size(65, 17);
            this.ulblBitsParo.TabIndex = 90;
            this.ulblBitsParo.Text = "Bits Paro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.SeaShell;
            this.label1.Location = new System.Drawing.Point(45, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 89;
            this.label1.Text = "Bits Datos";
            // 
            // ulblEstatus
            // 
            this.ulblEstatus.AutoSize = true;
            this.ulblEstatus.BackColor = System.Drawing.Color.Transparent;
            this.ulblEstatus.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblEstatus.Location = new System.Drawing.Point(44, 306);
            this.ulblEstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblEstatus.Name = "ulblEstatus";
            this.ulblEstatus.Size = new System.Drawing.Size(55, 17);
            this.ulblEstatus.TabIndex = 88;
            this.ulblEstatus.Text = "Estatus";
            // 
            // ulblVelocidad
            // 
            this.ulblVelocidad.AutoSize = true;
            this.ulblVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.ulblVelocidad.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblVelocidad.Location = new System.Drawing.Point(44, 144);
            this.ulblVelocidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblVelocidad.Name = "ulblVelocidad";
            this.ulblVelocidad.Size = new System.Drawing.Size(70, 17);
            this.ulblVelocidad.TabIndex = 87;
            this.ulblVelocidad.Text = "Velocidad";
            // 
            // ulblHandshaking
            // 
            this.ulblHandshaking.AutoSize = true;
            this.ulblHandshaking.BackColor = System.Drawing.Color.Transparent;
            this.ulblHandshaking.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblHandshaking.Location = new System.Drawing.Point(44, 273);
            this.ulblHandshaking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblHandshaking.Name = "ulblHandshaking";
            this.ulblHandshaking.Size = new System.Drawing.Size(91, 17);
            this.ulblHandshaking.TabIndex = 86;
            this.ulblHandshaking.Text = "Handshaking";
            // 
            // ulblParidad
            // 
            this.ulblParidad.AutoSize = true;
            this.ulblParidad.BackColor = System.Drawing.Color.Transparent;
            this.ulblParidad.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblParidad.Location = new System.Drawing.Point(44, 244);
            this.ulblParidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblParidad.Name = "ulblParidad";
            this.ulblParidad.Size = new System.Drawing.Size(57, 17);
            this.ulblParidad.TabIndex = 85;
            this.ulblParidad.Text = "Paridad";
            // 
            // ulblEquipo
            // 
            this.ulblEquipo.AutoSize = true;
            this.ulblEquipo.BackColor = System.Drawing.Color.Transparent;
            this.ulblEquipo.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblEquipo.Location = new System.Drawing.Point(44, 78);
            this.ulblEquipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblEquipo.Name = "ulblEquipo";
            this.ulblEquipo.Size = new System.Drawing.Size(56, 17);
            this.ulblEquipo.TabIndex = 84;
            this.ulblEquipo.Text = "Equipo ";
            // 
            // ulblPuerto
            // 
            this.ulblPuerto.AutoSize = true;
            this.ulblPuerto.BackColor = System.Drawing.Color.Transparent;
            this.ulblPuerto.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblPuerto.Location = new System.Drawing.Point(44, 111);
            this.ulblPuerto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblPuerto.Name = "ulblPuerto";
            this.ulblPuerto.Size = new System.Drawing.Size(50, 17);
            this.ulblPuerto.TabIndex = 83;
            this.ulblPuerto.Text = "Puerto";
            // 
            // savDialog
            // 
            this.savDialog.Filter = "txt files (*.txt)|*.txt\"";
            this.savDialog.Title = "Seleccione el archivo a guardar";
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "SYSMEX XE 2100";
            this.trayIcon.Visible = true;
            this.trayIcon.Click += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // Sysmex100i
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(931, 476);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstResultados);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.utxtEquipo);
            this.Controls.Add(this.utxtPuerto);
            this.Controls.Add(this.utxtVelocidad);
            this.Controls.Add(this.utxtBitsDatos);
            this.Controls.Add(this.utxtBitsParo);
            this.Controls.Add(this.utxtParidad);
            this.Controls.Add(this.utxtHandShaking);
            this.Controls.Add(this.utxtEstatus);
            this.Controls.Add(this.ulblBitsParo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ulblEstatus);
            this.Controls.Add(this.ulblVelocidad);
            this.Controls.Add(this.ulblHandshaking);
            this.Controls.Add(this.ulblParidad);
            this.Controls.Add(this.ulblEquipo);
            this.Controls.Add(this.ulblPuerto);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Sysmex100i";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYSMEX EX 2100";
            this.Shown += new System.EventHandler(this.frmCobas_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lstResultados;
        private System.Windows.Forms.ColumnHeader colResultado;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnLimpiar;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ubtnOcultar;
        private System.Windows.Forms.Button utbnCerrar;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox utxtEquipo;
        private System.Windows.Forms.TextBox utxtPuerto;
        private System.Windows.Forms.TextBox utxtVelocidad;
        private System.Windows.Forms.TextBox utxtBitsDatos;
        private System.Windows.Forms.TextBox utxtBitsParo;
        private System.Windows.Forms.TextBox utxtParidad;
        private System.Windows.Forms.TextBox utxtHandShaking;
        private System.Windows.Forms.TextBox utxtEstatus;
        internal System.Windows.Forms.Label ulblBitsParo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label ulblEstatus;
        internal System.Windows.Forms.Label ulblVelocidad;
        internal System.Windows.Forms.Label ulblHandshaking;
        internal System.Windows.Forms.Label ulblParidad;
        internal System.Windows.Forms.Label ulblEquipo;
        internal System.Windows.Forms.Label ulblPuerto;
        private System.Windows.Forms.SaveFileDialog savDialog;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}

