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
    public partial class sales_summary : Form
    {
        public sales_summary()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void salesCüs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from sales.sales_summary", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand siparisozetEkle = new SqlCommand("exec siparisozetiekle @p1,@p2,@p3,@p4", baglanti);
            siparisozetEkle.Parameters.AddWithValue("@p1", textBox1.Text);
            siparisozetEkle.Parameters.AddWithValue("@p2", textBox2.Text);
            siparisozetEkle.Parameters.AddWithValue("@p3", textBox3.Text);
            siparisozetEkle.Parameters.AddWithValue("@p4", textBox6.Text);


            siparisozetEkle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand siparisozetSil = new SqlCommand("exec siparisozetsil @p1,@p2,@p3", baglanti);
            siparisozetSil.Parameters.AddWithValue("@p1", textBox1.Text);
            siparisozetSil.Parameters.AddWithValue("@p2", textBox2.Text);
            siparisozetSil.Parameters.AddWithValue("@p3", textBox3.Text);

            siparisozetSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string brand = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string cateogry = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string year = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string sales = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            

            textBox1.Text = brand;
            textBox2.Text = cateogry;
            textBox3.Text = year;
            textBox6.Text = sales;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand siparisozetGuncelle = new SqlCommand("exec siparisozetguncelle @p1,@p2,@p3,@p4", baglanti);
            siparisozetGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            siparisozetGuncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            siparisozetGuncelle.Parameters.AddWithValue("@p3", textBox3.Text);
            siparisozetGuncelle.Parameters.AddWithValue("@p4", textBox6.Text);

            siparisozetGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
