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

namespace AutomotiveGallery
{
    public partial class kayit_ol : Form
    {
        public kayit_ol()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");

        private void button1_Click(object sender, EventArgs e)
        {

            string sorgu = "insert into parola(ad,sifre)values(@v1,@v2)";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@v1", textBox1.Text);
            komut.Parameters.AddWithValue("@v2", textBox2.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız başarıyla tamamlandı.");
            textBox1.Clear();
            textBox2.Clear();
            baglanti.Close();
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }
    }
}
