using CafeOtomasyonu.Entities.Models; // Context dosyanın olduğu yer
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; // Bu satır .Load() ve .ToBindingList() için çok önemli!
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Menuler
{
    public partial class frmMenuler : DevExpress.XtraEditors.XtraForm
    {
       
        private CafeContext context = new CafeContext();

        public frmMenuler()
        {
            InitializeComponent();
            if (context.Menu.Count() == 0)
            {
                // 1. Ekleme: Sıcak İçecekler
                CafeOtomasyonu.Entities.Models.Menu sicakMenu = new CafeOtomasyonu.Entities.Models.Menu();
                sicakMenu.MenuAdi = "Sıcak İçecekler";
                sicakMenu.Aciklama = "Çay, Kahve, Salep vb.";
                context.Menu.Add(sicakMenu);

                // 2. Ekleme: Soğuk İçecekler (İstediğin Kısım)
                CafeOtomasyonu.Entities.Models.Menu sogukMenu = new CafeOtomasyonu.Entities.Models.Menu();
                sogukMenu.MenuAdi = "Soğuk İçecekler";
                sogukMenu.Aciklama = "Kola, Fanta, Limonata, Ayran";
                context.Menu.Add(sogukMenu);

                // Hepsini tek seferde veritabanına kaydet
                context.SaveChanges();


            }

            context.Menu.Load();


            gridControl1.DataSource = context.Menu.Local.ToBindingList();
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Tablodaki değişiklikleri veritabanına yazar
            context.SaveChanges();

            // Kullanıcıya bilgi ver (İstersen)
            MessageBox.Show("Menüler başarıyla kaydedildi!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan mesaj silinsin mi", "Uyarı", MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) ;
            {
                gridView1.DeleteSelectedRows();
                context.SaveChanges();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
    }
