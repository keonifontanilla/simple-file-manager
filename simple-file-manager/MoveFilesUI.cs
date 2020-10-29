using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace simple_file_manager
{
    /// <summary>
    /// This class is the user interface for moving folders and files.
    /// </summary>
    public partial class MoveFilesUI : Form
    {
        TopBar topBar;

        public MoveFilesUI()
        {
            InitializeComponent();

            topBar = new TopBar(topBarPanel, "Move", 0);
            topBar.Dock = DockStyle.Top;
            topBarPanel.Controls.Add(topBar);
        }

        /// <summary>
        /// Checks source and destination path and moves folders or files. Also updates the path if the folder is on the main ui and removes
        /// any folder duplication that may happen with the move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(MoveFiles.SourcePath) && (destPictureBox.Image != null) && (MoveFiles.SourcePath != MoveFiles.DestinationPath + "\\" + sourceLabel.Text) && (MoveFiles.SourcePath != MoveFiles.DestinationPath))
            {
                var fileAttributes = File.GetAttributes(MoveFiles.SourcePath);

                if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    // Old path for folders on main UI
                    var index = Array.FindIndex(MoveFiles.MainUIPaths, x => x == MoveFiles.SourcePath);
                    if (index != -1) MoveFiles.MainUIPaths[index] = MoveFiles.DestinationPath + "\\" + sourceLabel.Text;
                    MoveFolders(MoveFiles.SourcePath, MoveFiles.DestinationPath + "\\" + sourceLabel.Text);

                    // Remove duplicate folders from main ui if a folder is copied into a folder with the same name
                    MoveFiles.MainUIRef.RemoveDuplicateUIFolder(MoveFiles.DestinationPath + "\\" + sourceLabel.Text);
                    
                    SendToRecycleBin();
                    RefreshListView();
                    Reset();
                }
                else
                {
                    MoveFile();
                }
            }
        }

        /// <summary>
        /// Moves a folder to another folder. If the destination folder doesn't exist then it creates the folder. If the 
        /// destination folder does exist then it moves the files to the destination folder and recursively moves the sub
        /// folders to the destination folder.
        /// </summary>
        /// <param name="sourcePath">
        /// The source path.
        /// </param>
        /// <param name="destinationPath">
        /// The destination path.
        /// </param>
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
                
                SendToRecycleBin();
                RefreshListView();
                Reset();
            }
            catch (Exception)
            {
                MessageBox.Show("Move failed.");
            }
        }

        /// <summary>
        /// Sends original folder or file to the recycle bin after it is moved.
        /// </summary>
        private void SendToRecycleBin()
        {
            if (Directory.Exists(MoveFiles.SourcePath))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(
                    MoveFiles.SourcePath, 
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, 
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }
            else if (File.Exists(MoveFiles.SourcePath))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                    MoveFiles.SourcePath,
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }
        }

        /// <summary>
        /// Refreshes listView of the open directory after the folder or file has been moved.
        /// </summary>
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

        /// <summary>
        /// Sets the source path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setButton1_Click(object sender, EventArgs e)
        {
            if (MoveFiles.IsSource)
            {
                SetButtonUI(MoveFiles.SourcePath, sourcePictureBox, sourceLabel, false);
            }
        }

        /// <summary>
        /// Sets the destination path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setButton2_Click(object sender, EventArgs e)
        {
            if (MoveFiles.DestinationPath != "" && MoveFiles.DestinationPath != null)
            {
                SetButtonUI(MoveFiles.DestinationPath, destPictureBox, destLabel, false);
                MoveFiles.MoveClicked = false;
            }
        }

        /// <summary>
        /// Sets the icon of the folder or file that is being moved.
        /// </summary>
        /// <param name="path">
        /// The source or destination path.
        /// </param>
        /// <param name="pictureBox">
        /// The pictureBox to set the folder icon to.
        /// </param>
        /// <param name="label">
        /// The name of the folder or file being moved.
        /// </param>
        /// <param name="isSource">
        /// Checks to see if source or destination is set.
        /// </param>
        private void SetButtonUI(string path, PictureBox pictureBox, Label label, bool isSource)
        {
            if (!string.IsNullOrEmpty(path))
            {
                var isFolder = (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
                var image = isFolder ? DefaultIcons.FolderLarge.ToBitmap() : Icon.ExtractAssociatedIcon(path).ToBitmap();

                pictureBox.Image = new Bitmap(image, new Size(96, 96));
                label.Text = MoveFiles.Name;
                label.Location = PostionLabel(pictureBox, label);
                MoveFiles.IsSource = isSource;
                MessageBox.Show(path);
            }
        }

        /// <summary>
        /// Positions folder label in the center of the folder icon.
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="label"></param>
        /// <returns>
        /// Returns a point of the location of the label.
        /// </returns>
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
