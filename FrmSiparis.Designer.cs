namespace CafeOtomasyonu
{
    partial class FrmSiparis
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMenu = new DevExpress.XtraTab.XtraTabControl();
            this.btnSiparisKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridSiparisler = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSiparisler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSiparisKaydet);
            this.splitContainer1.Panel2.Controls.Add(this.gridSiparisler);
            this.splitContainer1.Size = new System.Drawing.Size(1319, 949);
            this.splitContainer1.SplitterDistance = 436;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabMenu
            // 
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.Size = new System.Drawing.Size(436, 949);
            this.tabMenu.TabIndex = 0;
            // 
            // btnSiparisKaydet
            // 
            this.btnSiparisKaydet.Appearance.BackColor = System.Drawing.Color.SeaShell;
            this.btnSiparisKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSiparisKaydet.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSiparisKaydet.Appearance.Options.UseBackColor = true;
            this.btnSiparisKaydet.Appearance.Options.UseFont = true;
            this.btnSiparisKaydet.Appearance.Options.UseForeColor = true;
            this.btnSiparisKaydet.Location = new System.Drawing.Point(647, 790);
            this.btnSiparisKaydet.Name = "btnSiparisKaydet";
            this.btnSiparisKaydet.Size = new System.Drawing.Size(189, 66);
            this.btnSiparisKaydet.TabIndex = 0;
            this.btnSiparisKaydet.Text = "KAYDET";
            this.btnSiparisKaydet.Click += new System.EventHandler(this.btnSiparisKaydet_Click);
            // 
            // gridSiparisler
            // 
            this.gridSiparisler.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridSiparisler.Location = new System.Drawing.Point(0, 0);
            this.gridSiparisler.MainView = this.gridView1;
            this.gridSiparisler.Name = "gridSiparisler";
            this.gridSiparisler.Size = new System.Drawing.Size(879, 776);
            this.gridSiparisler.TabIndex = 0;
            this.gridSiparisler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridSiparisler.Click += new System.EventHandler(this.gridSiparisler_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridSiparisler;
            this.gridView1.Name = "gridView1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(286, 491);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(286, 491);
            // 
            // FrmSiparis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 949);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSiparis";
            this.Text = "FrmSiparis";
            this.Load += new System.EventHandler(this.FrmSiparis_Load_1);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSiparisler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridSiparisler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl tabMenu;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton btnSiparisKaydet;
    }
}