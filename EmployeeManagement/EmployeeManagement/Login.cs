using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using BCrypt.Net;

namespace EmployeeManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT PasswordHash FROM Employees WHERE Email = @Email", connection);
            cmd.Parameters.AddWithValue("@Email", email);

            string storedPasswordHash = (string)cmd.ExecuteScalar();

            if (!string.IsNullOrEmpty(storedPasswordHash) && BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
            {
                MessageBox.Show("Login successful!");

                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials.");
            }

        }
    }
}
