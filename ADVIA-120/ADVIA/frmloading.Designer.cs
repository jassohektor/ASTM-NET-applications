namespace ADVIA2120
{
    partial class frmloading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmloading));
            this.picturebox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // picturebox
            // 
            this.picturebox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picturebox.BackgroundImage")));
            this.picturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picturebox.Location = new System.Drawing.Point(1, 20);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(109, 117);
            this.picturebox.TabIndex = 0;
            this.picturebox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADVIA 120";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ADVIA120";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(83, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMin
            // 
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Location = new System.Drawing.Point(50, 2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(27, 23);
            this.btnMin.TabIndex = 3;
            this.btnMin.Text = "-";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // frmloading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(111, 162);
            this.ControlBox = false;
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmloading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
    }
}