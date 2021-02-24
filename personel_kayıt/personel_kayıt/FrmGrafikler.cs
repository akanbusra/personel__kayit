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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection bağlanti = new SqlConnection("Data Source=DESKTOP-6QDVVSR\\ SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //grafik1
            bağlanti.Open();
            SqlCommand komut1 = new SqlCommand("select persehir,count(*) from tbl_personel group by persehir", bağlanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            bağlanti.Close();


            //grafik2
            bağlanti.Open();
            SqlCommand komut2 = new SqlCommand("select permeslek,avg(permaas) from tbl_personel group by permeslek", bağlanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }

            bağlanti.Close();

        }
    }
}
