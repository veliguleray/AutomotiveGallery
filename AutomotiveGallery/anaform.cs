using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomotiveGallery
{
    public partial class anaform : Form
    {
        public anaform()
        {
            InitializeComponent();
        }

        

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Subeler anafrm = new Subeler();
            anafrm.Show();
            this.Hide();
        }

        private void araçlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Araclar anafrm = new Araclar();
            anafrm.Show();
            this.Hide();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Müsteriler anafrm = new Müsteriler();
            anafrm.Show();
            this.Hide();
        }

        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personeller anafrm = new Personeller();
            anafrm.Show();
            this.Hide();
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raporlar anafrm = new Raporlar();
            anafrm.Show();
            this.Hide();
        }

        private void anaform_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Müsteriler anafrm = new Müsteriler();
            anafrm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Araclar anafrm = new Araclar();
            anafrm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Subeler anafrm = new Subeler();
            anafrm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Personeller anafrm = new Personeller();
            anafrm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Raporlar anafrm = new Raporlar();
            anafrm.Show();
            this.Hide();
        }
    }
}
