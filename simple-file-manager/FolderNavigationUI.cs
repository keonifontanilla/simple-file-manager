using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_file_manager
{
    public partial class FolderNavigationUI : Form
    {
        public FolderNavigationUI()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainFolderButton_Click(object sender, EventArgs e)
        {

        }

        private void desktopfolderButton_Click(object sender, EventArgs e)
        {

        }

        private void downloadsFolderButton_Click(object sender, EventArgs e)
        {

        }

        private void AddNewFolder(string name)
        {
            foreach (var item in this.Controls.OfType<Button>().Where(x => x.Name == name))
            {
                item.Image = Image.FromFile(@".\Icons\folderIcon.png");
            }
        }

        private void addFolderButton1_Click(object sender, EventArgs e)
        {
            AddNewFolder("addFolderButton1");
        }

        private void addFolderButton2_Click(object sender, EventArgs e)
        {
            AddNewFolder("addFolderButton2");
        }

        private void addFolderButton3_Click(object sender, EventArgs e)
        {
            AddNewFolder("addFolderButton3");
        }

        private void addFolderButton4_Click(object sender, EventArgs e)
        {
            AddNewFolder("addFolderButton4");
        }

        private void addFolderButton5_Click(object sender, EventArgs e)
        {
            AddNewFolder("addFolderButton5");
        }

        private void addFolderButton6_Click(object sender, EventArgs e)
        {
            AddNewFolder("addFolderButton6");
        }
    }
}
