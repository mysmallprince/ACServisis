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
    public partial class AdminPanel : Form
    {

        public string admin;
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenZakazi zakazi = new MenZakazi();
            zakazi.Show();
            zakazi.id1 = id.Text;
            zakazi.ad = admin;
            zakazi.valll = Valutka.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.Show();
            profile.ad = admin;
            profile.id1 = id.Text;
            profile.valll = Valutka.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Avtomeshlist avtomeshlist = new Avtomeshlist();
            avtomeshlist.Show();
            avtomeshlist.id = id.Text;
            avtomeshlist.ad = admin;
            avtomeshlist.valll = Valutka.Text;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Balance balance = new Balance();
            balance.Show();
            balance.id = id.Text;
            balance.ad = admin;
            balance.valll = Valutka.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            

        }
    }
}
