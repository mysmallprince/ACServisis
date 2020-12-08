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
        public string valll;
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
            mainMenu.id.Text = id;
            mainMenu.admin = ad;
            mainMenu.Valutka.Text = valll;
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


            values = table.Rows[0][8].ToString();
            idAv = table.Rows[0][10].ToString();


            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[8]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[2].ToString();
                data[data.Count - 1][2] = reader[1].ToString();
                data[data.Count - 1][3] = reader[8].ToString();
                data[data.Count - 1][4] = reader[10].ToString();
                data[data.Count - 1][5] = reader[7].ToString();
                data[data.Count - 1][6] = reader[9].ToString();
                data[data.Count - 1][7] = reader[11].ToString();
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


            DataGridViewRow row = dataGridView1.CurrentRow;

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `zapic` set `Status`=@val  WHERE `id`=@id", db.GetConnection());
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Выберите заказ");
                return;
            }
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = 0;

            status = row.Cells[6].Value.ToString();

            if (status == "2")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
                if (label5.Visible == false)
                    label5.Visible = true;
                if (label2.Visible == false)
                    label2.Visible = true;
                if (label6.Visible == true)
                    label6.Visible = false;
                if (label8.Visible == true)
                    label8.Visible = false;
                return;
            }

            if (status == "1")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
                if (label5.Visible == false)
                    label5.Visible = true;
                if (label2.Visible == false)
                    label2.Visible = true;
                if (label6.Visible == true)
                    label6.Visible = false;
                if (label8.Visible == true)
                    label8.Visible = false;
                return;
            }
            if (status == "0")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
                if (label5.Visible == false)
                    label5.Visible = true;
                if (label2.Visible == false)
                    label2.Visible = true;
                if (label6.Visible == true)
                    label6.Visible = false;
                if (label8.Visible == true)
                    label8.Visible = false;
                return;
            }

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {


            }

            else
                MessageBox.Show("Ошибка");






            MySqlCommand ccommand = new MySqlCommand("UPDATE `users` set `Valutka`=`Valutka`+((@val*90)/100)  WHERE `id`=@id", db.GetConnection());
            ccommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[7].Value.ToString();
            ccommand.Parameters.Add("@val", MySqlDbType.VarChar).Value = row.Cells[3].Value.ToString();

            if (status == "2")
            {
                return;
            }
            if (status == "1")
            {
                return;
            }
            if (status == "0")
                return;


            if (ccommand.ExecuteNonQuery() == 1)
            {


            }

            else
                MessageBox.Show("Ошибка");



            MySqlCommand cccommand = new MySqlCommand("UPDATE `users` set `Valutka`=`Valutka`+((@val*10)/100)  WHERE `id`=@id", db.GetConnection());
            cccommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[4].Value.ToString();
            cccommand.Parameters.Add("@val", MySqlDbType.VarChar).Value = row.Cells[3].Value.ToString();

            if (status == "2")
            {
                return;
            }
            if (status == "1")
            {
                return;
            }
            if (status == "0")
                return;


            if (cccommand.ExecuteNonQuery() == 1)
            {


            }

            else
                MessageBox.Show("Ошибка");







            MySqlCommand scommand = new MySqlCommand("DELETE FROM `zapic` WHERE `id`=@id", db.GetConnection());
            scommand.Parameters.Add("@id", MySqlDbType.VarChar).Value = row.Cells[0].Value.ToString();

            status = row.Cells[6].Value.ToString();
            if (status == "2")
            {
                MessageBox.Show("Этот заказ нельзя оплатить");
                if (label5.Visible == false)
                    label5.Visible = true;
                if (label2.Visible == false)
                    label2.Visible = true;
                if (label6.Visible == true)
                    label6.Visible = false;
                if (label8.Visible == true)
                    label8.Visible = false;
                return;
            }


             if (status == "1")
             {
                    MessageBox.Show("Этот заказ нельзя оплатить");
                    if (label5.Visible == false)
                        label5.Visible = true;
                    if (label2.Visible == false)
                        label2.Visible = true;
                    if (label6.Visible == true)
                        label6.Visible = false;
                    if (label8.Visible == true)
                        label8.Visible = false;
                    return;
             }
             if (status == "0")
             {
                    MessageBox.Show("Этот заказ нельзя оплатить");
                    if (label5.Visible == false)
                        label5.Visible = true;
                    if (label2.Visible == false)
                        label2.Visible = true;
                    if (label6.Visible == true)
                        label6.Visible = false;
                    if (label8.Visible == true)
                        label8.Visible = false;
                    return;
             }



             if (scommand.ExecuteNonQuery() == 1)
             {
                    MessageBox.Show("Оплачено");
                    if (label5.Visible == false)
                        label5.Visible = true;
                    if (label2.Visible == false)
                        label2.Visible = true;
                    if (label6.Visible == true)
                        label6.Visible = false;
                    if (label8.Visible == true)
                        label8.Visible = false;
                this.label4_Click(sender,e);
             }
                else
                    MessageBox.Show("Ошибка");


                db.closeConnection();


            
        }
    }
}
