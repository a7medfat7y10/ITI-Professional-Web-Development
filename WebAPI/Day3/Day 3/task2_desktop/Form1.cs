using System.Net;

namespace task2_desktop
{
    public partial class Form1 : Form
    {
        HttpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HttpResponseMessage res =
               client.GetAsync("https://localhost:7262/api/Instructors").Result;

            if (res.StatusCode == HttpStatusCode.OK)
            {
                List<Instructor> ins = res.Content.ReadAsAsync<List<Instructor>>().Result;
                grdInstructors.DataSource = ins;
            }
            else
            {
                MessageBox.Show("Couldn't Get All Instructors Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            HttpResponseMessage res2 = client.GetAsync("https://localhost:7262/api/Departments").Result;
            if (res2.IsSuccessStatusCode)
            {
                List<Department> depts = res2.Content.ReadAsAsync<List<Department>>().Result;
                cBoxDeptID.DisplayMember = "Name";
                cBoxDeptID.ValueMember = "Id";
                cBoxDeptID.DataSource = depts;
            }
            else
            {
                MessageBox.Show("Couldn't Get All Departments Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Instructor ins = new Instructor()
            {
                Name = txtName.Text,
                InstructorId = Convert.ToInt32(txtSSN.Text),
                Address = txtAddress.Text,
                Salary = Convert.ToInt32(txtSalary.Text),
                Age = Convert.ToInt32(txtAge.Text),
                DepartmentId = Convert.ToInt32(cBoxDeptID.SelectedValue)
            };

            HttpResponseMessage r = client.PostAsJsonAsync("https://localhost:7262/api/Instructors\r\n", ins).Result;

            if (r.IsSuccessStatusCode)
            {
                Form1_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Couldn't Save New Instructor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void grdInstructors_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
        }

        private void grdInstructors_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void grdInstructors_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this instructor", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)grdInstructors.SelectedRows[0].Cells[0].Value;
                HttpResponseMessage res = client.DeleteAsync("https://localhost:7262/api/Instructors" + "/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    Form1_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Couldn't Delete New Instructor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

    }
}