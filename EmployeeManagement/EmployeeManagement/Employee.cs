using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.VisualBasic;
using BCrypt.Net;

namespace EmployeeManagement
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlCommand cnn = new SqlCommand("Select * from Employees", connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            dataGridView1.DataSource = table;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand cnn = new SqlCommand("Insert into Employees(id, employeename, age, email, salary, dateofbirth, benefits, PasswordHash) values(@id, @employeename, @age, @email, @salary, @dateofbirth, @benefits, @PasswordHash)", connection);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            string employeeName = textBox2.Text;
            if (!IsAlpha(employeeName))
            {
                MessageBox.Show("Employee name should contain only alphabets.");
                connection.Close();
                return;
            }

            cnn.Parameters.AddWithValue("@EmployeeName", employeeName);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

            cnn.Parameters.AddWithValue("@Email", textBox4.Text);

            cnn.Parameters.AddWithValue("@Salary", int.Parse(textBox5.Text));

            cnn.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(textBox6.Text));

            cnn.Parameters.AddWithValue("@Benefits", textBox7.Text);

            string password = textBox8.Text;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            cnn.Parameters.AddWithValue("@PasswordHash", passwordHash);

            cnn.ExecuteNonQuery();

            connection.Close();

            BindData();
        }

        private bool IsAlpha(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

            connection.Open();

            SqlCommand cnn = new SqlCommand("Delete Employees where id=@id", connection);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Data deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int employeeId;
            //if (int.TryParse(Interaction.InputBox("Enter Employee ID:", "Edit Employee", "0"), out employeeId))
            //{
            //    PopulateEmployeeData(employeeId);

            //    UpdateEmployeeData(employeeId);


            //}

            //void PopulateEmployeeData(int employeeId)
            //{
            //    SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

            //    connection.Open();

            //    SqlCommand cmd = new SqlCommand("SELECT EmployeeName, Age, Email, Salary, DateOfBirth, Benefits FROM Employees WHERE Id = @Id", connection);
            //    cmd.Parameters.AddWithValue("@Id", employeeId);

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.Read())
            //    {
            //        textBox2.Text = reader["EmployeeName"].ToString();
            //        textBox3.Text = reader["Age"].ToString();
            //        textBox4.Text = reader["Email"].ToString();
            //        textBox5.Text = reader["Salary"].ToString();
            //        textBox6.Text = reader["DateOfBirth"].ToString();
            //        textBox7.Text = reader["Benefits"].ToString();
            //    }

            //    reader.Close();
            //}


            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

            connection.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Employees SET EmployeeName = @EmployeeName, Age = @Age, Email = @Email, Salary = @Salary, DateOfBirth = @DateOfBirth, Benefits = @Benefits, PasswordHash = @PasswordHash WHERE Id = @Id", connection);

            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@EmployeeName", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Salary", int.Parse(textBox5.Text));
            DateTime dateOfBirth;
            if (DateTime.TryParse(textBox6.Text, out dateOfBirth))
            {
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            }
            else
            {
                MessageBox.Show("Invalid Date of Birth");
                return;
            }
            cmd.Parameters.AddWithValue("@Benefits", textBox7.Text);
            string newPassword = textBox8.Text;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

            cmd.ExecuteNonQuery();

            connection.Close();



            MessageBox.Show("Data edited");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string employeeName = textBox2.Text;

            if (!IsAlpha(employeeName))
            {
                textBox2.BackColor = Color.Red;
                warningLabel.Text = "Employee name should contain only alphabets.";
            }
            else
            {
                textBox2.BackColor = SystemColors.Window;
                warningLabel.Text = string.Empty;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string input = textBox3.Text;

            if (!IsNumeric(input))
            {
                textBox3.BackColor = Color.Red;
                warningLabel2.Text = "Age should contain only numbers.";
            }
            else
            {
                textBox3.BackColor = SystemColors.Window;
                warningLabel2.Text = "";
            }
        }
        private bool IsNumeric(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string email = textBox4.Text;

            if (!IsValidEmail(email))
            {
                textBox4.BackColor = Color.Red;
                warningLabel3.Text = "Invalid email format.";
            }
            else
            {
                textBox4.BackColor = SystemColors.Window;
                warningLabel3.Text = "";
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string input = textBox5.Text;

            if (!IsNumeric(input))
            {
                textBox5.BackColor = Color.Red;
                warningLabel4.Text = "Salary should contain only numbers.";
            }
            else
            {
                textBox5.BackColor = SystemColors.Window;
                warningLabel4.Text = "";
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            tooltip.SetToolTip(button1, "Add Employee");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            tooltip.SetToolTip(button2, "Clear Fields");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            tooltip.SetToolTip(button3, "Delete Employee");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            tooltip.SetToolTip(button4, "Edit Employee");
        }
    }
}