using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_file_manager
{
    public partial class OpenFolderUI : Form
    {
        private string rootPath = "";
        private string path = "";

        public OpenFolderUI(string rootPath)
        {
            this.rootPath = rootPath;
            this.path = rootPath;

            InitializeComponent();
            LoadDirectoryAndFiles(rootPath);
        }

        private void LoadDirectoryAndFiles(string path)
        {
            // Get directories and file but exluded hidden directories and files
            var directories = new DirectoryInfo(path).GetDirectories().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();
            var files = new DirectoryInfo(path).GetFiles().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();

            folderListView.Items.Clear();

            LoadDirectory(directories);
            LoadFiles(files);
        }

        private void LoadDirectory(DirectoryInfo[] directories)
        {
            foreach (var directory in directories)
            {
                folderListView.Items.Add(directory.Name);
            }
        }

        private void LoadFiles(FileInfo[] files)
        {
            foreach (var file in files)
            {
                iconsList.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
                folderListView.Items.Add(file.Name, iconsList.Images.Count - 1);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (folderListView.FocusedItem != null) this.path += "\\" + folderListView.FocusedItem.Text;

            LoadDirectoryAndFiles(this.path);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var previousPath = this.path.Substring(0, this.path.LastIndexOf("\\"));
            if (previousPath.Count() >= rootPath.Count()) this.path = previousPath;

            LoadDirectoryAndFiles(this.path);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            this.path = this.rootPath;
            LoadDirectoryAndFiles(this.rootPath);
        }
    }
}
