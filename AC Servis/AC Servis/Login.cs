﻿using MySql.Data.MySqlClient;
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
    public partial class Login : Form
    {
        public string kek;
        public int lol;
        public string admin;
        public Login()
        {
            InitializeComponent();
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 27);
        }

        public void bLogin_Click(object sender, EventArgs e)
        {
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL AND `pass`=@uP AND `Admin` != 'NULL'", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;


            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0
                
                )
            {
                MessageBox.Show("Такого аккаунта не существует");
                return;
            }
            
            
            admin = table.Rows[0][6].ToString();
            if (table.Rows.Count > 0 && admin == "0")
            {
                this.Hide();
                Menu mainForm = new Menu();
                mainForm.Show();
                mainForm.id.Text = table.Rows[0][0].ToString();
                mainForm.admin = table.Rows[0][6].ToString();
                mainForm.Valutka.Text = table.Rows[0][7].ToString();
            }

            else if (table.Rows.Count > 0 && admin == "1")
            {
                this.Hide();
                AdminPanel adminchik = new AdminPanel();
                adminchik.Show();
                adminchik.id.Text = table.Rows[0][0].ToString();
                adminchik.admin = table.Rows[0][6].ToString();
                adminchik.Valutka.Text = table.Rows[0][7].ToString();
            }
            else if (table.Rows.Count > 0 && admin == "2")
            {
                this.Hide();
                AvtoMesh adminc = new AvtoMesh();
                adminc.Show();
                adminc.id.Text = table.Rows[0][0].ToString();
                adminc.admin = table.Rows[0][6].ToString();
                adminc.nameAv = table.Rows[0][3].ToString();
                adminc.Valutka.Text = table.Rows[0][7].ToString();
            }
            else
            {
                MessageBox.Show("No");
            }

            


        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerFrom = new Register();
            registerFrom.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
