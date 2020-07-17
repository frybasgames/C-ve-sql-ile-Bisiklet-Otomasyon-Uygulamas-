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
    public partial class order_items : Form
    {
        public order_items()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void order_items_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from sales.order_items", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsiparisekle = new SqlCommand("exec ürünsiparisekle @p1,@p2,@p3,@p4,@p5,@p6", baglanti);
            urunsiparisekle.Parameters.AddWithValue("@p1", textBox1.Text);
            urunsiparisekle.Parameters.AddWithValue("@p2", textBox2.Text);
            urunsiparisekle.Parameters.AddWithValue("@p3", textBox3.Text);
            urunsiparisekle.Parameters.AddWithValue("@p4", textBox6.Text);
            urunsiparisekle.Parameters.AddWithValue("@p5", textBox5.Text);
            urunsiparisekle.Parameters.AddWithValue("@p6", textBox4.Text);

            urunsiparisekle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsiparisSil = new SqlCommand("exec urunsiparissil @p1,@p2,@p3", baglanti);
            urunsiparisSil.Parameters.AddWithValue("@p1", textBox1.Text);
            urunsiparisSil.Parameters.AddWithValue("@p2", textBox2.Text);
            urunsiparisSil.Parameters.AddWithValue("@p3", textBox3.Text);
            urunsiparisSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string item = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string product = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string quantity = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string list_price = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string discount = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            

            textBox1.Text = no;
            textBox2.Text = item;
            textBox3.Text = product;
            textBox6.Text = quantity;
            textBox5.Text = list_price;
            textBox4.Text = discount;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand urunsiparisGuncelle = new SqlCommand("exec urunsiparisguncelle @p1,@p2,@p3,@p4,@p5", baglanti);
            urunsiparisGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            urunsiparisGuncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            urunsiparisGuncelle.Parameters.AddWithValue("@p3", textBox3.Text);
            urunsiparisGuncelle.Parameters.AddWithValue("@p4", textBox6.Text);
            urunsiparisGuncelle.Parameters.AddWithValue("@p5", textBox4.Text);


            urunsiparisGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
