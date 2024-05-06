namespace DIMENSIONRL
{
    partial class frmDimension
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDimension));
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lstResultados = new System.Windows.Forms.ListView();
            this.colResultado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.ubtnCerrar = new System.Windows.Forms.Button();
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
            this.rdUrgente = new System.Windows.Forms.RadioButton();
            this.rdRutina = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(763, 442);
            this.btnCopiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(87, 31);
            this.btnCopiar.TabIndex = 175;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(857, 442);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 31);
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
            this.lstResultados.Location = new System.Drawing.Point(331, 80);
            this.lstResultados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstResultados.MultiSelect = false;
            this.lstResultados.Name = "lstResultados";
            this.lstResultados.ShowGroups = false;
            this.lstResultados.Size = new System.Drawing.Size(612, 308);
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
            this.gbPanel.Controls.Add(this.ubtnCerrar);
            this.gbPanel.Controls.Add(this.ubtnOcultar);
            this.gbPanel.Controls.Add(this.ulblPanel);
            this.gbPanel.Location = new System.Drawing.Point(27, 332);
            this.gbPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPanel.Size = new System.Drawing.Size(292, 102);
            this.gbPanel.TabIndex = 173;
            this.gbPanel.TabStop = false;
            // 
            // ubtnCerrar
            // 
            this.ubtnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubtnCerrar.Location = new System.Drawing.Point(149, 39);
            this.ubtnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ubtnCerrar.Name = "ubtnCerrar";
            this.ubtnCerrar.Size = new System.Drawing.Size(117, 44);
            this.ubtnCerrar.TabIndex = 61;
            this.ubtnCerrar.Text = "Cerrar";
            this.ubtnCerrar.UseVisualStyleBackColor = true;
            this.ubtnCerrar.Click += new System.EventHandler(this.utbnCerrar_Click);
            // 
            // ubtnOcultar
            // 
            this.ubtnOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubtnOcultar.Location = new System.Drawing.Point(24, 39);
            this.ubtnOcultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ubtnOcultar.Name = "ubtnOcultar";
            this.ubtnOcultar.Size = new System.Drawing.Size(117, 44);
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
            this.ulblPanel.Location = new System.Drawing.Point(83, 16);
            this.ulblPanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblPanel.Name = "ulblPanel";
            this.ulblPanel.Size = new System.Drawing.Size(106, 17);
            this.ulblPanel.TabIndex = 0;
            this.ulblPanel.Text = "Panel Control";
            // 
            // utxtEstatus
            // 
            this.utxtEstatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtEstatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtEstatus.Location = new System.Drawing.Point(125, 300);
            this.utxtEstatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtEstatus.Name = "utxtEstatus";
            this.utxtEstatus.ReadOnly = true;
            this.utxtEstatus.Size = new System.Drawing.Size(192, 22);
            this.utxtEstatus.TabIndex = 172;
            // 
            // utxtHandShaking
            // 
            this.utxtHandShaking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtHandShaking.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtHandShaking.Location = new System.Drawing.Point(125, 268);
            this.utxtHandShaking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtHandShaking.Name = "utxtHandShaking";
            this.utxtHandShaking.ReadOnly = true;
            this.utxtHandShaking.Size = new System.Drawing.Size(192, 22);
            this.utxtHandShaking.TabIndex = 171;
            // 
            // utxtParidad
            // 
            this.utxtParidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtParidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtParidad.Location = new System.Drawing.Point(125, 236);
            this.utxtParidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtParidad.Name = "utxtParidad";
            this.utxtParidad.ReadOnly = true;
            this.utxtParidad.Size = new System.Drawing.Size(192, 22);
            this.utxtParidad.TabIndex = 170;
            // 
            // utxtBitsParo
            // 
            this.utxtBitsParo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtBitsParo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtBitsParo.Location = new System.Drawing.Point(125, 204);
            this.utxtBitsParo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtBitsParo.Name = "utxtBitsParo";
            this.utxtBitsParo.ReadOnly = true;
            this.utxtBitsParo.Size = new System.Drawing.Size(192, 22);
            this.utxtBitsParo.TabIndex = 169;
            // 
            // utxtBitsDatos
            // 
            this.utxtBitsDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtBitsDatos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtBitsDatos.Location = new System.Drawing.Point(125, 172);
            this.utxtBitsDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtBitsDatos.Name = "utxtBitsDatos";
            this.utxtBitsDatos.ReadOnly = true;
            this.utxtBitsDatos.Size = new System.Drawing.Size(192, 22);
            this.utxtBitsDatos.TabIndex = 168;
            // 
            // utxtVelocidad
            // 
            this.utxtVelocidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtVelocidad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtVelocidad.Location = new System.Drawing.Point(125, 140);
            this.utxtVelocidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtVelocidad.Name = "utxtVelocidad";
            this.utxtVelocidad.ReadOnly = true;
            this.utxtVelocidad.Size = new System.Drawing.Size(192, 22);
            this.utxtVelocidad.TabIndex = 167;
            // 
            // utxtPuerto
            // 
            this.utxtPuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtPuerto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtPuerto.Location = new System.Drawing.Point(125, 110);
            this.utxtPuerto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtPuerto.Name = "utxtPuerto";
            this.utxtPuerto.ReadOnly = true;
            this.utxtPuerto.Size = new System.Drawing.Size(192, 22);
            this.utxtPuerto.TabIndex = 166;
            // 
            // utxtEquipo
            // 
            this.utxtEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.utxtEquipo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.utxtEquipo.Location = new System.Drawing.Point(125, 80);
            this.utxtEquipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.utxtEquipo.Name = "utxtEquipo";
            this.utxtEquipo.ReadOnly = true;
            this.utxtEquipo.Size = new System.Drawing.Size(192, 22);
            this.utxtEquipo.TabIndex = 165;
            // 
            // ulblDatosRecibido
            // 
            this.ulblDatosRecibido.AutoSize = true;
            this.ulblDatosRecibido.BackColor = System.Drawing.Color.Transparent;
            this.ulblDatosRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblDatosRecibido.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblDatosRecibido.Location = new System.Drawing.Point(325, 50);
            this.ulblDatosRecibido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblDatosRecibido.Name = "ulblDatosRecibido";
            this.ulblDatosRecibido.Size = new System.Drawing.Size(177, 26);
            this.ulblDatosRecibido.TabIndex = 164;
            this.ulblDatosRecibido.Text = "Datos Recibidos ";
            // 
            // ulblBitsParo
            // 
            this.ulblBitsParo.AutoSize = true;
            this.ulblBitsParo.BackColor = System.Drawing.Color.Transparent;
            this.ulblBitsParo.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblBitsParo.Location = new System.Drawing.Point(23, 209);
            this.ulblBitsParo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblBitsParo.Name = "ulblBitsParo";
            this.ulblBitsParo.Size = new System.Drawing.Size(65, 17);
            this.ulblBitsParo.TabIndex = 162;
            this.ulblBitsParo.Text = "Bits Paro";
            // 
            // ulblBitsDatos
            // 
            this.ulblBitsDatos.AutoSize = true;
            this.ulblBitsDatos.BackColor = System.Drawing.Color.Transparent;
            this.ulblBitsDatos.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblBitsDatos.Location = new System.Drawing.Point(23, 177);
            this.ulblBitsDatos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblBitsDatos.Name = "ulblBitsDatos";
            this.ulblBitsDatos.Size = new System.Drawing.Size(72, 17);
            this.ulblBitsDatos.TabIndex = 161;
            this.ulblBitsDatos.Text = "Bits Datos";
            // 
            // ulblEstatus
            // 
            this.ulblEstatus.AutoSize = true;
            this.ulblEstatus.BackColor = System.Drawing.Color.Transparent;
            this.ulblEstatus.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblEstatus.Location = new System.Drawing.Point(21, 306);
            this.ulblEstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblEstatus.Name = "ulblEstatus";
            this.ulblEstatus.Size = new System.Drawing.Size(55, 17);
            this.ulblEstatus.TabIndex = 160;
            this.ulblEstatus.Text = "Estatus";
            // 
            // ulblEncabezado
            // 
            this.ulblEncabezado.AutoSize = true;
            this.ulblEncabezado.BackColor = System.Drawing.Color.Transparent;
            this.ulblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblEncabezado.ForeColor = System.Drawing.Color.Firebrick;
            this.ulblEncabezado.Location = new System.Drawing.Point(19, 26);
            this.ulblEncabezado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblEncabezado.Name = "ulblEncabezado";
            this.ulblEncabezado.Size = new System.Drawing.Size(277, 39);
            this.ulblEncabezado.TabIndex = 158;
            this.ulblEncabezado.Text = "DIMENSION RL";
            // 
            // ulblVelocidad
            // 
            this.ulblVelocidad.AutoSize = true;
            this.ulblVelocidad.BackColor = System.Drawing.Color.Transparent;
            this.ulblVelocidad.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblVelocidad.Location = new System.Drawing.Point(21, 145);
            this.ulblVelocidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblVelocidad.Name = "ulblVelocidad";
            this.ulblVelocidad.Size = new System.Drawing.Size(70, 17);
            this.ulblVelocidad.TabIndex = 157;
            this.ulblVelocidad.Text = "Velocidad";
            // 
            // ulblHandshaking
            // 
            this.ulblHandshaking.AutoSize = true;
            this.ulblHandshaking.BackColor = System.Drawing.Color.Transparent;
            this.ulblHandshaking.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblHandshaking.Location = new System.Drawing.Point(21, 274);
            this.ulblHandshaking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblHandshaking.Name = "ulblHandshaking";
            this.ulblHandshaking.Size = new System.Drawing.Size(91, 17);
            this.ulblHandshaking.TabIndex = 156;
            this.ulblHandshaking.Text = "Handshaking";
            // 
            // ulblParidad
            // 
            this.ulblParidad.AutoSize = true;
            this.ulblParidad.BackColor = System.Drawing.Color.Transparent;
            this.ulblParidad.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblParidad.Location = new System.Drawing.Point(21, 242);
            this.ulblParidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblParidad.Name = "ulblParidad";
            this.ulblParidad.Size = new System.Drawing.Size(57, 17);
            this.ulblParidad.TabIndex = 155;
            this.ulblParidad.Text = "Paridad";
            // 
            // ulblEquipo
            // 
            this.ulblEquipo.AutoSize = true;
            this.ulblEquipo.BackColor = System.Drawing.Color.Transparent;
            this.ulblEquipo.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblEquipo.Location = new System.Drawing.Point(21, 80);
            this.ulblEquipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblEquipo.Name = "ulblEquipo";
            this.ulblEquipo.Size = new System.Drawing.Size(56, 17);
            this.ulblEquipo.TabIndex = 154;
            this.ulblEquipo.Text = "Equipo ";
            // 
            // ulblPuerto
            // 
            this.ulblPuerto.AutoSize = true;
            this.ulblPuerto.BackColor = System.Drawing.Color.Transparent;
            this.ulblPuerto.ForeColor = System.Drawing.Color.SeaShell;
            this.ulblPuerto.Location = new System.Drawing.Point(21, 113);
            this.ulblPuerto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ulblPuerto.Name = "ulblPuerto";
            this.ulblPuerto.Size = new System.Drawing.Size(50, 17);
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
            this.trayIcon.Text = "DIMENSION RL";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // rdUrgente
            // 
            this.rdUrgente.AutoSize = true;
            this.rdUrgente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdUrgente.ForeColor = System.Drawing.Color.Black;
            this.rdUrgente.Location = new System.Drawing.Point(151, 37);
            this.rdUrgente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdUrgente.Name = "rdUrgente";
            this.rdUrgente.Size = new System.Drawing.Size(96, 21);
            this.rdUrgente.TabIndex = 176;
            this.rdUrgente.TabStop = true;
            this.rdUrgente.Text = "URGENTE";
            this.rdUrgente.UseVisualStyleBackColor = true;
            // 
            // rdRutina
            // 
            this.rdRutina.AutoSize = true;
            this.rdRutina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdRutina.ForeColor = System.Drawing.Color.Black;
            this.rdRutina.Location = new System.Drawing.Point(39, 37);
            this.rdRutina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdRutina.Name = "rdRutina";
            this.rdRutina.Size = new System.Drawing.Size(79, 21);
            this.rdRutina.TabIndex = 177;
            this.rdRutina.TabStop = true;
            this.rdRutina.Text = "RUTINA";
            this.rdRutina.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdRutina);
            this.panel1.Controls.Add(this.rdUrgente);
            this.panel1.Location = new System.Drawing.Point(429, 396);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 75);
            this.panel1.TabIndex = 178;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 179;
            this.label1.Text = "Prioridad";
            // 
            // frmDimension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(973, 487);
            this.Controls.Add(this.panel1);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDimension";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.frm_shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_MouseUp);
            this.gbPanel.ResumeLayout(false);
            this.gbPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListView lstResultados;
        private System.Windows.Forms.ColumnHeader colResultado;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.Button ubtnCerrar;
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
        private System.Windows.Forms.RadioButton rdUrgente;
        private System.Windows.Forms.RadioButton rdRutina;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
    }
}

