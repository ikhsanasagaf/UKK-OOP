using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Log_in
{
    public partial class To_Do : UserControl        

    {

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\ASUS\source\repos\ProjectApp\Log-in\UKK.mdb");
        int count = 0;
        public To_Do()
        {
            InitializeComponent();
            
        }

        private void To_Do_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {

            if (txtProdname.Text == "" || txtStock.Text == "" || txtPrice.Text == "" || txtDesc.Text == "")
            {
                MessageBox.Show("Fill the Values!");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Stock (ProdName, Stock, Price, Description) VALUES ('" + txtProdname.Text + "', '" + txtStock.Text + "','" + txtPrice.Text + "','" + txtDesc.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtProdname.Text = "";
                    txtStock.Text = "";
                    txtPrice.Text = "";
                    txtDesc.Text = "";
                    MessageBox.Show("Product Successfully added!");
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtProdname.Text == "" || txtStock.Text == ""  || txtPrice.Text == "" || txtDesc.Text == "" || txtID.Text == "")
            {
                MessageBox.Show("Fill THe Values!");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    string query = "update Stock set ProdName='" + txtProdname.Text + "',Stock='" + txtStock.Text + "',Price ='" + txtPrice.Text + "',Description='" + txtDesc.Text + "' where ID =" +txtID.Text+"" ;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtProdname.Text = "";
                    txtStock.Text = "";
                    txtPrice.Text = "";
                    txtDesc.Text = "";
                    txtID.Text = "";
                    MessageBox.Show("Product Successfully edited!");
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtID.Text == "")
            {
                MessageBox.Show("Fill the Values!");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    string query = "delete from Stock where ID=" + txtID.Text + "";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtID.Text = "";
                    txtProdname.Text = "";
                    txtStock.Text = "";
                    txtPrice.Text = "";
                    txtDesc.Text = "";
                    MessageBox.Show("Data Successfully Deleted!");
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value.ToString();
            txtProdname.Text = row.Cells[1].Value.ToString();
            txtStock.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            txtDesc.Text = row.Cells[4].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Stock";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Stock where ProdName='" + txtSearch.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView1.DataSource = dt;
            con.Close();


            if (count == 0)
            {
                MessageBox.Show("Product Not Found!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtProdname.Text = "";
            txtStock.Text = "";
            txtPrice.Text = "";
            txtDesc.Text = "";
        }
    }
}
