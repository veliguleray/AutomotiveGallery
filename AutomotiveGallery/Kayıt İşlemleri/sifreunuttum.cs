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
using System.Data.Sql;
using System.Net;
using System.Net.Mail;
using System.Security;
//using System.Net.Mail;

namespace AutomotiveGallery
{
    public partial class sifreunuttum : Form
    {
        public sifreunuttum()
        {
            InitializeComponent();
        }



        SqlConnection baglanti = new SqlConnection("Data Source = 302-10; Initial Catalog = AutoGallery; User ID = WebMobile_302; Password=webmobile.302");






        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            //MailMessage ePosta = new MailMessage();
            //ePosta.From = new MailAddress("veliguleray@hotmail.com");
            //ePosta.To.Add(txt_Mail.Text); //göndereceğimiz mail adresi

            //ePosta.Subject = "Şifreniz: "; //mail konusu
            //ePosta.Body = "Şifre"; //mail içeriği 

            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("veliguleray@hotmail.com", "veliguleray@hotmail.com");
            //client.Port = 587;
            //client.Host = "smtp.outlook.com";
            //client.EnableSsl = true;
            //client.Send(ePosta);
            //object userState = true;
            //bool kontrol = true;
            //try
            //{
            //    client.SendAsync(ePosta, (object)ePosta);
            //}
            //catch (SmtpException ex)
            //{
            //    kontrol = false;
            //    MessageBox.Show(ex.Message);
            //}
            //return kontrol;
        



        }
        string sifre;
        private void btnGonder_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection baglanti = new SqlConnection("Data Source = 302-10; Initial Catalog = AutoGallery; User ID = WebMobile_302; Password=webmobile.302");
            //    if (baglanti.State == ConnectionState.Closed)
            //    {
            //        baglanti.Open();
            //    }
            //    SqlCommand komut = new SqlCommand("select * from ad where mail='" + txt_Mail.Text + "'");
            //    komut.Connection = baglanti;
            //    SqlDataReader oku = komut.ExecuteReader();
            //    if (oku.Read())
            //    {
            //        sifre = oku["sifre"].ToString();

            //        lblHata.Visible = true;
            //        lblHata.ForeColor = Color.Green;
            //        lblHata.Text = "Girmiş Olduğunuz Bilgiler Uyuşuyor Şifreniz Mail Olarak Gönderildi";

            //        progressBar1.Visible = true;
            //        progressBar1.Maximum = 900000;
            //        progressBar1.Minimum = 90;

            //        for (int j = 90; j < 900000; j++)
            //        {
            //            progressBar1.Value = j;
            //        }

            //        MailGonder("ŞİFRE HATIRLATMA", "Şifreniz: " + sifre);
            //        baglanti.Close();
            //    }
            //    else
            //    {
            //        lblHata.Visible = true;
            //        lblHata.ForeColor = Color.Red;
            //        lblHata.Text = "Girmiş Olduğunuz Bilgiler Uyuşmuyor";
            //    }
            //}
            //catch (Exception)
            //{
            //    lblHata.Visible = true;
            //    lblHata.ForeColor = Color.Red;
            //    lblHata.Text = "Mail Gönderme Hatası";
            //}

        }

        private void sifreunuttum_Load(object sender, EventArgs e)
        {

        }
    }
}
