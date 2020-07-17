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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from production.categories", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kategoriekle = new SqlCommand("exec kategoriekle @p1,@p2", baglanti);
            kategoriekle.Parameters.AddWithValue("@p1", textBox3.Text);
            kategoriekle.Parameters.AddWithValue("@p2", textBox1.Text);
            kategoriekle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kategoriSil = new SqlCommand("exec kategorisil @p1", baglanti);
            kategoriSil.Parameters.AddWithValue("@p1", textBox1.Text);
            kategoriSil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = no;
            textBox1.Text = name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kategoriGuncelle = new SqlCommand("exec kategoriguncelle @p1,@p2", baglanti);
            kategoriGuncelle.Parameters.AddWithValue("@p1", textBox3.Text);
            kategoriGuncelle.Parameters.AddWithValue("@p2", textBox1.Text);
            kategoriGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
