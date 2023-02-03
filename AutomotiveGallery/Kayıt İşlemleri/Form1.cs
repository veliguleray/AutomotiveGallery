using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutomotiveGallery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        SqlConnection baglanti = new SqlConnection("Data Source=302-10;Initial Catalog=AutoGallery;User ID=WebMobile_302;Password=webmobile.302");




        private void button_girisyap_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "Select * From parola where Ad=@adi AND sifre=@sifresi";
                SqlParameter prmt1 = new SqlParameter("adi", textBox_login.Text.Trim());
                SqlParameter prmt2 = new SqlParameter("sifresi", textBox_password.Text.Trim());

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prmt1);
                komut.Parameters.Add(prmt2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    anaform fr = new anaform();
                    fr.Show();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("hatalı giriş");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayit_ol anafrm = new kayit_ol();
            anafrm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreunuttum anafrm = new sifreunuttum();
            anafrm.Show();
            this.Hide();
        }
    }
}
