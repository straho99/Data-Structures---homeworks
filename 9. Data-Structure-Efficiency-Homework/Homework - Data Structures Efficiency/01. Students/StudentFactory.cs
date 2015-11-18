namespace _01.Students
{
    using System;
    using System.IO;

    public static class StudentFactory
    {
        private static Random rnd = new Random();

        public static void CreateStudents(int count)
        {
            string[] firstNames = new string[] { "John", "Mary", "Peter", "Michael", "David", "Elena", "Sam", "Ryan", "Jessica", "Kate", "Taylor" };
            string[] lastNames = new string[] { "Swift", "Giggs", "Johnson", "Peters", "De Gea", "Oliver", "Stewart", "Beckham", "Neville", "Keane", "Stamp" };
            string[] courses = new string[] { "C#", "Java", "Java Script Basics", "OOP", "PHP Basics", "Advanced JS", "Databases", "Database Apps", "Web Services", "Data Structures", "SPA Applications" };
            string fileName = ProjectFolder.GetCurrentProjectFolder() + "students.txt";

            using (FileStream fs = File.Open(fileName, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < count; i++)
                {
                    string firstName = firstNames[rnd.Next(0, firstNames.Length)];
                    string lastName = lastNames[rnd.Next(0, lastNames.Length)];
                    string course = courses[rnd.Next(0, lastNames.Length)];
                    sw.WriteLine(firstName + "|" + lastName + "|" + course);
                }
            }
        }
    }
}
