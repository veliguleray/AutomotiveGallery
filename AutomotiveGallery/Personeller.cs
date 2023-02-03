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
    public partial class Personeller : Form
    {
        public Personeller()
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
            string kayit = "insert into personel(personel_ad, personel_soyad, personel_yas, personel_tc, personel_telefon,personel_kidem) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6)";

            SqlCommand kmt = new SqlCommand(kayit, baglanti);

            kmt.Parameters.AddWithValue("@p1", txt_ad.Text);
            kmt.Parameters.AddWithValue("@p2", txt_soyad.Text);
            kmt.Parameters.AddWithValue("@p3", txt_yas.Text);
            kmt.Parameters.AddWithValue("@p4", txt_tc.Text);
            kmt.Parameters.AddWithValue("@p5", txt_tel.Text);
            kmt.Parameters.AddWithValue("@p6", txt_kıdem.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            getDats("Select * from personel");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("update personel set personel_ad='" + txt_ad.Text + "' where personel_id=" + comboBox1_id.SelectedValue.ToString(), baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlCommand kmt2 = new SqlCommand("select * from personel", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(kmt2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            dataGridView1.DataSource = dt2;
        }

        private void Personeller_Load(object sender, EventArgs e)
        {

            getDats("select * from personel ");
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from personel", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1_id.ValueMember = "personel_id";
            comboBox1_id.DisplayMember = "personel_ad";
            comboBox1_id.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_id_SelectedIndexChanged(object sender, EventArgs e)
        {


            SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");
            baglanti.Open();
            int val;
            int.TryParse(comboBox1_id.SelectedValue.ToString(), out val);
            SqlCommand kmt = new SqlCommand("select * from personel where personel_id=" + val, baglanti);

            SqlDataAdapter da2 = new SqlDataAdapter(kmt);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            {
                txt_ad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_soyad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_yas.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_tc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_tel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txt_kıdem.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                


            }
            baglanti.Close();

        }

        private void comboBox2_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
