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
    public partial class Moizakazi : Form
    {
        public string idAv;
        public string hern;
        public string values;
        public string status;
        public string id;
        public string ad;
        public Moizakazi()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu mainMenu = new Menu();
            mainMenu.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `zapic` WHERE `uid`=@ad", db.GetConnection());
            command.Parameters.Add("@ad", MySqlDbType.VarChar).Value = id;
            


            adapter.SelectCommand = command;
            adapter.Fill(table);

            

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("У вас нет закзов");
                return;
            }

            status = table.Rows[0][9].ToString();
            values = table.Rows[0][8].ToString();
            idAv = table.Rows[0][10].ToString();


            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[2].ToString();
                data[data.Count - 1][2] = reader[1].ToString();
                data[data.Count - 1][3] = reader[8].ToString();
                data[data.Count - 1][4] = reader[10].ToString();
                data[data.Count - 1][5] = reader[7].ToString();
            }
            reader.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Обновленно");
            }
            else
                MessageBox.Show("Заказов нету");


            db.closeConnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `nameZ`=@val  WHERE `uid`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[4].Value.ToString();
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = row.Cells[2].Value.ToString();
            

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись изменена");

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Visible == true)
                label5.Visible = false;
            if (label2.Visible == true)
                label2.Visible = false;
            if (label6.Visible == false)
                label6.Visible = true;
            if (label8.Visible == false)
                label8.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (label5.Visible == false)
                label5.Visible = true;
            if (label2.Visible == false)
                label2.Visible = true;
            if (label6.Visible == true)
                label6.Visible = false;
            if (label8.Visible == true)
                label8.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DataGridViewRow roww = dataGridView1.CurrentRow;

            DB bd = new DB();
            DataTable datatable = new DataTable();

            MySqlDataAdapter dataadapter = new MySqlDataAdapter();

            MySqlCommand ccommand = new MySqlCommand("UPDATE `users` set `Valutka`=@val  WHERE `id`=@id", bd.GetConnection());
            ccommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = idAv;
            ccommand.Parameters.Add("@val", MySqlDbType.VarChar).Value = roww.Cells[3].Value.ToString();


            bd.openConnection();
            if (ccommand.ExecuteNonQuery() == 1)
            {
                

            }

            else
                MessageBox.Show("Ошибка");

            bd.closeConnection();

            DataGridViewRow row = dataGridView1.CurrentRow;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `Status`=@val  WHERE `uid`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[1].Value.ToString();
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = 0;

            if (status == "1")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
            }
            if (status == "0")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
            }

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Оплата выполнена");

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();





            DataGridViewRow rowww = dataGridView1.CurrentRow;

            DB dbb = new DB();
            DataTable datable = new DataTable();

            MySqlDataAdapter aadapter = new MySqlDataAdapter();

            MySqlCommand scommand = new MySqlCommand("DELETE FROM `zapic` WHERE `uid`=@id", dbb.GetConnection());
            scommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[1].Value.ToString();

            if (status == "1")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
            }
            if (status == "0")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
            }

            dbb.openConnection();

            if (scommand.ExecuteNonQuery() == 1)
                MessageBox.Show("Удалено");
            else
                MessageBox.Show("Ошибка");

            dbb.closeConnection();


        }
    }
}
