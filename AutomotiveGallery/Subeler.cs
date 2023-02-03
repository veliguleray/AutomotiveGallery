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
    public partial class Subeler : Form
    {
        public Subeler()
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

        private void label8_Click(object sender, EventArgs e)
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
            //SqlCommand sorgu = new SqlCommand("insert into sube( sube_id,sube_ad, sube_il, sube_ilce, sube_kodu, sube_calisan_sayisi,sube_ciro) " +
            //    "values (@sube_id,@sube_ad,@sube_il,@sube_ilce,@sube_kodu,@sube_calisan_sayisi,@sube_ciro");

            baglanti.Open();

            string kayit = "insert into sube(sube_ad, sube_il, sube_ilce, sube_kodu, sube_calisan_sayisi,sube_ciro) " +
                "values (@sube_ad,@sube_il,@sube_ilce,@sube_kodu,@sube_calisan_sayisi,@sube_ciro)";


            SqlCommand kmt = new SqlCommand(kayit, baglanti);

            kmt.Parameters.AddWithValue("@sube_ad", txt_ad.Text);
            kmt.Parameters.AddWithValue("@sube_il", txt_il.Text);
            kmt.Parameters.AddWithValue("@sube_ilce", txt_ilce.Text);
            kmt.Parameters.AddWithValue("@sube_kodu", txt_kod.Text);
            kmt.Parameters.AddWithValue("@sube_calisan_sayisi", txt_calisan.Text);
            kmt.Parameters.AddWithValue("@sube_ciro", txt_ciro.Text);


            kmt.ExecuteNonQuery();

            baglanti.Close();
            getDats("Select * from sube");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("update sube set sube_ad='" + txt_ad.Text + "' where sube_id=" + comboBox1_id.SelectedValue.ToString(), baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlCommand kmt2 = new SqlCommand("select * from sube", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(kmt2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            dataGridView1.DataSource = dt2;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");
            baglanti.Open();
            int val;
            int.TryParse(comboBox1_id.SelectedValue.ToString(), out val);
            SqlCommand kmt = new SqlCommand("select * from sube where sube_id=" + val, baglanti);
            //SqlDataReader dr= kmt.ExecuteReader();

            SqlDataAdapter da2 = new SqlDataAdapter(kmt);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            {
                txt_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_il.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_ilce.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_kod.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_calisan.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_ciro.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


            }
            baglanti.Close();

        }

        private void Subeler_Load(object sender, EventArgs e)
        {



            getDats("select * from sube ");
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from sube", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1_id.ValueMember = "sube_id";
            comboBox1_id.DisplayMember = "sube_ad";
            comboBox1_id.DataSource = dt;
            baglanti.Close();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            comboBox1_id.Text = "";
            txt_ad.Clear();
            txt_il.Clear();
            txt_ilce.Clear();
            txt_ciro.Clear();
            txt_calisan.Clear();
            txt_kod.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            this.Controls.Clear();

            this.InitializeComponent();


            SqlCommand kmt = new SqlCommand("select * from sube", baglanti);
            //SqlDataReader dr= kmt.ExecuteReader();

            SqlDataAdapter da2 = new SqlDataAdapter(kmt);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

        }



        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0)
            {
                int secilenIndeks = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow secilenSatir = dataGridView1.Rows[secilenIndeks];
                string silinecek = Convert.ToString(secilenSatir.Cells["sube_id"].Value);

                string sql = "DELETE FROM sube WHERE sube_id=" + silinecek;

                getDats("select * from sube ");
            }
        }
    }
}
