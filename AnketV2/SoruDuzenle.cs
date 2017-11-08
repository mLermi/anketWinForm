using DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketV2
{
    public partial class SoruDuzenle : Form
    {
        public SoruDuzenle()
        {
            InitializeComponent();
        }
        public Soru GelenSoru { get; set; }
        private void SoruDuzenle_Load(object sender, EventArgs e)
        {
           txtSoru.Text= GelenSoru.SoruCumlesi;
        }

        private void btnSoruKaydet_Click(object sender, EventArgs e)
        {//soru düzenle kaydet
            //EF nir kayıtta değişiklik yapabilmesi CONTEXT üzerinden geliyorsa mümkün
            AnketContext db = new AnketContext();
            var duzenlenecek = db.Sorular.Find(GelenSoru.SoruID);
            duzenlenecek.SoruCumlesi = txtSoru.Text;
            db.Entry(duzenlenecek).State= EntityState.Modified;
            db.SaveChanges();
            MessageBox.Show("Düzenlendi!");
            Form1 f =(Form1) Application.OpenForms["Form1"];
            
            f.SorulariYenile();
            f.CevaplariYenile();
            f.Refresh();
            this.Close();
        }
    }
}
