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
    public partial class Izmen : Form
    {
        public string id;
        public Izmen()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("Update `zapic` set `vidwork` =@new , `date` =@srok  where uid = @id", db.GetConnection());
            

        
           command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
           command.Parameters.Add("@new", MySqlDbType.VarChar).Value = textBox1.Text;

           command.Parameters.Add("@srok", MySqlDbType.VarChar).Value = textBox3.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись изменена");

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu mainMenu = new Menu();
            mainMenu.Show();
            mainMenu.id.Text = id;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
