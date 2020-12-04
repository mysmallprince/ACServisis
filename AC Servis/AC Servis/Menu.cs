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
        public string id2;
        public Menu()
        {
            InitializeComponent();
            id.Text = id2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Zapic zapicFrom = new Zapic();
            zapicFrom.Show();
        }

        private void id_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Izmen izmenFrom = new Izmen();
            izmenFrom.Show();
            izmenFrom.id =id.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Del delin = new Del();
            delin.Show();
            delin.id= id.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profileForm = new Profile();
            profileForm.Show();
            profileForm.id1 = id.Text;
        }
    }
}
