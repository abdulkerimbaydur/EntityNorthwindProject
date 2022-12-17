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
    public partial class MAIN : Form
    {
        public MAIN()
        {
            InitializeComponent();
        }

        private void MAIN_Load(object sender, EventArgs e)
        {

        }
        FRMPERSONEL fRMPERSONEL;
        FRMKATEGORI fRMKATEGORI;
        FRMMUSTERI fRMMUSTERI;
        FRMTEDARIKCI fRMTEDARIKCI;
        FRMURUNLER fRMURUNLER;
        FRMSIPARIS fRMSIPARIS;
        FRM_SIPARIS_DETAY fRM_SIPARIS_DETAY;
        

        private void pERSONELLERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fRMPERSONEL==null || fRMPERSONEL.IsDisposed)
            {
                fRMPERSONEL = new FRMPERSONEL();
                fRMPERSONEL.MdiParent = this;
            }
            fRMPERSONEL.Show();
        }

        private void kATEGORILERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fRMKATEGORI == null || fRMKATEGORI.IsDisposed)
            {
                fRMKATEGORI = new FRMKATEGORI();
                fRMKATEGORI.MdiParent = this;
            }
            fRMKATEGORI.Show();
        }

        private void mUSTERILERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fRMMUSTERI == null || fRMMUSTERI.IsDisposed)
            {
                fRMMUSTERI = new FRMMUSTERI();
                fRMMUSTERI.MdiParent = this;
            }
            fRMMUSTERI.Show();
        }

        private void tEDARIKCILERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fRMTEDARIKCI == null || fRMMUSTERI.IsDisposed)
            {
                fRMTEDARIKCI = new FRMTEDARIKCI();
                fRMTEDARIKCI.MdiParent = this;
            }
            fRMTEDARIKCI.Show();
        }

        private void üRÜNLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fRMURUNLER == null || fRMURUNLER.IsDisposed)
            {
                fRMURUNLER = new FRMURUNLER();
                fRMURUNLER.MdiParent = this;
            }
            fRMURUNLER.Show();
        }

        private void sIPARISLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sIPARISLERToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (fRMSIPARIS == null || fRMSIPARIS.IsDisposed)
            {
                fRMSIPARIS = new FRMSIPARIS();
                fRMSIPARIS.MdiParent = this;
            }
            fRMSIPARIS.Show();
        }

        private void tANIMLAMALARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sIPARISDETAYToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (fRM_SIPARIS_DETAY == null || fRM_SIPARIS_DETAY.IsDisposed)
            {
                fRM_SIPARIS_DETAY = new FRM_SIPARIS_DETAY();
                fRM_SIPARIS_DETAY.MdiParent = this;
            }
            fRM_SIPARIS_DETAY.Show();
        }
    }
}
