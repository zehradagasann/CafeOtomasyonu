using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
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
    public partial class frmMasaKaydet : DevExpress.XtraEditors.XtraForm
    {
        private CafeContext context = new CafeContext();
        private MasalarDal masalarDal = new MasalarDal();
        private Entities.Models.Masalar _entity;
        public bool kaydet = false;

        public frmMasaKaydet(Entities.Models.Masalar entity)
        {
            InitializeComponent();

            _entity = entity;

            
            txtMasaAdi.DataBindings.Add("Text", _entity, "MasaAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void btnKaydett_Click(object sender, EventArgs e)
        {
            // 1. KONTROL: İsim girilmiş mi?
            if (string.IsNullOrEmpty(txtMasaAdi.Text))
            {
                MessageBox.Show("Lütfen bir Masa Adı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (_entity.Id == 0)
            {
                

                _entity.MasaAdi = txtMasaAdi.Text;
                _entity.Aciklama = txtAciklama.Text;
                _entity.Durumu = true;
                _entity.RezerveMi = false;
                _entity.EklenmeTarihi = DateTime.Now;
                _entity.SonIslemTarihi = DateTime.Now;
                _entity.Islem = "Yeni Masa Eklendi";

                _entity.Kullaniciİd = 1; 

                context.Masalar.Add(_entity);
            }
            else
            {
                // --- GÜNCELLEME (UPDATE) ---
                // Var olan masayı veritabanından çekip değiştiriyoruz.

                var guncellenecekMasa = context.Masalar.Find(_entity.Id);

                if (guncellenecekMasa != null)
                {
                    guncellenecekMasa.MasaAdi = txtMasaAdi.Text;
                    guncellenecekMasa.Aciklama = txtAciklama.Text;
                    guncellenecekMasa.SonIslemTarihi = DateTime.Now;
                    guncellenecekMasa.Islem = "Masa Güncellendi";
                    guncellenecekMasa.Kullaniciİd = 1; 
                }
            }

            try
            {
                context.SaveChanges(); 
                kaydet = true;
                this.Close();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string hataMesaji = "";
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityError.ValidationErrors)
                    {
                        hataMesaji += $"- {validationError.PropertyName}: {validationError.ErrorMessage}\n";
                    }
                }
                MessageBox.Show("Veritabanı Hatası:\n" + hataMesaji);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Genel Hata: " + ex.Message);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}