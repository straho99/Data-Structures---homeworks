namespace _02.Traverse_and_Save
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TraverseDirectories
    {
        public static void Main()
        {
            DirectoryTree windows = new DirectoryTree(@"c:\windows");
            Console.WriteLine("Total size of Windows folder is: {0} bytes.", windows.Size);

            Folder fonts = new Folder();
            fonts.Name = "Fonts";

            Console.WriteLine("Size of Fonts subfoler is: {0} bytes.", windows.GetSubfolderSize(fonts));
        }
    }
}