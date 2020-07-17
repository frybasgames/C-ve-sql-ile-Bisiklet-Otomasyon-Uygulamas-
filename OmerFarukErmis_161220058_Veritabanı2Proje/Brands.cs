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
    public partial class Brands : Form
    {
        public Brands()
        {
            

            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            baglanti.Open();
            SqlCommand markaekle = new SqlCommand("exec markaekle @p1,@p2",baglanti);
           

            if(string.IsNullOrEmpty(textBox1.Text))
            {
                label5.Text = "HATA OLUSTU";
            }
            else
            {
                
                
                markaekle.Parameters.AddWithValue("@p1", textBox1.Text);
                markaekle.Parameters.AddWithValue("@p2", textBox2.Text);
                markaekle.ExecuteNonQuery();

            }
                
                baglanti.Close();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Brands_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from production.brands", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand markasil = new SqlCommand("exec markasil @p1", baglanti);
            markasil.Parameters.AddWithValue("@p1", textBox2.Text);
            markasil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox1.Text = no;
            textBox2.Text = name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand markaGuncelle = new SqlCommand("exec markaguncelle @p1,@p2", baglanti);
            markaGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            markaGuncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            markaGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            

        }
    }
}
