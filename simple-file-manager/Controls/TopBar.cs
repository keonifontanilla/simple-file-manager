using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_file_manager
{
    public partial class TopBar : UserControl
    {
        readonly Panel topBarPanel;
        private Point lastLocation;
        private bool mouseDown = false;

        public TopBar(Panel topBarPanel, string name)
        {
            this.topBarPanel = topBarPanel;

            InitializeComponent();

            topBarLabel.Location = new Point((topBarPanel.Width - topBarLabel.Width - 136) / 2, (topBarPanel.Height - topBarLabel.Height) / 2);
            topBarLabel.Text = LimitLabelLength(name.Substring(name.LastIndexOf("\\") + 1));
        }

        private void TopBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void TopBar_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Parent.Parent.Location = new Point((Parent.Parent.Location.X - lastLocation.X) + e.X, (Parent.Parent.Location.Y - lastLocation.Y) + e.Y);

                Parent.Update();
            }
        }

        private void TopBar_MouseUp_1(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void topBarLabel_SizeChanged(object sender, EventArgs e)
        {
            topBarLabel.Location = new Point((topBarPanel.Width - topBarLabel.Width - 136) / 2, (topBarPanel.Height - topBarLabel.Height) / 2);
        }

        private string LimitLabelLength(string labelText)
        {
            return labelText.Length > 30 ? labelText.Substring(0, 30) + "..." : labelText;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            var parentForm = topBarPanel.Parent as Form;
            
            parentForm.Close();
        }
    }
}
