using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using DevExpress.XtraEditors;
using System;
using System.Data.Entity;
using System.Linq; // FirstOrDefault ve ToList için gerekli
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasalar : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        // MasalarDal masalarDal = new MasalarDal(); // Bunu kapattık, sorun çıkarıyor.

        public frmMasalar()
        {
            InitializeComponent();
            Listele();
        }

        private void Listele()
        {
            // DAL yerine doğrudan Context üzerinden listeliyoruz
            // "Verileri yerel hafızaya yükle ve bana ver" diyoruz.
            context.Masalar.Load();
            gridControl2.DataSource = context.Masalar.Local.ToBindingList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            // Boş
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            // Yeni masa ekleme
            frmMasaKaydet frm = new frmMasaKaydet(new Entities.Models.Masalar());
            frm.ShowDialog();

            if (frm.kaydet)
            {
                // Değişiklikleri kaydet ve listeyi yenile
                context.SaveChanges();
                Listele();
            }
        }

        private void btnYenileme_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            // Seçili satırın ID'sini alıyoruz
            var seciliRow = gridView1.GetFocusedRowCellValue(colId);
            if (seciliRow == null) return;

            int seciliId = Convert.ToInt32(seciliRow);

            // DAL yerine Context ile buluyoruz
            var secilenMasa = context.Masalar.FirstOrDefault(m => m.Id == seciliId);

            if (secilenMasa != null)
            {
                frmMasaKaydet frm = new frmMasaKaydet(secilenMasa);
                frm.ShowDialog();

                if (frm.kaydet)
                {
                    context.SaveChanges();
                    Listele();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var seciliRow = gridView1.GetFocusedRowCellValue(colId);
            if (seciliRow == null)
            {
                MessageBox.Show("Silinecek bir masa seçiniz.");
                return;
            }

            int seciliId = Convert.ToInt32(seciliRow);

            if (MessageBox.Show("Seçili kayıt silinecek. Onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Silinecek masayı bul
                var silinecekMasa = context.Masalar.FirstOrDefault(u => u.Id == seciliId);

                if (silinecekMasa != null)
                {
                    // Masayı sil
                    context.Masalar.Remove(silinecekMasa);
                    // Kaydet
                    context.SaveChanges();
                    Listele();
                }
            }
        }

        private void btnDurumDegistir_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int seciliId = Convert.ToInt32(gridView1.GetFocusedRowCellValue(colId));

                // Masayı bul
                var secilenMasa = context.Masalar.FirstOrDefault(m => m.Id == seciliId);

                if (secilenMasa != null)
                {
                    // Durumu tersine çevir (True ise False, False ise True yap)
                    secilenMasa.Durumu = !secilenMasa.Durumu;

                    // Kaydet
                    context.SaveChanges();
                    Listele();
                }
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

       
