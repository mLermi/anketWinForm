﻿using DAL;
using Entity.Models;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnketV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AnketContext db = new AnketContext();
        private void btnSoruKaydet_Click(object sender, EventArgs e)
        {
            Soru s = new Soru();
            s.SoruCumlesi = txtSoru.Text;
            
            db.Sorular.Add(s);
            db.SaveChanges();
            MessageBox.Show("Eklendi!");
            txtSoru.Text = "";
            SorulariYenile();
            CevaplariYenile();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            SorulariYenile();
            CevaplariYenile();
        }
        public void SorulariYenile()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.Sorular.ToList();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();

            foreach (Soru soru in db.Sorular)
            {
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = soru.SoruCumlesi;           
                flowLayoutPanel1.Controls.Add(lbl);
                flowLayoutPanel1.SetFlowBreak(lbl, true);

                RadioButton r1 = new RadioButton();
                r1.Name = "Soru_" + soru.SoruID;
                r1.Text = "Evet";
                r1.Height = 50;
                
                RadioButton r2 = new RadioButton();
                r2.Name = "Soru_" + soru.SoruID;
                r2.Text = "Hayır";
                r2.Height = 50;
                
                FlowLayoutPanel p = new FlowLayoutPanel();
                p.Size = new Size(300, 50);
                p.AutoScroll = false;
                p.Controls.Add(r1);
                p.Controls.Add(r2);
                flowLayoutPanel1.Controls.Add(p);
                flowLayoutPanel1.SetFlowBreak(p, true);


                //ComboBox c1 = new ComboBox();
                //c1.Items.Add("Hayır");
                //c1.Items.Add("Evet");
                //flowLayoutPanel1.Controls.Add(c1);
                //flowLayoutPanel1.SetFlowBreak(c1, true);

            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            foreach (Control pnl in flowLayoutPanel1.Controls)
            {
                if (pnl is FlowLayoutPanel)
                {
                    foreach (RadioButton item in ((FlowLayoutPanel)pnl).Controls)
                    {
                        RadioButton r = item;
                        if (r.Checked)
                        {
                            string soruID = item.Name.Replace("Soru_", "");
                            int sID = Convert.ToInt32(soruID);

                            Cevap c = new Cevap();
                            c.SoruID = sID;
                            c.Yanit = r.Text == "Evet" ? Yanit.Evet : Yanit.Hayir;
                            Kisi k = db.Kisiler.Where(x => x.AdSoyad == txtAdSoyad.Text).FirstOrDefault();
                            if (k != null)
                            {
                                c.KisiID = k.KisiID;
                            }
                            else
                            {
                                k = new Kisi();
                                k.AdSoyad = txtAdSoyad.Text;
                                db.Kisiler.Add(k);
                                db.SaveChanges();
                                c.KisiID = k.KisiID;
                            }
                            db.Cevaplar.Add(c);
                            db.SaveChanges();
                            
                        }
                    }
                }
            }
            MessageBox.Show("Eklendi");
            txtAdSoyad.Text = "";
            CevaplariYenile();
            SorulariYenile();
        }
        public void CevaplariYenile()
        {
            dataGridView2.DataSource = null;
            //dataGridView2.DataSource = db.Cevaplar.ToList();
            dataGridView2.DataSource = db.Cevaplar.Select(x => new CevapViewModel()
            {
                CevapID = x.CevapID,
                AdSoyad = x.CevabiVerenKisi.AdSoyad,
                Soru = x.Sorusu.SoruCumlesi,
                Cevap = x.Yanit.ToString()

            }).ToList();
                     
        }

        private void btnSoruSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Soru Seçiniz!");
            }
            else
            {
                foreach  (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    int SoruID = (int)item.Cells[0].Value;
                    Soru silinecek = db.Sorular.Find(SoruID);
                    db.Sorular.Remove(silinecek);
                }
                db.SaveChanges();
                SorulariYenile();
                CevaplariYenile();
            }
        }

        private void btnSoruDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Soru Seçiniz!");
            }
            else
            {
                SoruDuzenle fsd = new SoruDuzenle();
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    int SoruID = (int)item.Cells[0].Value;
                    Soru iletilecek = db.Sorular.Find(SoruID);
                    fsd.GelenSoru = iletilecek;
                    fsd.Show();
                }
                SorulariYenile();
                CevaplariYenile();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silinecek cevapı seçiniz!");
            }
            else
            {
                foreach (DataGridViewRow item in dataGridView2.SelectedRows)
                {
                    int CevapID = (int)item.Cells[0].Value;
                    Cevap silinecek = db.Cevaplar.Find(CevapID);
                    db.Cevaplar.Remove(silinecek);
                }
                db.SaveChanges();
                SorulariYenile();
                CevaplariYenile();
            }
            //if (dataGridView2.SelectedRows.Count == 0)
            //    MessageBox.Show("Cevap seçiniz");
            //else
            //{
            //    List<Cevap> silinecekler = new List<Cevap>();
            //    foreach (DataGridViewRow item in dataGridView2.SelectedRows)
            //    {
            //        var silinecek = db.Cevaplar.ToList()[item.Index];
            //        silinecekler.Add(silinecek);
            //        //int CevapID = (int)item.Cells[0].Value;
            //        //Cevap silinecek = db.Cevaplar.Find(CevapID);
            //        //db.Cevaplar.Remove(silinecek);
            //    }
            //    db.Cevaplar.RemoveRange(silinecekler);
            //    db.SaveChanges();
            //    //db.SaveChanges();
            //    //Yenile();
            //    CevaplariYenile();
            //}

        }
    }
}
