using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarrantyTracking.DesktopApp.Forms.Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0, Width, Height, 20, 20));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void loginButtonAction()
        {
            if (txtKullaniciAdi.Text == "admin" && txtParola.Text == "1")
            {
                Properties.Settings.Default.LastLoggedUsername = txtKullaniciAdi.Text;
                Properties.Settings.Default.LastLoggedPassword = chkParolayiKaydet.Checked ? txtParola.Text : null;
                Properties.Settings.Default.Save();
                lblHataliParola.Visible = false;
                this.Hide();
                MessageBox.Show("Hoşgeldiniz.!!!");
            }
            else
            {
                lblHataliParola.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnGiriş_Click(object sender, EventArgs e)
        {
            loginButtonAction();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = Properties.Settings.Default.LastLoggedUsername;
            txtParola.Text = Properties.Settings.Default.LastLoggedPassword;
            chkParolayiKaydet.Checked = Properties.Settings.Default.LastLoggedPassword != string.Empty ? true : false;
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblHataliParola.Visible)
            {
                lblHataliParola.Visible = false;
            }
        }

        private void txtParola_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblHataliParola.Visible)
            {
                lblHataliParola.Visible = false;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void lblParolayiKaydet_DoubleClick(object sender, EventArgs e)
        {
            if (chkParolayiKaydet.Checked)
            {
                chkParolayiKaydet.Checked = false;
                return;
            }
            chkParolayiKaydet.Checked = true;
            return;
        }
    }
}
