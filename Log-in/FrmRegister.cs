using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_in
{
    public partial class FrmRegister : Form
    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ASUS\source\repos\ProjectApp\Log-in\UKK.mdb");

        public FrmRegister()
        {
            InitializeComponent();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "First Name";
            txtLastName.Text = "Last Name";
            txtUsername.Text = "Username";
            txtEmail.Text = "Email";
            txtPassword.Text = "Password";
            
        }
       
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
         
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {

        }
        private void txtUsername_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {

        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {

        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {

        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

        }

        private void txtPassword_Leave(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                button3.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }


        private void cmdRegister_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Equals("") || txtFirstName.Text.Equals("First Name"))
            {
                MessageBox.Show("Input First Name", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtLastName.Text.Equals("") || txtLastName.Text.Equals("Last Name"))
            {
                MessageBox.Show("Input Last Name", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtEmail.Text.Equals("") || txtEmail.Text.Equals("Email"))
            {
                MessageBox.Show("Input Email", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            else
            {
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [User] values('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtEmail.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Register Success!");
                FrmLogin fl = new FrmLogin();
                fl.Show();
                Close();

            }
        }

            private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
