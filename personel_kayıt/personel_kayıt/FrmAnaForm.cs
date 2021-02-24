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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection bağlanti = new SqlConnection("Data Source=DESKTOP-6QDVVSR\\ SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            txtİd.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            mskmaaş.Text = "";
            cmbşehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_personel (perad,persoyad,persehir,permaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", bağlanti);
            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbşehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaaş.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();
            bağlanti.Close();
            MessageBox.Show("personel eklendi");

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "true";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "false";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            cmbşehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaaş.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand sil = new SqlCommand("delete from Tbl_personel where perid=@k1", bağlanti);
            sil.Parameters.AddWithValue("@k1", txtİd.Text);
            sil.ExecuteNonQuery();
            bağlanti.Close();
            MessageBox.Show("kayıt silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            bağlanti.Open();
            SqlCommand güncelle = new SqlCommand("update Tbl_personel set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", bağlanti);
            güncelle.Parameters.AddWithValue("@a1",txtAd.Text);
            güncelle.Parameters.AddWithValue("@a2",txtSoyad.Text);
            güncelle.Parameters.AddWithValue("@a3",cmbşehir.Text);
            güncelle.Parameters.AddWithValue("@a4",mskmaaş.Text);
            güncelle.Parameters.AddWithValue("@a5",label8.Text);
            güncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            güncelle.Parameters.AddWithValue("@a7", txtİd.Text);
            güncelle.ExecuteNonQuery();
            bağlanti.Close();
            MessageBox.Show("personel bilgisi güncellendi");

        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
            
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
        }

     
    }
}
