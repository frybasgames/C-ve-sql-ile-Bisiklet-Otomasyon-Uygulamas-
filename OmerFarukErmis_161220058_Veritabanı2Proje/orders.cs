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
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void orders_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from sales.orders", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand siparisekle = new SqlCommand("exec siparislerekle @p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8", baglanti);
            siparisekle.Parameters.AddWithValue("@p1", textBox1.Text);
            siparisekle.Parameters.AddWithValue("@p2", textBox2.Text);
            siparisekle.Parameters.AddWithValue("@p3", textBox3.Text);
            siparisekle.Parameters.AddWithValue("@p4", textBox6.Text);
            siparisekle.Parameters.AddWithValue("@p5", textBox5.Text);
            siparisekle.Parameters.AddWithValue("@p6", textBox4.Text);
            siparisekle.Parameters.AddWithValue("@p7", textBox9.Text);
            siparisekle.Parameters.AddWithValue("@p8", textBox8.Text);

            siparisekle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand siparisSil = new SqlCommand("exec siparissil @p1", baglanti);
            siparisSil.Parameters.AddWithValue("@p1", textBox1.Text);
            
            siparisSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string customer = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string orders = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string orderd = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string required = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string shipped = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string store = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string staff = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

            textBox1.Text = no;
            textBox2.Text = customer;
            textBox3.Text = orders;
            textBox6.Text = orderd;
            textBox5.Text = required;
            textBox4.Text = shipped;
            textBox9.Text = store;
            textBox8.Text = staff;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand siparisGuncelle = new SqlCommand("exec siparisguncelle @p1,@p2,@p3,@p4,@p5", baglanti);
          
            siparisGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            siparisGuncelle.Parameters.AddWithValue("@p2", textBox3.Text);
            siparisGuncelle.Parameters.AddWithValue("@p3", textBox6.Text);
            siparisGuncelle.Parameters.AddWithValue("@p4", textBox5.Text);
            siparisGuncelle.Parameters.AddWithValue("@p5", textBox4.Text);


            siparisGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
