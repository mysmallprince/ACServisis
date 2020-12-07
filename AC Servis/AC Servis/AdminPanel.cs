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
            if (button8.Visible == false)
                button8.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button1.Visible == true)
                button1.Visible = false;
            if (button2.Visible == true)
                button2.Visible = false;
            if (button3.Visible == true)
                button3.Visible = false;
            if (button4.Visible == true)
                button4.Visible = false;
            if (textBox1.Visible == false)
                textBox1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button8.Visible == true)
                button8.Visible = false;
            if (button6.Visible == true)
                button6.Visible = false;
            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (textBox1.Visible == true)
                textBox1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `users` set `Valutka`=`Valutka`+@namz WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id.Text;
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = textBox1.Text;



            

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Баланс успешно пополнен");
                if (button8.Visible == true)
                    button8.Visible = false;
                if (button6.Visible == true)
                    button6.Visible = false;
                if (button1.Visible == false)
                    button1.Visible = true;
                if (button2.Visible == false)
                    button2.Visible = true;
                if (button3.Visible == false)
                    button3.Visible = true;
                if (button4.Visible == false)
                    button4.Visible = true;
                if (textBox1.Visible == true)
                    textBox1.Visible = false;
            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }
    }
}
