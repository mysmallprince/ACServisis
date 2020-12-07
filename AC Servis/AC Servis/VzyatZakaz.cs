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
        public string valll;
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
            avto.Valutka.Text = valll;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == true)
                dataGridView2.Visible = false;
            if (dataGridView1.Visible == false)
                dataGridView1.Visible = true;
            if (label2.Visible == true)
                label2.Visible = false;
            if (label5.Visible == false)
                label5.Visible = true;

            dataGridView1.Rows.Clear();

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `zapic` WHERE `idAV`='0' AND `nameAv` = '0' AND `Status` = '1'", db.GetConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 0)
            {
                MessageBox.Show("Заказов нету");
                return;
            }

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[9]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[9].ToString();
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

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `idAv`=@namz, `nameAv`=@vidwork, `idAvu`=@adVu, `Status`=@stat WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@vidwork", MySqlDbType.VarChar).Value = nameAv;
            command.Parameters.Add("@adVu", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@stat", MySqlDbType.VarChar).Value = 2;

            

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
                avto.Valutka.Text = valll;

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == false)
                dataGridView2.Visible = true;
            if (dataGridView1.Visible == true)
                dataGridView1.Visible = false;
            if (label2.Visible == false)
                label2.Visible = true;
            if (label5.Visible == true)
                label5.Visible = false;

            dataGridView2.Rows.Clear();

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `zapic` WHERE `idAV`= @id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Заказов нету");
                return;
            }

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
                dataGridView2.Rows.Add(s);
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
            if (dataGridView2.Visible == true)
                dataGridView2.Visible = false;
            if (label4.Visible == true)
                label4.Visible = false;
            if (label5.Visible == true)
                label5.Visible = false;
            if (label6.Visible == true)
                label6.Visible = false;
            if (textBox1.Visible == false)
                textBox1.Visible = true;
            if (label8.Visible == false)
                label8.Visible = true;
            if (label9.Visible == false)
                label9.Visible = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (label4.Visible == false)
                label4.Visible = true;
            if (label5.Visible == false)
                label5.Visible = true;
            if (label6.Visible == false)
                label6.Visible = true;
            if (textBox1.Visible == true)
                textBox1.Visible = false;
            if (label8.Visible == true)
                label8.Visible = false;
            if (label9.Visible == true)
                label9.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.CurrentRow;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `idAv`='0', `Payment`=@namz, `Status`=@vidwork WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();
            command.Parameters.Add("@namz", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@vidwork", MySqlDbType.VarChar).Value = 3;
            

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Чек отправлен");
                this.Hide();
                AvtoMesh avto = new AvtoMesh();
                avto.Show();
                avto.id.Text = id;
                avto.nameAv = nameAv;
                avto.admin = ad;
                avto.Valutka.Text = valll;

            }

            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

    }
    
    
}

