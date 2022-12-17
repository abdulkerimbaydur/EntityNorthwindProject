using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityNorthwindProject.Service;

namespace EntityNorthwindProject
{
    public partial class FRMKATEGORI : Form
    {
        public FRMKATEGORI()
        {
            InitializeComponent();
        }

        private void Form50_Load(object sender, EventArgs e)
        {
            TEMIZLE();
            LISTELE();
        }

        private void TEMIZLE()
        {
            txtKTGRAD.Text = String.Empty;
            ID = 0;

        }
        int ID =0;

        private void LISTELE()
        {
            dataGridView1.DataSource = Kategorics.LISTELE();
        }

        private void btnLIST_Click(object sender, EventArgs e)
        {
            TEMIZLE();
            LISTELE();

        }

        private void btnEKLE_Click(object sender, EventArgs e)
        {
            if (KONTROLET())
            {

                Kategoriler kategori = new Kategoriler();

                kategori.ID = ID;
                kategori.AD = txtKTGRAD.Text;
                kategori.CREATEDATE = DateTime.Now;
                kategori.IS_FLAG = 1;



                if (ID !=0)
                {
                    DialogResult giriskontrol = MessageBox.Show("Update Yapılsın Mı?", "UPDATE İSLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (giriskontrol == DialogResult.Yes)
                    {
                        try
                        {
                            Kategorics.Update(kategori);
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
                        Kategorics.Insert(kategori);
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

        private bool KONTROLET()
        {
            bool DON = true;


            if (txtKTGRAD.Text == string.Empty)
            {
                MessageBox.Show("AD bilgisi eksik");
                DON = false;

                return DON;
            }

            return DON;
        }

        private void btnYENI_Click(object sender, EventArgs e)
        {
            TEMIZLE();
        }

        private void btnSIL_Click(object sender, EventArgs e)
        {
           if (ID !=0)
            {
                DialogResult giriskontrol = MessageBox.Show("Silme Yapılsın Mı?", "SİLME İSLEMİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(giriskontrol==DialogResult.Yes)
                {
                    Kategoriler Kategori = new Kategoriler();
                    Kategori.ID = ID;

                    try
                    {
                        Kategorics.SIL(Kategori);
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            ID = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            txtKTGRAD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void buttonEXC_Click(object sender, EventArgs e)
        {
            Provider.Excel_Aktar(dataGridView1);
        }
    }
}
