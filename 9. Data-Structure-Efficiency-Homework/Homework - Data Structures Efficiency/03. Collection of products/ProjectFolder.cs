namespace _03.Collection_of_products
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
