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

namespace E_Ticaret
{
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-35OLAMI\\SQLEXPRESS01;Initial Catalog=ECommerceDB;Integrated Security=True");


        private async void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string query = "SELECT User_Name, Password, Rol FROM Users";
            SqlCommand komut = new SqlCommand(query, baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string userName = dt.Rows[i]["User_Name"].ToString();
                string password = dt.Rows[i]["Password"].ToString();
                int role = Convert.ToInt16(dt.Rows[i]["Rol"]);

                if (userName == textBox1.Text && password == textBox2.Text)
                {
                    MessageBox.Show("Giriş Başarılı.");
                    await Task.Delay(2000);
                    if (role == 0)
                    {
                        Form1 fr = new Form1();
                        fr.Show();
                        this.Hide();
                    }
                    else if (role == 1)
                    {
                        AdminPanel fr = new AdminPanel();
                        fr.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sistemler bir sıkıntı oldu. Tekrar deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Girilen bilgiler hatalı! Tekrar Deneyiniz.");
                }
                baglanti.Close();
            }

        }

    }
}
//Data Source=DESKTOP-35OLAMI\SQLEXPRESS01;Initial Catalog=ECommerceDB;Integrated Security=True;Trust Server Certificate=True