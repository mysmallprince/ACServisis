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
    public partial class Profile : Form
    {
        public string valll;
        public string nameAv;
        public string ad;
        public string id1;
        public Profile()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("Update `users` set `login`=@login, `pass` =@pass, `Name`=@Name, `Famil`=@Famil, `Otche`=@Otche WHERE `id` =@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id1;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = nazv.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = id.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = vidrab.Text;
            command.Parameters.Add("@Famil", MySqlDbType.VarChar).Value = marka.Text;
            command.Parameters.Add("@Otche", MySqlDbType.VarChar).Value = data.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные обновлены");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (ad == "0")
            {
                this.Hide();
                Menu mainMenu = new Menu();
                mainMenu.Show();
                mainMenu.id.Text = id1;
                mainMenu.admin = ad;
                mainMenu.Valutka.Text = valll;
            }

            else if (ad == "1")
            {
                this.Hide();
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                adminPanel.id.Text = id1;
                adminPanel.admin = ad;
                adminPanel.Valutka.Text = valll;
            }
            else if (ad == "2")
            {
                this.Hide();
                AvtoMesh avto = new AvtoMesh();
                avto.Show();
                avto.id.Text = id1;
                avto.admin = ad;
                avto.nameAv = nameAv;
                avto.Valutka.Text = valll;
            }
            else
                MessageBox.Show("Вы даун");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void udal_Click(object sender, EventArgs e)
        {

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id1;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ваш профиль успешно удален");
                this.Hide();
                Login login = new Login();
                login.Show();

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }
    }
}
