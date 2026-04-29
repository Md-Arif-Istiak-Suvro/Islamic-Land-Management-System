using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Islamic_Land_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=LoginDB;Integrated Security=True;TrustServerCertificate=True"))
            {
                string query = "SELECT COUNT(*) FROM LOGIN WHERE name=@user AND password=@pass";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    try
                    {
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            this.Hide();

                            Form2 dashboard = new Form2();
                            dashboard.ShowDialog();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
