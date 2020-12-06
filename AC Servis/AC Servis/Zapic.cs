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
    public partial class Zapic : Form
    {
        public string id8;
        public Zapic()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (Zakazi())
                return;


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `zapic` (`nameZ`, `uid`, `vidwork`, `mark`, `date`, `idAv`, `nameAv`, `Payment`,`Status`,`idAvu`) VALUES (@naz, @id, @vid, @marka, @data,'0','0','0','0','0')", db.GetConnection());

            command.Parameters.Add("@naz", MySqlDbType.VarChar).Value = nazv.Text;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = label9.Text;
            command.Parameters.Add("@vid", MySqlDbType.VarChar).Value = vidrab.Text;
            command.Parameters.Add("@marka", MySqlDbType.VarChar).Value = marka.Text;
            command.Parameters.Add("@data", MySqlDbType.VarChar).Value = data.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись на рассмотрение");
                this.Hide();
                Menu mainMenu = new Menu();
                mainMenu.Show();
                mainMenu.id.Text = id8;

            }
            else
                MessageBox.Show("Нет мест");
            db.closeConnection();
        }

        public Boolean Zakazi()
        {
            String nazvi = nazv.Text;
            DB db = new DB();

            DataTable dataTable = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `zapic` WHERE `nameZ` = @naz", db.GetConnection());
            command.Parameters.Add("@naz", MySqlDbType.VarChar).Value = nazvi;

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Такой заказ уже есть, введите другой");
                return true;
            }
            else
                return false;

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu mainMenu = new Menu();
            mainMenu.Show();
            mainMenu.id.Text = id8;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
