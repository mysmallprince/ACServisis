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
    public partial class Balance : Form
    {
        int rom;
        public string id;
        public string valll;
        public string ad;
        public Balance()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
                
            
            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `users` set `Valutka`=`Valutka`+@namz WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = balnc.Text;


            

            db.openConnection();


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Баланс успешно пополнен");
                
            }

            else
                MessageBox.Show("Ошибка");


            db.closeConnection();


            DB dbb = new DB();
            DataTable ttable = new DataTable();

            MySqlDataAdapter aadapter = new MySqlDataAdapter();

            MySqlCommand ccommand = new MySqlCommand("SELECT * FROM `users` WHERE `id`=@id", dbb.GetConnection());
            ccommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            aadapter.SelectCommand = ccommand;
            aadapter.Fill(ttable);

            valll = ttable.Rows[0][7].ToString();

            dbb.openConnection();

            if (ad == "1")
            {
                this.Hide();
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                adminPanel.id.Text = id;
                adminPanel.admin = ad;
                adminPanel.Valutka.Text = valll;
            }
            if (ad == "2")
            {
                this.Hide();
                AvtoMesh avtoMesh = new AvtoMesh();
                avtoMesh.id.Text = id;
                avtoMesh.admin = ad;
                avtoMesh.Valutka.Text = valll;
            }
            if(ad == "0")
            {
                this.Hide();
                Menu mainMenu = new Menu();
                mainMenu.Show();
                mainMenu.id.Text = id;
                mainMenu.admin = ad;
                mainMenu.Valutka.Text = valll;
            }



            dbb.closeConnection();


        }

        private void balnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            e.Handled = !Char.IsDigit(number) && number != 8;
        }
    }
}
