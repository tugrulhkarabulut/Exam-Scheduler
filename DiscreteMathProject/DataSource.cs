using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DiscreteMathProject
{
    public class DataSource
    {
        public Dictionary<string, string[]> Courses { get; }

        public DataSource() {
            Courses = new Dictionary<string, string[]>();
        }

        public string[] ReadCourses()
        {
            string basePath = @"..\..\..\Data\";
            string[] courses = File.ReadAllLines(basePath + "DersListesi.txt");

            foreach (string course in courses)
            {
                string courseFilePath = $@"{basePath}{course}.txt";
                string[] students = File.ReadAllLines(courseFilePath);
                Courses.Add(course, students);
            }

            return courses;
        }
    }
}
