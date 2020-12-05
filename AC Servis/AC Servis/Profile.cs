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
            this.Hide();
            Menu mainMenu = new Menu();
            mainMenu.Show();
            mainMenu.id.Text = id1;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
