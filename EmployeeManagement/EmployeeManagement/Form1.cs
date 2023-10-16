namespace EmployeeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee EmployeeInfo = new Employee();

            EmployeeInfo.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeInfo EmployeeInfo = new EmployeeInfo();

            EmployeeInfo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(button1, "Register/Edit employees");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(button2, "View Employee Information");
        }
    }
}