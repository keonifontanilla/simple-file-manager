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
    public partial class MoveFilesUI : Form
    {
        public MoveFilesUI()
        {
            InitializeComponent();
        }

        public void SetPictureBox(string image)
        {
            sourcePictureBox.Image = MoveFiles.IsSource ? sourcePictureBox.Image = Image.FromFile(image) : destPictureBox.Image = Image.FromFile(image); ; 
        }

        private void confrimButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MoveFiles.SourcePath);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MoveFiles.DestinationPath);
        }
    }
}
