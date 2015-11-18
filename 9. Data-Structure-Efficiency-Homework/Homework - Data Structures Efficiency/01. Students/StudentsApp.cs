namespace _01.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StudentsApp
    {
        public static void Main()
        {
            StudentFactory.CreateStudents(200); //Test with various number of students
            var studentsDatabase = ReadProducts(ProjectFolder.GetCurrentProjectFolder() + "students.txt");

            foreach (var course in studentsDatabase.Keys)
            {
                Console.WriteLine("{0}: {1}", course, string.Join(", ", studentsDatabase[course].ToList()));
                Console.WriteLine();
            }
        }

        public static SortedDictionary<string, SortedSet<Student>> ReadProducts(string fileName)
        {
            SortedDictionary<string, SortedSet<Student>> studentsByCourses = new SortedDictionary<string, SortedSet<Student>>();

            using (var reader = new StreamReader(fileName))
            {
                var line = reader.ReadLine();
                while (line != null && line.Length > 2)
                {
                    string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Student student = new Student(tokens[0].Trim(), tokens[1].Trim());
                    string course = tokens[2].Trim();

                    if (studentsByCourses.ContainsKey(course))
                    {
                        studentsByCourses[course].Add(student);
                    }
                    else
                    {
                        studentsByCourses[course] = new SortedSet<Student>();
                    }
                    
                    line = reader.ReadLine();
                }
            }

            return studentsByCourses;
        }
    }
}