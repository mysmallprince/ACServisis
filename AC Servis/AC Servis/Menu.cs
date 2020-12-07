using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC_Servis
{
    public partial class Menu : Form
    {

        public string admin;
        public string id2;
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Zapic zapicFrom = new Zapic();
            zapicFrom.Show();
            zapicFrom.label9.Text = id.Text;
            zapicFrom.id8 = id.Text;
            zapicFrom.admin = admin;
            zapicFrom.valll = Valutka.Text;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Izmen izmenFrom = new Izmen();
            izmenFrom.Show();
            izmenFrom.id =id.Text;
            izmenFrom.admin = admin;
            izmenFrom.valll = Valutka.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Del delin = new Del();
            delin.Show();
            delin.id= id.Text;
            delin.admin = admin;
            delin.valll = Valutka.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profileForm = new Profile();
            profileForm.Show();
            profileForm.id1 = id.Text;
            profileForm.ad = admin;
            profileForm.valll = Valutka.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Moizakazi moizakazi = new Moizakazi();
            moizakazi.Show();
            moizakazi.id = id.Text;
            moizakazi.ad = admin;
            moizakazi.valll = Valutka.Text;
        }
    }
}
