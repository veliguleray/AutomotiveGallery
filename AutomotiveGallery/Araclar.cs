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
    public partial class Araclar : Form
    {
        public Araclar()
        {
            InitializeComponent();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Araclar_Load(object sender, EventArgs e)
        {

            getDats("select * from arac ");
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from arac", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "arac_id";
            comboBox1.DisplayMember = "arac_marka";
            comboBox1.DataSource = dt;
            baglanti.Close();
            
           
        }

        private void txt_aracno_TextChanged(object sender, EventArgs e)
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

        private void btn_ara_Click(object sender, EventArgs e)
        {
            string kmt = "select * from arac where arac_id like '%" + txt_arac_ara.Text + "%'";

            SqlCommand cmd = new SqlCommand(kmt, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];



            
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("update arac set arac_marka='" + txt_arac_marka.Text + "' where arac_id=" + comboBox1.SelectedValue.ToString(), baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SqlCommand kmt2 = new SqlCommand("select * from arac ", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(kmt2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            dataGridView1.DataSource = dt2;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");
            SqlCommand sorgu = new SqlCommand("insert into arac( arac_marka,arac_model,arac_segment,arac_yas,arac_durum,arac_km,arac_adeti,arac_sanziman,arac_motorhacim,arac_renk) " +
                "values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10)");

            baglanti.Open();

            string kayit = "insert into arac( arac_marka,arac_model,arac_segment,arac_yas,arac_durum,arac_km,arac_adeti,arac_sanziman,arac_motorhacim,arac_renk) " +
                "values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10)";


            SqlCommand kmt = new SqlCommand(kayit, baglanti);

            //kmt.Parameters.AddWithValue("@a1", comboBox1.SelectedValue.ToString());
            kmt.Parameters.AddWithValue("@a1", txt_arac_marka.Text);
            kmt.Parameters.AddWithValue("@a2", txt_model.Text);
            kmt.Parameters.AddWithValue("@a3", txt_arac_segment.Text);
            kmt.Parameters.AddWithValue("@a4", txt_arac_yas.Text);
            kmt.Parameters.AddWithValue("@a5", txt_arac_durum.Text);
            kmt.Parameters.AddWithValue("@a6", txt_arac_km.Text);
            kmt.Parameters.AddWithValue("@a7", txt_arac_adet.Text);
            kmt.Parameters.AddWithValue("@a8", txt_arac_sanziman.Text);
            kmt.Parameters.AddWithValue("@a9", txt_arac_motorHacim.Text);
            kmt.Parameters.AddWithValue("@a10", txt_arac_renk.Text);

            kmt.ExecuteNonQuery();

            baglanti.Close();
            getDats("Select * from arac");
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("delete from arac where arac_id=@id", baglanti);
            kmt.Parameters.AddWithValue("@id", comboBox1.SelectedValue.ToString());
            kmt.ExecuteNonQuery();
            baglanti.Close();
            getDats("select * from arac ");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");
            baglanti.Open();
            int val;
            int.TryParse(comboBox1.SelectedValue.ToString(), out val);
            SqlCommand kmt = new SqlCommand("select * from arac where arac_id=" + val, baglanti);
            //SqlDataReader dr= kmt.ExecuteReader();

            SqlDataAdapter da2 = new SqlDataAdapter(kmt);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            {
                txt_arac_marka.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txt_model.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_arac_segment.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txt_arac_yas.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txt_arac_durum.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txt_arac_km.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txt_arac_adet.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txt_arac_sanziman.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                txt_arac_motorHacim.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                txt_arac_renk.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();


            }
            baglanti.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txt_arac_marka_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
