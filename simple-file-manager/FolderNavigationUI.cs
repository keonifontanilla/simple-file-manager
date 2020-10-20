﻿using System;
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
        private String[] paths = new String[6];

        public FolderNavigationUI()
        {
            moveFilesUI = new MoveFilesUI();

            InitializeComponent();

            topBar = new TopBar(topBarPanel, "File Manager", 0);
            topBar.Dock = DockStyle.Top;
            topBarPanel.Controls.Add(topBar);
        }

        private void mainFolderButton_Click(object sender, EventArgs e)
        {
            // Get path for correct hard drive e.g. C
            var rootDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            
            SetUp(rootDrive);
            openFolderUI.Show();
        }

        private void desktopfolderButton_Click(object sender, EventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            SetUp(desktopPath);
            openFolderUI.Show();
        }

        private void downloadsFolderButton_Click(object sender, EventArgs e)
        {
            var downloadsPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\downloads");

            SetUp(downloadsPath);
            openFolderUI.Show();
        }

        // Fix when UI folder is opened and path is changed from move
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
                    var duplicatePath = paths.Where(x => x != null).Any(x => x.Equals(folderBrowserDialog.SelectedPath));

                    if (!duplicatePath)
                    {
                        paths[index] = folderBrowserDialog.SelectedPath;
                        MoveFiles.mainUIUpdatedpaths[index] = folderBrowserDialog.SelectedPath;
                        AddFolderIcon(folderButton, removeButton);
                        lblName.Text = paths[index].Substring(paths[index].LastIndexOf("\\") + 1);

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
            if (paths[index] != null)
            {
                if (paths[index] != MoveFiles.mainUIUpdatedpaths[index])
                {
                    SetUp(MoveFiles.mainUIUpdatedpaths[index]);
                }
                else
                {
                    SetUp(paths[index]);
                }
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
            paths[index - 1] = null;
            MoveFiles.mainUIUpdatedpaths[index - 1] = null;
        }

        private void FolderNavigationUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
