using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        MoveFilesUI moveFilesUI;
        TopBar topBar;

        private string rootPath = "";
        private string path = "";
        private bool isFile = false;
        private bool sortByDateClicked = false;

        public OpenFolderUI(MoveFilesUI moveFilesUI, string rootPath)
        {
            this.moveFilesUI = moveFilesUI;
            this.rootPath = rootPath;
            this.path = rootPath;

            InitializeComponent();
            LoadDirectoryAndFiles(rootPath);
        }

        public void LoadDirectoryAndFiles(string path)
        {
            DirectoryInfo[] directories;
            FileInfo[] files;

            // Get directories and file but exclude hidden directories and files
            if (sortByDateClicked)
            {
                directories = new DirectoryInfo(path).GetDirectories().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).OrderByDescending(x => x.LastWriteTime.Year <= 1601 ? x.CreationTime : x.LastWriteTime).ToArray();
                files = new DirectoryInfo(path).GetFiles().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).OrderByDescending(x => x.LastWriteTime.Year <= 1601 ? x.CreationTime : x.LastWriteTime).ToArray();
                sortByDateClicked = false;
            }
            else
            {
                directories = new DirectoryInfo(path).GetDirectories().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();
                files = new DirectoryInfo(path).GetFiles().Where(x => (x.Attributes & FileAttributes.Hidden) == 0).ToArray();
            }

            folderListView.Items.Clear();

            LoadDirectory(directories);
            LoadFiles(files);
            FormatTopBar();
        }

        private void FormatTopBar()
        {
            var index = topBarPanel.Controls.IndexOf(topBar);

            if (index != -1) topBarPanel.Controls.RemoveAt(index);

            topBar = new TopBar(topBarPanel, path);
            topBar.Dock = DockStyle.Top;

            topBarPanel.Controls.Add(topBar);
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
            // Case insensitive search
            var listItems = folderListView.Items.Cast<ListViewItem>().Where(x => x.Text.IndexOf(searchTextBox.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

            folderListView.Items.Clear();

            listItems.ForEach(x => folderListView.Items.Add(x));
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (folderListView.FocusedItem != null && folderListView.SelectedItems.Count != 0) this.path += "\\" + folderListView.FocusedItem.Text;

            // Check if focused item is a file or folder
            var fileAttributes = File.GetAttributes(this.path);
            isFile = ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory) ? false : true;

            if (isFile)
            {
                Process.Start(this.path);

                // Removes the file name at the end of the path
                this.path = this.path.Substring(0, this.path.LastIndexOf("\\"));
            }
            else
            {
                LoadDirectoryAndFiles(this.path);
            }
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

        private void newFolderButton_Click(object sender, EventArgs e)
        {
            var path = ""; 
            var folderName = Microsoft.VisualBasic.Interaction.InputBox("Input folder name.", "Create New Folder", "New folder", newFolderButton.Right, newFolderButton.Location.Y);

            if (folderName != "") path += this.path + "\\" + folderName;

            try
            {
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder exists.");
                    return;
                }

                var directoryInfo = Directory.CreateDirectory(path);
                MessageBox.Show("Folder created.");
                LoadDirectoryAndFiles(this.path);
            }
            catch (Exception)
            {
                MessageBox.Show("Canceled.");
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            MoveFiles.MoveClicked = true;
            moveFilesUI.Show();
        }

        private void folderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = this.path;

            if (folderListView.FocusedItem != null)
            {
                if (MoveFiles.IsSource)
                {
                    MoveFiles.SourcePath = path += "\\" + folderListView.FocusedItem.Text;
                    MoveFiles.Name = folderListView.FocusedItem.Text;
                }
                else if (!MoveFiles.IsSource && MoveFiles.MoveClicked)
                {
                    MoveFiles.DestinationPath = path += "\\" + folderListView.FocusedItem.Text;
                    MoveFiles.Name = folderListView.FocusedItem.Text;
                }
            }
        }

        public void RefreshListView(string path)
        {
            // Check for when the folder on the main ui is moved while open
            if (Directory.Exists(this.path))
            {
                LoadDirectoryAndFiles(this.path);
            }
            else
            {
                this.path = path;
                this.rootPath = path;
                LoadDirectoryAndFiles(path);
            }
        }

        private void OpenFolderUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            MoveFiles.OpenFolderUIRefs.Remove(this);
        }

        private void sortByNameButton_Click(object sender, EventArgs e)
        {
            LoadDirectoryAndFiles(this.path);
        }

        private void sortByDate_Click(object sender, EventArgs e)
        {
            sortByDateClicked = true;
            LoadDirectoryAndFiles(this.path);
        }
    }
}
