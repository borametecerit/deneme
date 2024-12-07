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
using System.Data.Sql;
using System.Data.SqlClient;

namespace E_Ticaret
{
    public partial class KayıtOl : Form
    {
        public KayıtOl()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-35OLAMI\\SQLEXPRESS01;Initial Catalog=ECommerceDB;Integrated Security=True");


        private async void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Users (Name, Email, Address, Phone, Rol, User_Name, Password) Values ('"+ textBox1.Text+"','"+ textBox2.Text+"','"+ textBox3.Text+"','"+ textBox4.Text+"','"+ 0+"','"+ textBox5.Text+"','"+ textBox6.Text+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            MessageBox.Show("Kaydınız başarıyla tamamlandı.");
            await Task.Delay(3000);
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }
    }
}
