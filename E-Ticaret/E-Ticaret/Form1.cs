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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategoriler fr = new Kategoriler();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciGiris fr = new KullaniciGiris();
            fr.Show(); 
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KayıtOl fr = new KayıtOl();
            fr.Show();
            this.Hide();
        }
    }
}
