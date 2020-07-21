namespace WarrantyTracking.DesktopApp.Forms.Login
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.namePictureBox = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.txtParola = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtKullaniciAdi = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblHataliParola = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblParolayiKaydet = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.chkParolayiKaydet = new Bunifu.Framework.UI.BunifuCheckbox();
            this.btnGiriş = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.namePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.logoPictureBox)).BeginInit();
            this.panelRight.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.YellowGreen;
            this.panelLeft.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("panelLeft.BackgroundImage")));
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Controls.Add(this.namePictureBox);
            this.panelLeft.Controls.Add(this.logoPictureBox);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(350, 490);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            // 
            // namePictureBox
            // 
            this.namePictureBox.BackColor = System.Drawing.Color.Yellow;
            this.namePictureBox.Image = ((System.Drawing.Image) (resources.GetObject("namePictureBox.Image")));
            this.namePictureBox.Location = new System.Drawing.Point(21, 220);
            this.namePictureBox.Name = "namePictureBox";
            this.namePictureBox.Size = new System.Drawing.Size(311, 42);
            this.namePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.namePictureBox.TabIndex = 1;
            this.namePictureBox.TabStop = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Yellow;
            this.logoPictureBox.Image = ((System.Drawing.Image) (resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(69, 81);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(183, 135);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.YellowGreen;
            this.panelRight.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("panelRight.BackgroundImage")));
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.txtParola);
            this.panelRight.Controls.Add(this.txtKullaniciAdi);
            this.panelRight.Controls.Add(this.lblHataliParola);
            this.panelRight.Controls.Add(this.lblParolayiKaydet);
            this.panelRight.Controls.Add(this.chkParolayiKaydet);
            this.panelRight.Controls.Add(this.btnGiriş);
            this.panelRight.Controls.Add(this.pnlTop);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(350, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(450, 490);
            this.panelRight.TabIndex = 1;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            // 
            // txtParola
            // 
            this.txtParola.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtParola.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtParola.BackColor = System.Drawing.Color.Bisque;
            this.txtParola.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtParola.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtParola.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtParola.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.txtParola.HintForeColor = System.Drawing.Color.Empty;
            this.txtParola.HintText = "Parola";
            this.txtParola.isPassword = false;
            this.txtParola.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtParola.LineIdleColor = System.Drawing.Color.Gray;
            this.txtParola.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtParola.LineThickness = 3;
            this.txtParola.Location = new System.Drawing.Point(39, 164);
            this.txtParola.Margin = new System.Windows.Forms.Padding(4);
            this.txtParola.MaxLength = 32767;
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(371, 33);
            this.txtParola.TabIndex = 10;
            this.txtParola.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtKullaniciAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtKullaniciAdi.BackColor = System.Drawing.Color.Bisque;
            this.txtKullaniciAdi.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtKullaniciAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.txtKullaniciAdi.HintForeColor = System.Drawing.Color.Empty;
            this.txtKullaniciAdi.HintText = "Kullanıcı Adı";
            this.txtKullaniciAdi.isPassword = false;
            this.txtKullaniciAdi.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtKullaniciAdi.LineIdleColor = System.Drawing.Color.Gray;
            this.txtKullaniciAdi.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtKullaniciAdi.LineThickness = 3;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(39, 108);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtKullaniciAdi.MaxLength = 32767;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(371, 33);
            this.txtKullaniciAdi.TabIndex = 9;
            this.txtKullaniciAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblHataliParola
            // 
            this.lblHataliParola.AutoSize = true;
            this.lblHataliParola.BackColor = System.Drawing.Color.Bisque;
            this.lblHataliParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (162)));
            this.lblHataliParola.ForeColor = System.Drawing.Color.Red;
            this.lblHataliParola.Location = new System.Drawing.Point(297, 230);
            this.lblHataliParola.Name = "lblHataliParola";
            this.lblHataliParola.Size = new System.Drawing.Size(103, 16);
            this.lblHataliParola.TabIndex = 8;
            this.lblHataliParola.Text = "Parola Hatalı!";
            this.lblHataliParola.Visible = false;
            // 
            // lblParolayiKaydet
            // 
            this.lblParolayiKaydet.AutoSize = true;
            this.lblParolayiKaydet.BackColor = System.Drawing.Color.Bisque;
            this.lblParolayiKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (162)));
            this.lblParolayiKaydet.ForeColor = System.Drawing.Color.Black;
            this.lblParolayiKaydet.Location = new System.Drawing.Point(61, 230);
            this.lblParolayiKaydet.Name = "lblParolayiKaydet";
            this.lblParolayiKaydet.Size = new System.Drawing.Size(118, 16);
            this.lblParolayiKaydet.TabIndex = 7;
            this.lblParolayiKaydet.Text = "Parolayı Kaydet";
            this.lblParolayiKaydet.DoubleClick += new System.EventHandler(this.lblParolayiKaydet_DoubleClick);
            // 
            // chkParolayiKaydet
            // 
            this.chkParolayiKaydet.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (205)))), ((int) (((byte) (117)))));
            this.chkParolayiKaydet.ChechedOffColor = System.Drawing.Color.DarkOrange;
            this.chkParolayiKaydet.Checked = true;
            this.chkParolayiKaydet.CheckedOnColor = System.Drawing.Color.FromArgb(((int) (((byte) (51)))), ((int) (((byte) (205)))), ((int) (((byte) (117)))));
            this.chkParolayiKaydet.ForeColor = System.Drawing.Color.White;
            this.chkParolayiKaydet.Location = new System.Drawing.Point(39, 229);
            this.chkParolayiKaydet.Name = "chkParolayiKaydet";
            this.chkParolayiKaydet.Size = new System.Drawing.Size(20, 20);
            this.chkParolayiKaydet.TabIndex = 6;
            // 
            // btnGiriş
            // 
            this.btnGiriş.Active = false;
            this.btnGiriş.Activecolor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (139)))), ((int) (((byte) (87)))));
            this.btnGiriş.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (139)))), ((int) (((byte) (87)))));
            this.btnGiriş.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGiriş.BorderRadius = 5;
            this.btnGiriş.ButtonText = "Giriş";
            this.btnGiriş.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiriş.DisabledColor = System.Drawing.Color.Gray;
            this.btnGiriş.Iconcolor = System.Drawing.Color.Transparent;
            this.btnGiriş.Iconimage = ((System.Drawing.Image) (resources.GetObject("btnGiriş.Iconimage")));
            this.btnGiriş.Iconimage_right = null;
            this.btnGiriş.Iconimage_right_Selected = null;
            this.btnGiriş.Iconimage_Selected = null;
            this.btnGiriş.IconMarginLeft = 0;
            this.btnGiriş.IconMarginRight = 0;
            this.btnGiriş.IconRightVisible = true;
            this.btnGiriş.IconRightZoom = 0D;
            this.btnGiriş.IconVisible = true;
            this.btnGiriş.IconZoom = 90D;
            this.btnGiriş.IsTab = false;
            this.btnGiriş.Location = new System.Drawing.Point(287, 261);
            this.btnGiriş.Name = "btnGiriş";
            this.btnGiriş.Normalcolor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (139)))), ((int) (((byte) (87)))));
            this.btnGiriş.OnHovercolor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))));
            this.btnGiriş.OnHoverTextColor = System.Drawing.Color.White;
            this.btnGiriş.selected = false;
            this.btnGiriş.Size = new System.Drawing.Size(122, 35);
            this.btnGiriş.TabIndex = 5;
            this.btnGiriş.Text = "Giriş";
            this.btnGiriş.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiriş.Textcolor = System.Drawing.Color.White;
            this.btnGiriş.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (162)));
            this.btnGiriş.Click += new System.EventHandler(this.btnGiriş_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Bisque;
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnExit);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(450, 32);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (162)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(392, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(29, 32);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "_";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (162)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(421, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "X";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.ForeColor = System.Drawing.Color.YellowGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.TransparencyKey = System.Drawing.Color.YellowGreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.namePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.logoPictureBox)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnExit;
        private Bunifu.Framework.UI.BunifuFlatButton btnGiriş;
        private System.Windows.Forms.Button btnMinimize;
        private Bunifu.Framework.UI.BunifuCheckbox chkParolayiKaydet;
        private Bunifu.Framework.UI.BunifuCustomLabel lblHataliParola;
        private Bunifu.Framework.UI.BunifuCustomLabel lblParolayiKaydet;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.PictureBox namePictureBox;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel pnlTop;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtKullaniciAdi;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtParola;

        #endregion
    }
}