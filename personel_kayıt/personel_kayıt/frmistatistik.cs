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

namespace personel_kayıt
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection bağlanti = new SqlConnection("Data Source=DESKTOP-6QDVVSR\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void frmistatistik_Load(object sender, EventArgs e)
        {  
            //toplam personel sayısı
            bağlanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*)from Tbl_personel",bağlanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label2.Text = dr1[0].ToString();
            }
            bağlanti.Close();


            //evli personel sayısı
            bağlanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*)from tbl_personel where perdurum=1", bağlanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label4.Text = dr2[0].ToString();
            }
            bağlanti.Close();


            //bekar personel sayısı
            bağlanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*)from tbl_personel where perdurum=0", bağlanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                label6.Text = dr3[0].ToString();
            }
            bağlanti.Close();


            //toplam şehir sayısı
            bağlanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir))from tbl_personel", bağlanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                label8.Text = dr4[0].ToString();
            }
            bağlanti.Close();


            //toplam maaş
            bağlanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) from tbl_personel", bağlanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                label10.Text = dr5[0].ToString();
            }
            bağlanti.Close();


            //ortalama maaş
            bağlanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas)from tbl_personel", bağlanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label12.Text = dr6[0].ToString();
            }
            bağlanti.Close();
        }
    }
}
