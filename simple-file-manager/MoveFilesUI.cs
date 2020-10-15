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
            try
            {
                if (Directory.Exists(MoveFiles.SourcePath))
                { 
                    if (!Directory.Exists(MoveFiles.DestinationPath + "\\" + sourceLabel.Text))
                    {
                        Directory.Move(MoveFiles.SourcePath, MoveFiles.DestinationPath + "\\" + sourceLabel.Text);

                        foreach (var refs in MoveFiles.openFolderUIRefs)
                        {
                            // refs.LoadDirectoryAndFiles(MoveFiles.SourcePath.Substring(0, MoveFiles.DestinationPath.LastIndexOf("\\")));
                            refs.LoadDirectoryAndFiles(MoveFiles.DestinationPath);
                        }

                        Reset();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Move failed.");
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
            SetButtonUI(MoveFiles.DestinationPath, destPictureBox, destLabel, false);
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
    }
}
