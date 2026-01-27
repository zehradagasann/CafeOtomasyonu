using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CafeOtomasyonu
{
    public partial class Form1 : XtraForm
    {
        CafeOtomasyonEntities db = new CafeOtomasyonEntities();

        public Form1()
        {
            InitializeComponent();
            MasaYukle();
        }

        public void MasaYukle()
        {

            db = new CafeOtomasyonEntities();
            // DÜZELTME BAŞLANGICI: Grubun var olup olmadığını kontrol et
            if (tileControl1.Groups.Count == 0)
            {
                // Eğer grup yoksa, varsayılan bir grup ekle
                tileControl1.Groups.Add(new TileGroup());
            }

            // Artık ilk gruba güvenle erişebiliriz
            tileControl1.Groups[0].Items.Clear();
            // DÜZELTME BİTİŞİ

            var masalar = db.Masalar.ToList();

            foreach (var masa in masalar)
            {
                TileItem item = new TileItem();
                item.AppearanceItem.Normal.BackColor = masa.Durumu == true ? Color.IndianRed : Color.ForestGreen;
                item.AppearanceItem.Normal.Options.UseBackColor = true;
                item.Text = masa.MasaAdi;
                item.Tag = masa.Id;
                item.ItemSize = TileItemSize.Wide;

                TileItemElement element = new TileItemElement();
                element.Text = masa.Durumu == true ? "DOLU" : "BOŞ";
                element.TextAlignment = TileItemContentAlignment.BottomLeft;
                item.Elements.Add(element);

                tileControl1.Groups[0].Items.Add(item);
            }
        }

        private void tileControl1_ItemClick_1(object sender, TileItemEventArgs e)
        {
            FrmSiparis frm = new FrmSiparis((int)e.Item.Tag);
            frm.ShowDialog();
            MasaYukle();
        }
    }
}