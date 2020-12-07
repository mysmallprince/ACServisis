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
    
    public partial class AvtoMesh : Form
    {
        public string nameAv;
        public string admin;

        public AvtoMesh()
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
            VzyatZakaz vzyat = new VzyatZakaz();
            vzyat.Show();
            vzyat.id = id.Text;
            vzyat.ad = admin;
            vzyat.nameAv = nameAv;
            vzyat.valll = Valutka.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы уволились");
                this.Hide();
                Login login = new Login();
                login.Show();

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.Show();
            profile.ad = admin;
            profile.id1 = id.Text;
            profile.nameAv = nameAv;
            profile.valll = Valutka.Text;
        }
    }
}
