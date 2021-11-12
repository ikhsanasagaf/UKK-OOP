using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Log_in
{
    public partial class FrmLogin : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ASUS\source\repos\ProjectApp\Log-in\UKK.mdb");

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void label1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.ForeColor = ColorTranslator.FromHtml("#8f3939");
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.ForeColor = ColorTranslator.FromHtml("#eb9898");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                button3.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Equals("") || txtUsername.Text.Equals("Username"))
            {
                MessageBox.Show("Input Username", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Equals("") || txtPassword.Text.Equals("Password"))
            {
                MessageBox.Show("Input Password", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OleDbDataAdapter da = new OleDbDataAdapter("select count(*) from [User] where Username='" + txtUsername.Text + "'and Password='" + txtPassword.Text + "'", con);

            // buat data tabel
            DataTable dt = new DataTable();

            //fill data tabel
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                // means the username and password is correct
                FrmMain fc = new FrmMain();
                fc.Show();
                this.Hide();

            }
            else
            {
                //means the username or password is incorrect
                MessageBox.Show("Login Failed!");
            }

        }
    }
}