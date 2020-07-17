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
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void customers_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from sales.customers", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand musteriekle = new SqlCommand("exec müsteriekle @p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9", baglanti);
            musteriekle.Parameters.AddWithValue("@p1", textBox1.Text);
            musteriekle.Parameters.AddWithValue("@p2", textBox2.Text);
            musteriekle.Parameters.AddWithValue("@p3", textBox3.Text);
            musteriekle.Parameters.AddWithValue("@p4", textBox6.Text);
            musteriekle.Parameters.AddWithValue("@p5", textBox5.Text);
            musteriekle.Parameters.AddWithValue("@p6", textBox4.Text);
            musteriekle.Parameters.AddWithValue("@p7", textBox9.Text);
            musteriekle.Parameters.AddWithValue("@p8", textBox8.Text);
            musteriekle.Parameters.AddWithValue("@p9", textBox7.Text);
            musteriekle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand musteriSil = new SqlCommand("exec musterisil @p1", baglanti);
            musteriSil.Parameters.AddWithValue("@p1", textBox2.Text);
            musteriSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string lastname = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string phone = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string email = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string street = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string city = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string state = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            string zipcode = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            
            textBox1.Text = no;
            textBox2.Text = name;
            textBox3.Text = lastname;
            textBox6.Text = phone;
            textBox5.Text = email;
            textBox4.Text = street;
            textBox9.Text = city;
            textBox8.Text = state;
            textBox7.Text = zipcode;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand musteriGuncelle = new SqlCommand("exec musteriguncelle @p,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8", baglanti);
            musteriGuncelle.Parameters.AddWithValue("@p", textBox1.Text);
            musteriGuncelle.Parameters.AddWithValue("@p1", textBox2.Text);
            musteriGuncelle.Parameters.AddWithValue("@p2", textBox3.Text);
            musteriGuncelle.Parameters.AddWithValue("@p3", textBox6.Text);
            musteriGuncelle.Parameters.AddWithValue("@p4", textBox5.Text);
            musteriGuncelle.Parameters.AddWithValue("@p5", textBox4.Text);
            musteriGuncelle.Parameters.AddWithValue("@p6", textBox9.Text);
            musteriGuncelle.Parameters.AddWithValue("@p7", textBox8.Text);
            musteriGuncelle.Parameters.AddWithValue("@p8", textBox7.Text);
            
            musteriGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
