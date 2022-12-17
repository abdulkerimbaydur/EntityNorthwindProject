
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
    public partial class FRMSIPARIS : Form
    {
        public FRMSIPARIS()
        {
            InitializeComponent();
        }

        private void FRMSIPARIS_Load(object sender, EventArgs e)
        {
            TEMIZLE();
            LISTELE();
        }

        int ID = 0;


        private void btnEKLE_Click(object sender, EventArgs e)
        {
            if (KONTROLET())
            {

                SIPARIS Siparis = new SIPARIS();

                Siparis.ID = ID;
                Siparis.MUSTERI_ID = Convert.ToInt32(comMUS.SelectedValue.ToString());
                Siparis.PERSONEL_ID = Convert.ToInt32(comPER.SelectedValue.ToString());
                Siparis.CREATEDATE = DateTime.Now;
                Siparis.IS_FLAG = 1;



                if (ID != 0)
                {
                    DialogResult giriskontrol = MessageBox.Show("Update Yapılsın Mı?", "UPDATE İSLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (giriskontrol == DialogResult.Yes)
                    {
                        try
                        {
                            Sipariscs.Update(Siparis);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("HATA : " + ex);
                        }

                    }
                }
                else
                {
                    try
                    {
                        Sipariscs.Insert(Siparis);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("HATA : " + ex);
                    }
                }
                TEMIZLE();
                LISTELE();
            }
        }

        private void btnSIL_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {

                DialogResult giriskontrol = MessageBox.Show("Silme Yapılsın Mı?", "SİLME İSLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (giriskontrol == DialogResult.Yes)
                {

                    SIPARIS Siparis = new SIPARIS();
                    Siparis.ID = ID;

                    try
                    {
                        Sipariscs.SIL(Siparis);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("HATA: " + ex);

                    }
                    TEMIZLE();
                    LISTELE();

                }
            }
        }

        private void btnLIST_Click(object sender, EventArgs e)
        {
            TEMIZLE();
            LISTELE();
        }

        private void LISTELE()
        {
            dataGridView1.DataSource = Sipariscs.LISTELE();


            comMUS.DataSource = Musterics.LISTELEPER();
            comMUS.DisplayMember = "MUSTERI_AD";
            comMUS.ValueMember = "ID";



            comPER.DataSource = Personelcs.LISTELEPER();
            comPER.DisplayMember = "AD";
            comPER.ValueMember = "ID";
        }

        private void TEMIZLE()
        {
            comMUS.Text = String.Empty;
            comPER.Text = String.Empty;
            ID = 0;
        }




        private bool KONTROLET()
        {
            bool DON = true;


            if (comMUS.Text == string.Empty)
            {
                MessageBox.Show("Musteri bilgisi eksik!!!!!!");
                DON = false;

                return DON;
            }




            if (comPER.Text == string.Empty)
            {
                MessageBox.Show("Personel bilgisi eksik!!!!!!");
                DON = false;

                return DON;
            }
            return DON;


        }

        private void btnYENI_Click(object sender, EventArgs e)
        {
            TEMIZLE();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ID = (int)dataGridView1.CurrentRow.Cells["SIPARIS_ID"].Value;
            comMUS.SelectedValue = dataGridView1.CurrentRow.Cells["MUSTERI_ID"].Value;
            comPER.SelectedValue = dataGridView1.CurrentRow.Cells["PERSONEL_ID"].Value;
        }

        private void buttonEXC_Click(object sender, EventArgs e)
        {
            Provider.Excel_Aktar(dataGridView1);
        }
    }
}
