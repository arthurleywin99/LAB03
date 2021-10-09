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
    public delegate void SendData(Student student);
    public partial class StudentManagement : Form
    {
        private DataTable data;
        private int Index;
        public StudentManagement()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Index = 1;
            data = new DataTable();
            InitDataTable(data);
        }

        private void InitDataTable(DataTable data)
        {
            data.Columns.Add("Số TT", typeof(int));
            data.Columns.Add("Mã Số SV", typeof(string));
            data.Columns.Add("Tên Sinh Viên", typeof(string));
            data.Columns.Add("Khoa", typeof(string));
            data.Columns.Add("Điểm TB", typeof(float));
            dgvStudent.DataSource = data;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm(SetData);
            inputForm.Show();
            inputForm.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetData(Student student)
        {
            if (isExist(student))
            {
                MessageBox.Show("Đã tồn tại sinh viên với mã này", "Existing Error", MessageBoxButtons.OK);
            }
            else
            {
                DataRow row = data.NewRow();
                row["Số TT"] = Index;
                row["Mã Số SV"] = student.StudentID;
                row["Tên Sinh Viên"] = student.FullName;
                row["Khoa"] = student.Faculty;
                row["Điểm TB"] = student.AverageScore;
                data.Rows.Add(row);
                Index++;
            }
        }

        private bool isExist(Student student)
        {
            foreach (DataRow item in data.Rows)
            {
                if (item["Mã Số SV"].Equals(student.StudentID))
                {
                    return true;
                }
            }
            return false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable TempData = new DataTable();
            InitDataTable(TempData);
            string text = txtSearch.Text;
            if (text == string.Empty)
            {
                dgvStudent.DataSource = data;
            }
            else
            {
                foreach (DataRow item in data.Rows)
                {
                    if (item["Tên Sinh Viên"].ToString().ToUpper().Contains(txtSearch.Text.ToUpper()))
                    {
                        TempData.ImportRow(item);
                    }
                }
                dgvStudent.DataSource = TempData;
            }
        }
    }
}
