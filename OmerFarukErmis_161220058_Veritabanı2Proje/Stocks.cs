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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void Stocks_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from production.stocks", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand stokekleme = new SqlCommand("exec stokekle @p1,@p2,@p3", baglanti);
            stokekleme.Parameters.AddWithValue("@p1", textBox1.Text);
            stokekleme.Parameters.AddWithValue("@p2", textBox2.Text);
            stokekleme.Parameters.AddWithValue("@p3", textBox3.Text);



            stokekleme.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand stokSil = new SqlCommand("exec stoksil @p1,@p2", baglanti);
            stokSil.Parameters.AddWithValue("@p1", textBox1.Text);
            stokSil.Parameters.AddWithValue("@p2", textBox2.Text);

            stokSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string sid = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string pid = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string quantity = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            

            textBox1.Text = sid;
            textBox2.Text = pid;
            textBox3.Text = quantity;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand stokGuncelle = new SqlCommand("exec stokguncelle @p1,@p2,@p3", baglanti);
            stokGuncelle.Parameters.AddWithValue("@p1", textBox1.Text);
            stokGuncelle.Parameters.AddWithValue("@p2", textBox2.Text);
            stokGuncelle.Parameters.AddWithValue("@p3", textBox3.Text);

            stokGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
