using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OmerFarukErmis_161220058_Veritabanı2Proje
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FCQCGGD\\FARUK;Initial Catalog=deneme;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Brands brands = new Brands();
            brands.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Categories category = new Categories();
            category.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stocks stok = new Stocks();
            stok.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            products product = new products();
            product.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customers customer = new customers();
            customer.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            order_items orderitem = new order_items();
            orderitem.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            orders order = new orders();
            order.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            staffs staff = new staffs();
            staff.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            stores store = new stores();
            store.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sales_summary salessummary = new sales_summary();
            salessummary.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                baglanti.Open();
                SqlCommand aramarka = new SqlCommand("exec markaara @p", baglanti);
                aramarka.Parameters.AddWithValue("@p", textBox4.Text);

                //aramarka.Parameters.AddWithValue("@p1", deger);
                aramarka.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(aramarka);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                baglanti.Open();
                SqlCommand kategoriAra = new SqlCommand("exec kategoriara @p", baglanti);
                kategoriAra.Parameters.AddWithValue("@p", textBox4.Text);
                kategoriAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(kategoriAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlCommand StokAra = new SqlCommand("exec stokara @p", baglanti);
                StokAra.Parameters.AddWithValue("@p", textBox4.Text);
                StokAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(StokAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                baglanti.Open();
                SqlCommand urunAra = new SqlCommand("exec urunara @p", baglanti);
                
                urunAra.Parameters.AddWithValue("@p", textBox4.Text);
                urunAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(urunAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                baglanti.Open();
                SqlCommand musteriAra = new SqlCommand("exec musteriara @p", baglanti);
                
                musteriAra.Parameters.AddWithValue("@p", textBox4.Text);
                musteriAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(musteriAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                baglanti.Open();
                SqlCommand siparisurunAra = new SqlCommand("exec siparisurunara @p", baglanti);
                
                siparisurunAra.Parameters.AddWithValue("@p", textBox4.Text);
                siparisurunAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(siparisurunAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                baglanti.Open();
                SqlCommand siparisAra = new SqlCommand("exec siparisara @p", baglanti);
                
                siparisAra.Parameters.AddWithValue("@p", textBox4.Text);
                siparisAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(siparisAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                baglanti.Open();
                SqlCommand siparisozetAra = new SqlCommand("exec siparisozetara @p", baglanti);
                
                siparisozetAra.Parameters.AddWithValue("@p", textBox4.Text);
                siparisozetAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(siparisozetAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                baglanti.Open();
                SqlCommand personelAra = new SqlCommand("exec personelara @p", baglanti);
                
                personelAra.Parameters.AddWithValue("@p", textBox4.Text);
                personelAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(personelAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                baglanti.Open();
                SqlCommand magazaAra = new SqlCommand("exec magazaara @p", baglanti);

                
                magazaAra.Parameters.AddWithValue("@p", textBox4.Text);
                magazaAra.ExecuteNonQuery();
                baglanti.Close();
                SqlDataAdapter da = new SqlDataAdapter(magazaAra);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }
    }
}