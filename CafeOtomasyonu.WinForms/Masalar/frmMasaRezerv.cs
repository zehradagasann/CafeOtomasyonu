using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using CafeOtomasyonu.WinForms.WinTools;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class frmMasaRezerv : DevExpress.XtraEditors.XtraForm
    {
        
        public int _secilenmasaId;
        public bool islemYapıldı;
        private Entities.Models.Masalar masalar;
        private MasalarDal masalarDal = new MasalarDal();
        CafeContext context = new CafeContext();
        public frmMasaRezerv(int gelenId)
        {
            InitializeComponent();
            _secilenmasaId = gelenId; 
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            
            CafeContext context = new CafeContext();
            MasalarDal masalarDal = new MasalarDal();

            var masa = context.Masalar.FirstOrDefault(m => m.Id == _secilenmasaId);

            if (masa != null)
            {
                masa.Islem = txtİslem.Text; 
                masa.SonIslemTarihi = DateTime.Now;
                masa.Kullaniciİd = KullaniciAyarları.kullaniciId;

                
                masa.RezerveMi = true;  

               
                masalarDal.Save(context);

                

                MessageBox.Show("Rezervasyon İşlemi Tamamlandı!");
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Masa Bulunamadı! ID: " + _secilenmasaId); 
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    