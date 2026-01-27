using CafeOtomasyonu.Entities.DAL;
using CafeOtomasyonu.Entities.Models;
using DevExpress.Utils.DirectXPaint.Svg;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CafeOtomasyonu.WinForms.Masalar
{
    public partial class MasaDurumu : DevExpress.XtraEditors.XtraForm
    {
        // --- GEREKLİ DEĞİŞKENLER (BUNLAR EKSİKTİ) ---
        private CafeContext context = new CafeContext();
        private MasalarDal masalarDal = new MasalarDal();

        private int? _secilenMasaId = null;   // Seçilen masanın ID'si
        private string _secilenMasaAdi = "";  // Seçilen masanın Adı
        private SatisKodu modelSatisKodu;     // Satış kodu üretmek için model
        private CheckButton btnsender;
        private string _satisKodu;

        public MasaDurumu()
        {
            InitializeComponent();

            // Satış kodunu veritabanından çekiyoruz (Yoksa hata verir)
            modelSatisKodu = context.SatisKodu.FirstOrDefault();

            MasalariGetir();
        }

        public void MasalariGetir()
        {
            flowLayoutPanel1.Controls.Clear();
            var model = context.Masalar.ToList();

            for (int i = 0; i < model.Count; i++)
            {
                var btn = new CheckButton();
                btn.Text = model[i].MasaAdi;
                btn.Name = model[i].Id.ToString(); 
                btn.Height = 100;
                btn.Width = 80;
               
                btn.Tag = model[i].Id; 
                btn.GroupIndex = 1;
              

                flowLayoutPanel1.Controls.Add(btn);

                // Renklendirme
                if (model[i].RezerveMi)
                    btn.Appearance.BackColor = Color.Yellow;
                else if (model[i].Durumu)
                    btn.Appearance.BackColor = Color.Red;
                else
                    btn.Appearance.BackColor = Color.Green;

                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var tiklananButton = sender as DevExpress.XtraEditors.SimpleButton;

            if (tiklananButton != null)
            {
                // Masanın adını al
                _secilenMasaAdi = tiklananButton.Text;
                // Bu kod SADECE masaya (Masa 1, Masa 2...) tıklandığında çalışan yerde olmalı!
                btnsender = (DevExpress.XtraEditors.CheckButton)sender;


                // --- GÜVENLİ ID ALMA İŞLEMİ ---
                if (tiklananButton.Tag != null)
                {
                    // Tag doluysa sayıya çevirmeyi dene
                    try
                    {
                        _secilenMasaId = Convert.ToInt32(tiklananButton.Tag);
                    }
                    catch
                    {
                        // Sayıya çevrilemezse (örn: içinde "masa" yazıyorsa)
                        _secilenMasaId = 0;
                        MessageBox.Show("HATA: Butonun Tag'inde sayı yok! İçinde şu yazıyor: " + tiklananButton.Tag.ToString());
                    }
                }
                else
                {
                    // Tag tamamen boşsa
                    _secilenMasaId = 0;
                    MessageBox.Show("KRİTİK HATA: Butonun Tag değeri BOŞ (Null)! Masaları listelerken ID atamayı unutmuşsun.");
                }
            }
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            if (_secilenMasaId != null)
            {
                // Masayı veritabanından bulup güncel Satış Kodunu alıyoruz
                var masa = context.Masalar.FirstOrDefault(m => m.Id == _secilenMasaId);
                _satisKodu = masa?.SatısKodu; // Güvenli şekilde satış kodunu aldık

                frmMasaSiparisleri frm = new frmMasaSiparisleri(masaId: _secilenMasaId, masaAdi: _secilenMasaAdi, satisKodu: _satisKodu);
                frm.ShowDialog();

                btnsender = null;
                _secilenMasaId = null;
                MasalariGetir();
            }
            else
            {
                MessageBox.Show("Lütfen işlem yapmak için önce bir masa seçiniz.");
            }
        }

        private void btnMasaAc_Click(object sender, EventArgs e)
        {
            
            if (_secilenMasaId == null || btnsender == null)
            {
                MessageBox.Show("Lütfen önce açmak istediğiniz masayı seçin!");
                return;
            }

            
            if (MessageBox.Show(btnsender.Text + " açılsın mı?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                var secilenMasa = context.Masalar.FirstOrDefault(m => m.Id == _secilenMasaId);

                if (secilenMasa != null)
                {
                    
                    secilenMasa.SatısKodu = modelSatisKodu.SatisTanimi + modelSatisKodu.Sayi;

                    
                    secilenMasa.Durumu = true;
                    modelSatisKodu.Sayi++;

                    context.SaveChanges();

                    
                    btnsender = null;
                    _secilenMasaId = null;

                    
                    MasalariGetir();
                }
            }
        }

        
        public void DurumlariYenile()
        {
            
        }

        private void btnRezervEt_Click(object sender, EventArgs e)
        {
            // Önce masa seçilmiş mi kontrol edelim
            if (_secilenMasaId > 0)
            {
                // Seçilen masanın ID'sini diğer forma gönderiyoruz
                frmMasaRezerv frm = new frmMasaRezerv(Convert.ToInt32(_secilenMasaId));
                frm.ShowDialog();

                // Form kapandıktan sonra masaların rengi güncellensin diye listeyi yenile
                // MasalariGetir(); // Eğer böyle bir metodun varsa yorumu kaldır.
            }
            else
            {
                MessageBox.Show("Lütfen önce listeden işlem yapılacak bir masa seçiniz!", "Uyarı");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
    
