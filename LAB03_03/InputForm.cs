using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAB03_03.Model;

namespace LAB03_03
{
    public partial class InputForm : Form
    {
        public SendData sender;
        public InputForm(SendData sender)
        {
            InitializeComponent();
            this.sender = sender;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            List<string> Faculties = new List<string>() { "Công nghệ thông tin", "Ngôn ngữ Anh", "Quản trị kinh doanh" };
            foreach (var item in Faculties)
            {
                cboFaculty.Items.Add(item);
            }
            cboFaculty.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                StudentID = txtStudentID.Text,
                FullName = txtFullName.Text,
                Faculty = cboFaculty.Text,
                AverageScore = float.Parse(txtAverageScore.Text)
            };
            this.sender(student);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtStudentID, "Không được để trống mã sinh viên");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtStudentID, null);
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtFullName, "Không được để trống họ tên sinh viên");
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(txtFullName, null);
            }

            if (string.IsNullOrWhiteSpace(txtAverageScore.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtAverageScore, "Không được để trống điểm");
            }
            else if (float.Parse(txtAverageScore.Text) < 0 || float.Parse(txtAverageScore.Text) > 10)
            {
                e.Cancel = true;
                errorProvider.SetError(txtAverageScore, "Điểm có giá trị từ 0 - 10");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtAverageScore, null);
            }
        }
    }
}
