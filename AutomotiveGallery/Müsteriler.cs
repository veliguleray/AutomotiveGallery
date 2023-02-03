using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomotiveGallery
{
    public partial class Müsteriler : Form
    {
        public Müsteriler()
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

        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void txt_arac_ara_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");
        public void getDats(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");
            baglanti.Open();
            string kayit = "insert into müsteri(müsteri_adi, müsteri_soyadi, müsteri_tc, müsteri_mail, müsteri_telefon,müsteri_yas,müsteri_adres) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";

            SqlCommand kmt = new SqlCommand(kayit, baglanti);

            kmt.Parameters.AddWithValue("@p1", txt_ad.Text);
            kmt.Parameters.AddWithValue("@p2", txt_soyadi.Text);
            kmt.Parameters.AddWithValue("@p3", txt_tc.Text);
            kmt.Parameters.AddWithValue("@p4", txt_mail.Text);
            kmt.Parameters.AddWithValue("@p5", txt_tel.Text);
            kmt.Parameters.AddWithValue("@p6", txt_yas.Text);
            kmt.Parameters.AddWithValue("@p7", txt_adres.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            getDats("Select * from müsteri");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("update müsteri set müsteri_adi='" + txt_ad.Text + "' where müsteri_id=" + comboBox1.SelectedValue.ToString(), baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlCommand kmt2 = new SqlCommand("select * from müsteri", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(kmt2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            dataGridView1.DataSource = dt2;
        }

        private void Müsteriler_Load(object sender, EventArgs e)
        {

            getDats("select * from müsteri ");
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from müsteri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "müsteri_id";
            comboBox1.DisplayMember = "müsteri_adi";
            comboBox1.DataSource = dt;
            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
