namespace _01.Students
{
    using System.IO;

    public static class ProjectFolder
    {
        public static string GetCurrentProjectFolder()
        {
            var dir = new DirectoryInfo(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString());
            string folderName = dir.Parent.Parent.Parent.FullName + @"\";
            return folderName;
        }
    }
}
