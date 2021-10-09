using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03_03.Model
{
    public class Student
    {
        public string StudentID { get; set; }

        public string FullName { get; set; }

        public string Faculty { get; set; }

        public float AverageScore { get; set; }

        public Student()
        {

        }

        public Student(string StudentID, string FullName, string Faculty, float AverageScore)
        {
            this.StudentID = StudentID;
            this.FullName = FullName;
            this.Faculty = Faculty;
            this.AverageScore = AverageScore;
        }
    }
}
