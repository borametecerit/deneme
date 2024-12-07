using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace E_Ticaret
{
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-35OLAMI\\SQLEXPRESS01;Initial Catalog=ECommerceDB;Integrated Security=True");


        private void Verilerigoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Products", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ProductID"].ToString();
                ekle.SubItems.Add(oku["ProductName"].ToString());
                ekle.SubItems.Add(oku["Description"].ToString());
                ekle.SubItems.Add(oku["Price"].ToString());
                ekle.SubItems.Add(oku["Stock"].ToString());
                ekle.SubItems.Add(oku["Category"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string urunadi = (string)textBox1.Text;
            string aciklama = (string)textBox2.Text;
            string fiyat = (string)textBox3.Text;
            int stok = (int)maskedTextBox1.Values;
            string kategori = (string)textBox5.Text;


            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Products(ProductName, Description, Price, Stock, Category) Values ()", baglanti);
        }
    }
}
