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
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void FrmGiriş_Load(object sender, EventArgs e)
        {

        }

        SqlConnection bağlanti = new SqlConnection("Data Source=DESKTOP-6QDVVSR\\ SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void btngiriş_Click(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_yonetici where kullaniciad=@p1 and sifre=@p2", bağlanti);
            komut.Parameters.AddWithValue("@p1",txtkullanıcıadi.Text);
            komut.Parameters.AddWithValue("@p2", txtşifre.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATA!! Kullanıcı adı veya şifre hatalı!");
            }

            bağlanti.Close();

        }
    }
}
