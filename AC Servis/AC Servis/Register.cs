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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            loginReg.Text = "Введите логин";
            passReg.Text = "Введите пароль";
        }

        private void passReg_Enter(object sender, EventArgs e)
        {
            if(passReg.Text == "Введите пароль")
                passReg.Text = "";
        }

        private void loginReg_Enter(object sender, EventArgs e)
        {
            if(loginReg.Text == "Введите логин")
                loginReg.Text = "";
        }

        private void loginReg_Leave(object sender, EventArgs e)
        {
            if (loginReg.Text == "")
                loginReg.Text = "Введите логин";
        }

        private void passReg_Leave(object sender, EventArgs e)
        {
            if (passReg.Text == "")
                passReg.Text = "Введите пароль";
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            if (loginReg.Text == "Введите логин") 
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (checkuser())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `Name`, `Famil`, `Otche`,`Admin`,`Valutka`) VALUES (@login, @pass, @name, @famil, @otche, @Admin,'0')", db.GetConnection());

            command.Parameters.Add("@login",MySqlDbType.VarChar).Value = loginReg.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passReg.Text;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = NameU.Text;
            command.Parameters.Add("@Famil", MySqlDbType.VarChar).Value = FamilU.Text;
            command.Parameters.Add("@Otche", MySqlDbType.VarChar).Value = OtcheU.Text;
            command.Parameters.Add("@Admin", MySqlDbType.VarChar).Value = Admin.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
                this.Hide();
                Login debil = new Login();
                debil.Show();
            }
            else
                MessageBox.Show("Аккаунт не был создан");

            db.closeConnection();
        }

        public Boolean checkuser()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginReg.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть, введите другой");
                    return true;
            }
            else
                    return false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginfrom = new Login();
            loginfrom.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
