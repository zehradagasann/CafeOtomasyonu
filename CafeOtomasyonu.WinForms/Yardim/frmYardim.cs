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

namespace CafeOtomasyonu.WinForms.Yardim
{
    public partial class frmYardim : DevExpress.XtraEditors.XtraForm
    {
        public frmYardim()
        {
            InitializeComponent();
        }

        private void btnWhatsapp_Click(object sender, EventArgs e)
        {
            string telefon = "905312470260";
            string mesaj = Uri.EscapeDataString("Merhaba, Cafe Otomasyonu hakkında destek almak istiyorum.");
            string url = $"https://wa.me/{telefon}?text={mesaj}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnEPosta_Click(object sender, EventArgs e)
        {
            string eposta = "zehradagasan83@gmail.com";
            string konu = Uri.EscapeDataString("Cafe Otomasyonu Destek Talebi");
            string mailto = $"mailto:{eposta}?subject={konu}";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(mailto) { UseShellExecute = true });
        }
    }
}