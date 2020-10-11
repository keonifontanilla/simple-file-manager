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
        private string rootPath;

        public OpenFolderUI(string rootPath)
        {
            this.rootPath = rootPath;

            InitializeComponent();
            LoadDirectoryAndFiles();
        }

        private void LoadDirectoryAndFiles()
        {
            var directories = Directory.GetDirectories(rootPath);
            var files = Directory.GetFiles(rootPath);
            LoadDirectory(directories);
            LoadFiles(files);
        }

        private void LoadDirectory(string[] directories)
        {
            foreach (var directory in directories)
            {
                var directoryName = Path.GetFileNameWithoutExtension(directory);
                folderListView.Items.Add(directoryName);
            }
        }

        private void LoadFiles(string[] files)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                folderListView.Items.Add(fileName);
            }
        }

    }
}
