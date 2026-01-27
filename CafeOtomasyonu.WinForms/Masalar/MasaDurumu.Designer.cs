namespace CafeOtomasyonu.WinForms.Masalar
{
    partial class MasaDurumu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasaDurumu));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupIslemler = new DevExpress.XtraEditors.GroupControl();
            this.btnRezervEt = new DevExpress.XtraEditors.SimpleButton();
            this.btnMasaAc = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenileme = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSiparisEkle = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupIslemler)).BeginInit();
            this.groupIslemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1529, 48);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Masa Durumları";
            // 
            // groupIslemler
            // 
            this.groupIslemler.AppearanceCaption.Options.UseTextOptions = true;
            this.groupIslemler.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupIslemler.Controls.Add(this.btnRezervEt);
            this.groupIslemler.Controls.Add(this.btnMasaAc);
            this.groupIslemler.Controls.Add(this.btnYenileme);
            this.groupIslemler.Controls.Add(this.btnKapat);
            this.groupIslemler.Controls.Add(this.btnSiparisEkle);
            this.groupIslemler.Controls.Add(this.groupControl2);
            this.groupIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupIslemler.Location = new System.Drawing.Point(0, 836);
            this.groupIslemler.Name = "groupIslemler";
            this.groupIslemler.Size = new System.Drawing.Size(1529, 152);
            this.groupIslemler.TabIndex = 13;
            this.groupIslemler.Text = "İşlemler";
            // 
            // btnRezervEt
            // 
            this.btnRezervEt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRezervEt.ImageOptions.Image")));
            this.btnRezervEt.Location = new System.Drawing.Point(364, 54);
            this.btnRezervEt.Name = "btnRezervEt";
            this.btnRezervEt.Size = new System.Drawing.Size(155, 73);
            this.btnRezervEt.TabIndex = 7;
            this.btnRezervEt.Text = "Rezerv Et";
            this.btnRezervEt.Click += new System.EventHandler(this.btnRezervEt_Click);
            // 
            // btnMasaAc
            // 
            this.btnMasaAc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMasaAc.ImageOptions.Image")));
            this.btnMasaAc.Location = new System.Drawing.Point(203, 54);
            this.btnMasaAc.Name = "btnMasaAc";
            this.btnMasaAc.Size = new System.Drawing.Size(155, 73);
            this.btnMasaAc.TabIndex = 6;
            this.btnMasaAc.Text = "Masa Aç";
            this.btnMasaAc.Click += new System.EventHandler(this.btnMasaAc_Click);
            // 
            // btnYenileme
            // 
            this.btnYenileme.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYenileme.ImageOptions.Image")));
            this.btnYenileme.Location = new System.Drawing.Point(525, 54);
            this.btnYenileme.Name = "btnYenileme";
            this.btnYenileme.Size = new System.Drawing.Size(155, 73);
            this.btnYenileme.TabIndex = 5;
            this.btnYenileme.Text = "Yenile-Listele";
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnKapat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKapat.ImageOptions.Image")));
            this.btnKapat.Location = new System.Drawing.Point(1365, 54);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(142, 73);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnSiparisEkle
            // 
            this.btnSiparisEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSiparisEkle.ImageOptions.Image")));
            this.btnSiparisEkle.Location = new System.Drawing.Point(12, 54);
            this.btnSiparisEkle.Name = "btnSiparisEkle";
            this.btnSiparisEkle.Size = new System.Drawing.Size(185, 73);
            this.btnSiparisEkle.TabIndex = 1;
            this.btnSiparisEkle.Text = "Siparisler";
            this.btnSiparisEkle.Click += new System.EventHandler(this.btnSiparisEkle_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Location = new System.Drawing.Point(56, 34);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(9, 38);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "groupControl2";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1529, 788);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // MasaDurumu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 988);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupIslemler);
            this.Controls.Add(this.labelControl1);
            this.Name = "MasaDurumu";
            this.Text = "MasaDurumu";
            ((System.ComponentModel.ISupportInitialize)(this.groupIslemler)).EndInit();
            this.groupIslemler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupIslemler;
        private DevExpress.XtraEditors.SimpleButton btnYenileme;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnSiparisEkle;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnRezervEt;
        private DevExpress.XtraEditors.SimpleButton btnMasaAc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}