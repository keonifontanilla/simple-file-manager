using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace simple_file_manager
{
    public partial class FolderNavigationUI : Form
    {
        TopBar topBar;
        OpenFolderUI openFolderUI;
        MoveFilesUI moveFilesUI;

        private string rootDrive = "";
        private string desktopPath = "";
        private string downloadsPath = "";

        public FolderNavigationUI()
        {
            moveFilesUI = new MoveFilesUI();
            rootDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            downloadsPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\Downloads");

            InitializeComponent();

            topBar = new TopBar(topBarPanel, "File Manager", 0);
            topBar.Dock = DockStyle.Top;
            topBarPanel.Controls.Add(topBar);
            MoveFiles.MainUIRef = this;
        }

        private void mainFolderButton_Click(object sender, EventArgs e)
        {   
            SetUp(rootDrive);
            openFolderUI.Show();
        }

        private void desktopfolderButton_Click(object sender, EventArgs e)
        {
            SetUp(desktopPath);
            openFolderUI.Show();
        }

        private void downloadsFolderButton_Click(object sender, EventArgs e)
        {
            SetUp(downloadsPath);
            openFolderUI.Show();
        }

        private void SetUp(string path)
        {
            openFolderUI = new OpenFolderUI(moveFilesUI, path);
            MoveFiles.OpenFolderUIRefs.Add(openFolderUI);

            if (MoveFiles.IsSource && MoveFiles.MoveClicked)
            {
                MoveFiles.SourcePath = path;
                MoveFiles.Name = path.Substring(path.LastIndexOf("\\") + 1);
            }
            else if (!MoveFiles.IsSource && MoveFiles.MoveClicked)
            {
                MoveFiles.DestinationPath = path;
                MoveFiles.Name = path.Substring(path.LastIndexOf("\\") + 1);
            }
        }

        private void AddFolderIcon(Button folderButton, Button removeButton)
        {
            var folderIcon = @".\Icons\folderIcon.png";
            
            folderButton.Image = Image.FromFile(folderIcon);
            removeButton.Visible = true;

            foreach (var button in this.Controls.OfType<Button>().Where(x => x.Name == removeButton.Name))
            {
                button.Click += new EventHandler(this.removeButton_Click);
            }
        }

        private void AddNewFolder(Label lblName, Button folderButton, Button removeButton, int index)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    var duplicatePath = MoveFiles.MainUIPaths.Where(x => x != null).Any(x => x.Equals(folderBrowserDialog.SelectedPath));

                    if (!duplicatePath && !folderBrowserDialog.SelectedPath.Equals(rootDrive) && !folderBrowserDialog.SelectedPath.Equals(desktopPath) && !folderBrowserDialog.SelectedPath.Equals(downloadsPath))
                    {
                        MoveFiles.MainUIPaths[index] = folderBrowserDialog.SelectedPath;
                        AddFolderIcon(folderButton, removeButton);
                        lblName.Text = folderBrowserDialog.SelectedPath.Substring(folderBrowserDialog.SelectedPath.LastIndexOf("\\") + 1) ;

                        // formating label location in the middle of folder icon
                        lblName.Location = new Point(folderButton.Location.X + ((folderButton.Size.Width - lblName.Size.Width) / 2), folderButton.Bottom);
                    }
                    else
                    {
                        MessageBox.Show("Folder already on menu.");
                    }
                }
            }
        }

        private void CreateUIFolder(Label lblName, Button folderButton, Button removeButton, int index)
        {
            if (MoveFiles.MainUIPaths[index] != null)
            {
                SetUp(MoveFiles.MainUIPaths[index]);
                openFolderUI.Show();
            }
            else
            {
                AddNewFolder(lblName, folderButton, removeButton, index);
            }
        }

        private void addFolderButton1_Click(object sender, EventArgs e)
        {
            CreateUIFolder(folderLabel1, addFolderButton1, removeButton1, 0);
        }

        private void addFolderButton2_Click(object sender, EventArgs e)
        {
            CreateUIFolder(folderLabel2, addFolderButton2, removeButton2, 1);
        }

        private void addFolderButton3_Click(object sender, EventArgs e)
        {
            CreateUIFolder(folderLabel3, addFolderButton3, removeButton3, 2);
        }

        private void addFolderButton4_Click(object sender, EventArgs e)
        {
            CreateUIFolder(folderLabel4, addFolderButton4, removeButton4, 3);
        }

        private void addFolderButton5_Click(object sender, EventArgs e)
        {
            CreateUIFolder(folderLabel5, addFolderButton5, removeButton5, 4);
        }

        private void addFolderButton6_Click(object sender, EventArgs e)
        {
            CreateUIFolder(folderLabel6, addFolderButton6, removeButton6, 5);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // Get remove button number from name
            var removeButton = (Button) sender;
            var index = int.Parse(Regex.Match(removeButton.Name, @"\d+").ToString());

            var addButton = (Button) this.Controls[$"addFolderButton{index}"];
            var folderLabel = (Label) this.Controls[$"folderLabel{index}"];

            addButton.Image = Image.FromFile(@".\Icons\addIcon.png");
            folderLabel.Text = "";
            removeButton.Visible = false;
            MoveFiles.MainUIPaths[index - 1] = null;
        }

        private void FolderNavigationUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void ChangeFolderLabels(string labelName, string name)
        {
            this.Controls[labelName].Text = name;
        }
    }
}
