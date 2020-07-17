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
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunekle = new SqlCommand("exec ürünekle @p1,@p2,@p3,@p4,@p5,@p6", baglanti);
            urunekle.Parameters.AddWithValue("@p1", textBox1.Text);
            urunekle.Parameters.AddWithValue("@p2", textBox2.Text);
            urunekle.Parameters.AddWithValue("@p3", textBox3.Text);
            urunekle.Parameters.AddWithValue("@p4", textBox6.Text);
            urunekle.Parameters.AddWithValue("@p5", textBox5.Text);
            urunekle.Parameters.AddWithValue("@p6", textBox4.Text);
            
            urunekle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void products_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from production.products", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunSil = new SqlCommand("exec urunsil @p1", baglanti);
            urunSil.Parameters.AddWithValue("@p1", textBox2.Text);

            urunSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string brand = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string category = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string year = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string price = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            

            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = brand;
            textBox6.Text = category;
            textBox5.Text = year;
            textBox4.Text = price;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunGuncelle = new SqlCommand("exec urunguncelle @p,@p1,@p2,@p3", baglanti);
            urunGuncelle.Parameters.AddWithValue("@p", textBox1.Text);
            urunGuncelle.Parameters.AddWithValue("@p1", textBox2.Text);
            urunGuncelle.Parameters.AddWithValue("@p2", textBox5.Text);
            urunGuncelle.Parameters.AddWithValue("@p3", textBox4.Text);



            urunGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand urunsayisi = new SqlCommand("select dbo.urunsayisi(@dukkan)", baglanti);
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
