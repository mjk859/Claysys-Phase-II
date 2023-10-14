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

            SqlCommand cnn = new SqlCommand("Insert into Employees(id, employeename, age, email, salary, dateofbirth, benefits) values(@id, @employeename, @age, @email, @salary, @dateofbirth, @benefits)", connection);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@EmployeeName", textBox2.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

            cnn.Parameters.AddWithValue("@Email", textBox4.Text);

            cnn.Parameters.AddWithValue("@Salary", int.Parse(textBox5.Text));

            cnn.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(textBox6.Text));

            cnn.Parameters.AddWithValue("@Benefits", textBox7.Text);

            cnn.ExecuteNonQuery();

            connection.Close();

            BindData();
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
            int employeeId;
            if (int.TryParse(Interaction.InputBox("Enter Employee ID:", "Edit Employee", "0"), out employeeId))
            {
                PopulateEmployeeData(employeeId);
                
                UpdateEmployeeData(employeeId);

                
            }

            void PopulateEmployeeData(int employeeId)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT EmployeeName, Age, Email, Salary, DateOfBirth, Benefits FROM Employees WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", employeeId);

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                        textBox2.Text = reader["EmployeeName"].ToString();
                        textBox3.Text = reader["Age"].ToString();
                        textBox4.Text = reader["Email"].ToString();
                        textBox5.Text = reader["Salary"].ToString();
                        textBox6.Text = reader["DateOfBirth"].ToString();
                        textBox7.Text = reader["Benefits"].ToString();
                }

                reader.Close();
            }
            

            void UpdateEmployeeData(int employeeId)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

                connection.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Employees SET EmployeeName = @EmployeeName, Age = @Age, Email = @Email, Salary = @Salary, DateOfBirth = @DateOfBirth, Benefits = @Benefits WHERE Id = @Id", connection);

                cmd.Parameters.AddWithValue("@Id", employeeId);
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

                cmd.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Data edited");
            }
        }
    }
}