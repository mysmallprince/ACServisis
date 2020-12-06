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
    public partial class MenZakazi : Form
    {
        public string ad;
        public string id1;
        public string id;
        public MenZakazi()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `zapic`", db.GetConnection());
            
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Пусто");
                return;
            }
            id = table.Rows[0][0].ToString();

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[8]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
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

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `nameZ`=@namz, `vidwork`=@vidwork, `mark`=@mark,`date`=@data WHERE `id`=@id" , db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = row.Cells[1].Value.ToString();
            command.Parameters.Add("@vidwork", MySqlDbType.VarChar).Value = row.Cells[3].Value.ToString();
            command.Parameters.Add("@mark", MySqlDbType.VarChar).Value = row.Cells[4].Value.ToString();
            command.Parameters.Add("@data", MySqlDbType.VarChar).Value = row.Cells[5].Value.ToString();
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
            DataGridViewRow row = dataGridView1.CurrentRow;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `zapic` WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = row.Cells[1].Value.ToString();
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись удалить");

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            adminPanel.id.Text = id1;
            adminPanel.admin = ad;
        }

    }
}
