using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ADVIA2120
{
    public partial class frmloading : Form
    {
        string[] advia;
        public static frmAdvia ad = null;
        public frmloading(string[] args)
        {
            advia = args;
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 30000;
            timer.Start();

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (ad == null)
            {
                ad = new frmAdvia(advia);
                ad.Show();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}