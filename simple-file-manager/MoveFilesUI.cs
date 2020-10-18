using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_file_manager
{
    public partial class MoveFilesUI : Form
    {
        public MoveFilesUI()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (MoveFiles.SourcePath != null && MoveFiles.SourcePath != "" && destPictureBox.Image != null)
            {
                var fileAttributes = File.GetAttributes(MoveFiles.SourcePath);

                if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    // Old path for folders on main UI
                    var index = Array.FindIndex(MoveFiles.mainUIUpdatedpaths, x => x == MoveFiles.SourcePath);
                    if (index != -1) MoveFiles.mainUIUpdatedpaths[index] = MoveFiles.DestinationPath + "\\" + sourceLabel.Text;
                    MoveFolders(MoveFiles.SourcePath, MoveFiles.DestinationPath + "\\" + sourceLabel.Text);
                }
                else
                {
                    MoveFile();
                }
            }
        }

        private void MoveFolders(string sourcePath, string destinationPath)
        {
            try
            {
                if (Directory.Exists(sourcePath))
                {
                    if (!Directory.Exists(destinationPath))
                    {
                        // Moves and creates new folder if folder doesn't exist
                        Directory.Move(sourcePath, destinationPath);
                    }
                    else
                    {
                        // Move files from a folder into an existing folder
                        foreach (var file in new DirectoryInfo(sourcePath).GetFiles())
                        {
                            file.CopyTo($@"{destinationPath}\{file.Name}", true);
                        }

                        // Recursively traverse subdirectories
                        foreach (var subDirectory in new DirectoryInfo(sourcePath).GetDirectories())
                        {
                            MoveFolders(subDirectory.FullName, $@"{destinationPath}\{subDirectory.Name}");
                        }
                    }

                    RefreshListView();
                    Reset();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Move failed.");
            }
        }

        private void MoveFile()
        {
            try
            {
                File.Copy(MoveFiles.SourcePath, MoveFiles.DestinationPath + "\\" + sourceLabel.Text, true);

                RefreshListView();
                Reset();
            }
            catch (Exception)
            {
                MessageBox.Show("Move failed.");
            }
        }

        private void RefreshListView()
        {
            foreach (var refs in MoveFiles.OpenFolderUIRefs)
            {
                // Pass in destination path for when the folder on the main ui is moved while open
                refs.RefreshListView(MoveFiles.DestinationPath + "\\" + sourceLabel.Text);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            MoveFiles.Reset();
            sourcePictureBox.Image = null;
            sourceLabel.Text = "";
            destPictureBox.Image = null;
            destLabel.Text = "";
            this.Hide();
        }

        private void setButton1_Click(object sender, EventArgs e)
        {
            if (MoveFiles.IsSource)
            {
                SetButtonUI(MoveFiles.SourcePath, sourcePictureBox, sourceLabel, false);
            }
        }

        private void setButton2_Click(object sender, EventArgs e)
        {
            if (MoveFiles.DestinationPath != "" && MoveFiles.DestinationPath != null)
            {
                SetButtonUI(MoveFiles.DestinationPath, destPictureBox, destLabel, false);
                MoveFiles.MoveClicked = false;
            }
        }

        private void SetButtonUI(string path, PictureBox pictureBox, Label label, bool isSource)
        {
            if (path != null && path != "")
            {
                pictureBox.Image = Image.FromFile(@".\Icons\folderIcon.png");
                label.Text = MoveFiles.Name;
                label.Location = PostionLabel(pictureBox, label);
                MoveFiles.IsSource = isSource;
                MessageBox.Show(path);
            }
        }

        private Point PostionLabel(PictureBox pictureBox, Label label)
        {
            return new Point(pictureBox.Location.X + ((pictureBox.Size.Width - label.Size.Width) / 2), pictureBox.Bottom);
        }

        private void MoveFilesUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Reset();
                Hide();
            }
        }
    }
}
