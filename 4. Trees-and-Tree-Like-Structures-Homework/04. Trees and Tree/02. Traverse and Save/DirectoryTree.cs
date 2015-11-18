namespace _02.Traverse_and_Save
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTree
    {
        private Folder rootFolder;
        private long currentFolderSize = 0;
        private Folder folderToFind = null;

        public DirectoryTree(string rootFolderName)
        {
            var rootDirInfo = new DirectoryInfo(rootFolderName);
            if (rootDirInfo == null)
            {
                throw new InvalidOperationException(string.Format("Directory with name {0} was not found.", rootFolderName));
            }
            this.rootFolder = new Folder();
            this.rootFolder.Name = rootDirInfo.Name;
            TraverseSubDirectories(this.rootFolder, rootDirInfo);
        }

        public long Size
        {
            get
            {
                this.currentFolderSize = 0;
                CalculateSize(this.rootFolder);
                return this.currentFolderSize;
            }
        }

        public long GetSubfolderSize(Folder subFolder)
        {
            var folder = FindFolder(subFolder);
            if (folder == null)
            {
                throw new InvalidOperationException(string.Format("No subfolder named {0} was found.", subFolder.Name));
            }
            this.currentFolderSize = 0;
            CalculateSize(folder);
            return this.currentFolderSize;
        }

        private void CalculateSize(Folder folder)
        {
            this.currentFolderSize += folder.Files.Sum(f => f.Size);
            foreach (var childFolder in folder.ChildFolders)
            {
                CalculateSize(childFolder);
            }
        }

        private void TraverseSubDirectories(Folder currentFolder, DirectoryInfo dir)
        {
            try
            {
                FileInfo[] childFiles = dir.GetFiles();
                foreach (var file in childFiles)
                {
                    File newFile = new File();
                    newFile.Name = file.Name;
                    newFile.Size = file.Length;
                    currentFolder.Files.Add(newFile);
                }

                DirectoryInfo[] childDirectories = dir.GetDirectories();
                foreach (var directory in childDirectories)
                {
                    Folder newFolder = new Folder();
                    newFolder.Name = directory.Name;
                    currentFolder.ChildFolders.Add(newFolder);
                    //DirectoryInfo newDirInfo = new DirectoryInfo(newFolder.Name);
                    TraverseSubDirectories(newFolder, directory);
                }
            }
            catch (Exception ex)
            {

                // Do nothing - no access to this directory.
            }
        }

        private Folder FindFolder(Folder folderToFind)
        {
            this.folderToFind = null;
            FindFolder(this.rootFolder, folderToFind);
            return this.folderToFind;
        }

        private void FindFolder(Folder currentFolder, Folder folderToFind)
        {
            if (currentFolder.Name == folderToFind.Name)
            {
                this.folderToFind = currentFolder;
            }
            foreach (var folder in currentFolder.ChildFolders)
            {
                FindFolder(folder, folderToFind);
            }
        }
    }
}
