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

namespace EmployeeManagement
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L9IDL8V\SQLEXPRESS;Initial Catalog=employeeDB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cnn = new SqlCommand("Select * from Employees", connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(button1, "View every employees information");
        }
    }
}
