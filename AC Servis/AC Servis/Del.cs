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
    public partial class Del : Form
    {

        public string id;
        public Del()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `zapic` WHERE `uid`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Удалено");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu mainMenu = new Menu();
            mainMenu.Show();
        }
    }
}
