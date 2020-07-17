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

namespace OmerFarukErmis_161220058_Veritabanı2Proje
{
    public partial class stores : Form
    {
        public stores()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void stores_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from sales.stores", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand magazaekleme = new SqlCommand("exec magazaekle @p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8", baglanti);
            

            
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label5.Text = "HATA OLUSTU";
            }
            else
            {
                magazaekleme.Parameters.AddWithValue("@p1", textBox1.Text);
                magazaekleme.Parameters.AddWithValue("@p2", textBox2.Text);
                magazaekleme.Parameters.AddWithValue("@p3", textBox3.Text);
                magazaekleme.Parameters.AddWithValue("@p4", textBox6.Text);
                magazaekleme.Parameters.AddWithValue("@p5", textBox5.Text);
                magazaekleme.Parameters.AddWithValue("@p6", textBox4.Text);
                magazaekleme.Parameters.AddWithValue("@p7", textBox9.Text);
                magazaekleme.Parameters.AddWithValue("@p8", textBox8.Text);
                magazaekleme.ExecuteNonQuery();
                
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand magazaSil = new SqlCommand("exec magazasil @p1", baglanti);
            magazaSil.Parameters.AddWithValue("@p1", textBox2.Text);

            magazaSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string phone = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string email = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string street = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string city = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string state = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string zipcode = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = phone;
            textBox6.Text = email;
            textBox5.Text = street;
            textBox4.Text = city;
            textBox9.Text = state;
            textBox8.Text = zipcode;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand magazaGuncelle = new SqlCommand("exec magazaguncelle @p,@p1,@p2,@p3,@p4,@p5,@p6,@p7", baglanti);
            magazaGuncelle.Parameters.AddWithValue("@p", textBox1.Text);
            magazaGuncelle.Parameters.AddWithValue("@p1", textBox2.Text);
            magazaGuncelle.Parameters.AddWithValue("@p2", textBox3.Text);
            magazaGuncelle.Parameters.AddWithValue("@p3", textBox6.Text);
            magazaGuncelle.Parameters.AddWithValue("@p4", textBox5.Text);
            magazaGuncelle.Parameters.AddWithValue("@p5", textBox4.Text);
            magazaGuncelle.Parameters.AddWithValue("@p6", textBox9.Text);
            magazaGuncelle.Parameters.AddWithValue("@p7", textBox8.Text);

            magazaGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsayisi = new SqlCommand("exec dbo.yillik_rapor5 @dukkan", baglanti);
            urunsayisi.Parameters.AddWithValue("@dukkan", textBox7.Text);
            urunsayisi.ExecuteNonQuery();
            baglanti.Close();
            SqlDataAdapter da = new SqlDataAdapter(urunsayisi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsayisi = new SqlCommand("exec dbo.aylik_rapor2 @dukkan", baglanti);
            urunsayisi.Parameters.AddWithValue("@dukkan", textBox7.Text);
            urunsayisi.ExecuteNonQuery();
            baglanti.Close();
            SqlDataAdapter da = new SqlDataAdapter(urunsayisi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsayisi = new SqlCommand("exec dbo.aylik_rapor2 @dukkan", baglanti);
            urunsayisi.Parameters.AddWithValue("@dukkan", textBox7.Text);
            urunsayisi.ExecuteNonQuery();
            baglanti.Close();
            SqlDataAdapter da = new SqlDataAdapter(urunsayisi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
    }
}
