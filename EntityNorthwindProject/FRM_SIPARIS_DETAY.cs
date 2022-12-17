using EntityNorthwindProject.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityNorthwindProject
{
    public partial class FRM_SIPARIS_DETAY : Form
    {
        public FRM_SIPARIS_DETAY()
        {
            InitializeComponent();
        }

        private void LISTELE()
        {
            dataGridView2.DataSource = Siparis_Detaycs.LISTELE();


            comSIP.DataSource = Sipariscs.LISTELESIPP();
            comSIP.DisplayMember = "PERSONEL_ADYOAD";
            comSIP.ValueMember = "SIPARIS_ID";



            comURUN.DataSource = Uruncs.LISTELEURUN();
            comURUN.DisplayMember = "URUN_AD";
            comURUN.ValueMember = "URUNLER_ID";
        }

        private void TEMIZLE()
        {
            comSIP.Text = String.Empty;
            comURUN.Text = String.Empty;
            txtADET.Text = String.Empty;
            
        }

        

        private void FRM_SIPARIS_DETAY_Load(object sender, EventArgs e)
        {
            TEMIZLE();
            LISTELE();
        }

        private void button1_Click(object sender, EventArgs e)
        {//sepete ekle
            if(KONTROL_ET())
            {
                URUNLER Urun = new URUNLER();
                Urun.ID = Convert.ToInt32(comURUN.SelectedValue.ToString());

                string[] FIYAT = Uruncs.FIYAT_GETIR(Urun).Split(',');

                string STOK = Uruncs.STOK_GETIR(Urun);
                int STOK_INT = Convert.ToInt32(STOK.ToString());
                int Adet_int = Convert.ToInt32(txtADET.Text.ToString());
                if (STOK_INT<Adet_int)
                {
                    MessageBox.Show("Stok miktarı: " + STOK_INT + "  Stok miktarı Yeterli Değil");
                    return;
                }
                dataGridView1.Rows.Add(true, comURUN.SelectedValue.ToString(), comURUN.Text, FIYAT[0], txtADET.Text);
            }
        }

        private bool KONTROL_ET()
        {
            bool DON = true;

            if (comSIP.Text == string.Empty)
            {
                MessageBox.Show("SIPARIS BILGISI eksik!!!!!!");
                DON = false;

                return DON;
            }


            if (comURUN.Text == string.Empty)
            {
                MessageBox.Show("URUN BILGISI eksik!!!!!!");
                DON = false;

                return DON;
            }

            if (txtADET.Text == string.Empty)
            {
                MessageBox.Show("ADET BILGISI eksik!!!!!!");
                DON = false;

                return DON;
            }
            return DON;
        }

        private void buttonTMZL_Click(object sender, EventArgs e)
        {
            TEMIZLE();
        }

        private void buttonLIST_Click(object sender, EventArgs e)
        {
            LISTELE();
        }

        private void buttonDETAYSIL_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult giriskontrol = MessageBox.Show("Sİpariş Yapılsın Mı?", "SİPARİŞ İSLEMİ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (giriskontrol == DialogResult.Yes)  
            {
                List<SIPARIS_DETAY> SiparisDetayList = new List<SIPARIS_DETAY>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["SEC"].Value !=null)
                    {
                        if ((Boolean)row.Cells["SEC"].Value==true)
                        {
                            if (row.Cells["URUN_ID"].Value !=null
                                && row.Cells["URUN_ID"].Value.ToString() !=string.Empty) 
                            {

                                SIPARIS_DETAY siparisDetay = new SIPARIS_DETAY();
                                
                                siparisDetay.SIPARIS_ID = Convert.ToInt32(comSIP.SelectedValue.ToString());
                                siparisDetay.URUN_ID = Convert.ToInt32(row.Cells["URUN_ID"].Value.ToString());
                                siparisDetay.FIYAT = Convert.ToDecimal(row.Cells["FIYAT"].Value.ToString());
                                siparisDetay.ADET = Convert.ToInt32(row.Cells["ADET"].Value.ToString());
                                siparisDetay.CREATEDATE = DateTime.Now;
                                siparisDetay.IS_FLAG = 1;

                                SiparisDetayList.Add(siparisDetay);
                            }
                        }
                    }
                }
                if (SiparisDetayList.Count>0)
                {
                    Siparis_Detaycs.Insert(SiparisDetayList);
                }
                LISTELE();
            }
        }

        private void buttonEXCEL_Click(object sender, EventArgs e)
        {
            Provider.Excel_Aktar(dataGridView2);
        }
    }
}
