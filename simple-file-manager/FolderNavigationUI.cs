using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace simple_file_manager
{
    /// <summary>
    /// This class displays the main interface. Folders can be added to the ui for the user to access easily. Folders
    /// can also be removed from the ui. When the program is closed, the user selected folders will be saved.
    /// </summary>
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

            InitSettings();
        }

        /// <summary>
        /// Initializes saved folders on the main ui.
        /// </summary>
        private void InitSettings()
        {
            var savePaths = Properties.Settings.Default.MainUIPaths;

            if (savePaths != null)
            {
                savePaths.CopyTo(MoveFiles.MainUIPaths, 0);
            }
            
            for (int i = 0; i < MoveFiles.MainUIPaths.Count();  i++)
            {
                if (MoveFiles.MainUIPaths[i] != null)
                {
                    var folderButton = (Button)this.Controls[$"addFolderButton{i + 1}"];
                    var removeButton = (Button)this.Controls[$"removeButton{i + 1}"];
                    var folderLabel = (Label)this.Controls[$"folderLabel{i + 1}"];

                    AddFolderIcon(folderButton, removeButton);
                    FormatFolderLabel(folderLabel, folderButton, MoveFiles.MainUIPaths[i]);
                }
            }
            
        }

        /// <summary>
        /// Saves the main ui folders.
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.MainUIPaths = new System.Collections.Specialized.StringCollection();

            foreach (var path in MoveFiles.MainUIPaths)
            {
                Properties.Settings.Default.MainUIPaths.Add(path);
            }

            Properties.Settings.Default.Save();
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

        /// <summary>
        /// Creates openFolderUI instance when a folder is clicked. 
        /// Sets paths if moving folders or files.
        /// </summary>
        /// <param name="path">
        /// The path of the folder.
        /// </param>
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

        private void FormatFolderLabel(Label lblName, Button folderButton, string path)
        {
            lblName.Text = path.Substring(path.LastIndexOf("\\") + 1);

            // formating label location in the middle of folder icon
            lblName.Location = new Point(folderButton.Location.X + ((folderButton.Size.Width - lblName.Size.Width) / 2), folderButton.Bottom);
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
                        FormatFolderLabel(lblName, folderButton, folderBrowserDialog.SelectedPath);
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
            SaveSettings();
            Application.Exit();
        }

        /// <summary>
        /// Changes folder label when a folder is renamed.
        /// </summary>
        /// <param name="labelName">
        /// The name of the folder.
        /// </param>
        /// <param name="name">
        /// The new name of the label.
        /// </param>
        public void ChangeFolderLabels(string labelName, string name)
        {
            this.Controls[labelName].Text = name;
        }

        /// <summary>
        /// Removes duplicate main ui folders when a folder is copied into a folder of the same name.
        /// </summary>
        /// <param name="path">
        /// The folder path used to check for duplicates.
        /// </param>
        public void RemoveDuplicateUIFolder(string path)
        {
            var duplicatePaths = MoveFiles.MainUIPaths
                .Select((t, i) => new { Index = i, Text = t })
                .Where(x => x.Text == path)
                .Select(x => x.Index).ToArray();

            for (int i = 1; i < duplicatePaths.Count(); i++)
            {
                var addButton = (Button)this.Controls[$"addFolderButton{duplicatePaths[i]+1}"];
                var folderLabel = (Label)this.Controls[$"folderLabel{duplicatePaths[i]+1}"];
                var removeButton = (Button)this.Controls[$"removeButton{duplicatePaths[i]+1}"];

                addButton.Image = Image.FromFile(@".\Icons\addIcon.png");
                folderLabel.Text = "";
                removeButton.Visible = false;
                MoveFiles.MainUIPaths[duplicatePaths[i]] = null;
            }
        }
    }
}
