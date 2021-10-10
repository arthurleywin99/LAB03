using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (txtStudentID.Text == "" || txtFullName.Text == "" || txtAverageScore.Text == "")
            {
                MessageBox.Show("Phải điền dữ liệu vào tất cả các trường", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Student student = new Student(txtStudentID.Text, txtFullName.Text, cboFaculty.Text, float.Parse(txtAverageScore.Text));
                this.sender(student);
                SetDefault();
            }
        }

        private void SetDefault()
        {
            txtStudentID.Text = "";
            txtFullName.Text = "";
            cboFaculty.SelectedIndex = 0;
            txtAverageScore.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStudentID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrEmpty(txtStudentID.Text))
            {
                e.Cancel = true;
                txtStudentID.Focus();
                errorProvider.SetError(txtStudentID, "Mã sinh viên không được để trống");
            }
            else if (txtStudentID.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                e.Cancel = true;
                txtStudentID.Focus();
                errorProvider.SetError(txtStudentID, "Mã sinh viên không chứa ký tự đặc biệt");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtStudentID, null);
            }
        }

        private void txtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrEmpty(txtFullName.Text))
            {
                e.Cancel = true;
                txtFullName.Focus();
                errorProvider.SetError(txtFullName, "Không được để trống");
            }
            else if (!Regex.IsMatch(UnicodeToAscii(txtFullName.Text), @"^[A-Za-z ]+$"))
            {
                e.Cancel = true;
                txtFullName.Focus();
                errorProvider.SetError(txtFullName, "Tên sinh viên không chứa số hoặc ký tự đặc biệt");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFullName, null);
            }
        }

        private void txtAverageScore_Validating(object sender, CancelEventArgs e)
        {
            float number;
            bool check;
            check = float.TryParse(txtAverageScore.Text, out number);
            if (string.IsNullOrWhiteSpace(txtAverageScore.Text) || string.IsNullOrEmpty(txtAverageScore.Text))
            {
                e.Cancel = true;
                txtAverageScore.Focus();
                errorProvider.SetError(txtAverageScore, "Không được để trống");
            }
            else if (!check)
            {
                e.Cancel = true;
                txtAverageScore.Focus();
                errorProvider.SetError(txtAverageScore, "Phải nhập dữ liệu là số thực");
            }
            else if (number < 0 || number > 10)
            {
                e.Cancel = true;
                txtAverageScore.Focus();
                errorProvider.SetError(txtAverageScore, "Điểm phải nằm trong khoảng từ 0 - 10");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtAverageScore, null);
            }
        }

        private readonly string[] VietNameseChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public string UnicodeToAscii(string str)
        {
            for (int i = 1; i < VietNameseChar.Length; i++)
            {
                for (int j = 0; j < VietNameseChar[i].Length; j++)
                    str = str.Replace(VietNameseChar[i][j], VietNameseChar[0][i - 1]);
            }
            return str;
        }
    }
}
