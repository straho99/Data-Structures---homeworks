namespace _02.Traverse_and_Save
{
    using System.Collections.Generic;

    public class Folder
    {
        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public Folder()
        {
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }
    }
}
