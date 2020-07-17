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
    public partial class staffs : Form
    {
        public staffs()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void staffs_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from sales.staffs", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand personelekleme = new SqlCommand("exec personelekle @p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8", baglanti);
            personelekleme.Parameters.AddWithValue("@p1", textBox1.Text);
            personelekleme.Parameters.AddWithValue("@p2", textBox2.Text);
            personelekleme.Parameters.AddWithValue("@p3", textBox3.Text);
            personelekleme.Parameters.AddWithValue("@p4", textBox6.Text);
            personelekleme.Parameters.AddWithValue("@p5", textBox5.Text);
            personelekleme.Parameters.AddWithValue("@p6", textBox4.Text);
            personelekleme.Parameters.AddWithValue("@p7", textBox9.Text);
            personelekleme.Parameters.AddWithValue("@p8", textBox8.Text);

            personelekleme.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand personelSil = new SqlCommand("exec personelsil @p1", baglanti);
            personelSil.Parameters.AddWithValue("@p1", textBox2.Text);

            personelSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            string lastname = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            string email = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            string phone = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            string active = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string store = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string manager = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            

            textBox1.Text = no;
            textBox2.Text = name;
            textBox3.Text = lastname;
            textBox6.Text = email;
            textBox5.Text = phone;
            textBox4.Text = active;
            textBox9.Text = store;
            textBox8.Text = manager;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand personelGuncelle = new SqlCommand("exec personelguncelle @p,@p1,@p2,@p3,@p4,@p5", baglanti);
            personelGuncelle.Parameters.AddWithValue("@p", textBox1.Text);
            personelGuncelle.Parameters.AddWithValue("@p1", textBox2.Text);
            personelGuncelle.Parameters.AddWithValue("@p2", textBox3.Text);
            personelGuncelle.Parameters.AddWithValue("@p3", textBox6.Text);
            personelGuncelle.Parameters.AddWithValue("@p4", textBox5.Text);
            personelGuncelle.Parameters.AddWithValue("@p5", textBox4.Text);
            
            personelGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select dbo.personelsayisi(5)", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
