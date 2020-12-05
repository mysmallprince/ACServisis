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
    public partial class VzyatZakaz : Form
    {
        public string nameAv;
        public string id;
        public string ad;
        public VzyatZakaz()
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
            AvtoMesh avto = new AvtoMesh();
            avto.Show();
            avto.id.Text = id;
            avto.admin = ad;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `zapic` WHERE `idAV`='0' ", db.GetConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);

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

        private void label5_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `idAv`=@namz, `nameAv`=@vidwork WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@vidwork", MySqlDbType.VarChar).Value = nameAv;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Заказ взят");
                this.Hide();
                AvtoMesh avto = new AvtoMesh();
                avto.Show();
                avto.id.Text = id;
                avto.nameAv = nameAv;
                avto.admin = ad;

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }
    }
    
}

