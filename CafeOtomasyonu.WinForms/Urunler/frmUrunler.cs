using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Mapping;
using CafeOtomasyonu.Entities.Models;
// using CafeOtomasyonu.WinForms.Urunler; // Kendi namespace'ini eklemene gerek yok, zaten buradasın
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Microsoft.Graph.Models;
using System;
using System.Data.Entity;
using System.Linq; // FirstOrDefault ve ToList için gerekli
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Urunler
{
    public partial class frmUrunler : DevExpress.XtraEditors.XtraForm
    {
        
        private CafeContext context = new CafeContext();
        UrunDal urunDal = new UrunDal();
        public frmUrunler()
        {
            InitializeComponent();
            // Constructor boş kalsın, yüklemeyi Load'da yapıyoruz.
        }

        void Listele()
        {
            // Verileri tazelemek için Local'i temizle veya yeniden çek
            // En garantisi veritabanından direkt çekmektir:
            gridControl1.DataSource = context.Urun.ToList();
        }

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = urunDal.GetAll(context);
        }

        private void btnYeni_Click(object sender, System.EventArgs e)
        {
            frmÜrünKaydetme frm = new frmÜrünKaydetme(new Urun());
            frm.ShowDialog();

            if (frm.kaydet)
            {
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, System.EventArgs e)
        {
            // Seçili satırın ID'sini al
            var seciliRow = gridView1.GetFocusedRowCellValue(colId);

            // Eğer seçim yapılmadıysa hata vermesin diye kontrol
            if (seciliRow == null) return;

            int seciliid = Convert.ToInt32(seciliRow);

            // HATALI KISIM DÜZELTİLDİ: urunDal.GetByFilter yerine Context kullanıyoruz
            var secilenUrun = context.Urun.FirstOrDefault(u => u.Id == seciliid);

            if (secilenUrun != null)
            {
                frmÜrünKaydetme frm = new frmÜrünKaydetme(secilenUrun);
                frm.ShowDialog();

                if (frm.kaydet)
                {
                    // Değişiklikleri veritabanına yansıt
                    context.SaveChanges();
                    Listele();
                }
            }
        }

        private void btnYenileme_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
            context.SaveChanges();
            MessageBox.Show("Kayıt Başarılı!");
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var seciliRow = gridView1.GetFocusedRowCellValue(colId);
            if (seciliRow == null)
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.");
                return;
            }

            int seciliId = Convert.ToInt32(seciliRow);

            if (MessageBox.Show("Seçili kayıt silinecek. Onaylıyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // HATALI KISIM DÜZELTİLDİ: urunDal.Delete yerine Context kullanıyoruz
                var silinecekUrun = context.Urun.FirstOrDefault(u => u.Id == seciliId);

                if (silinecekUrun != null)
                {
                    context.Urun.Remove(silinecekUrun);
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
