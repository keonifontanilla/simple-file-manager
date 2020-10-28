using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace simple_file_manager
{
    /// <summary>
    /// This class is a user control for the top bar of all open forms. It displays the name of the current folder
    /// and it exits the form or application.
    /// </summary>
    public partial class TopBar : UserControl
    {
        readonly Panel topBarPanel;
        private Point lastLocation;
        private bool mouseDown = false;
        private int offset;

        public TopBar(Panel topBarPanel, string name, int offset)
        {
            this.topBarPanel = topBarPanel;
            this.offset = offset;

            InitializeComponent();

            topBarLabel.Location = new Point((topBarPanel.Width - topBarLabel.Width - offset) / 2, (topBarPanel.Height - topBarLabel.Height) / 2);
            topBarLabel.Text = LimitLabelLength(name.Substring(name.LastIndexOf("\\") + 1));
        }

        /// <summary>
        /// For dragging and moving the form. Stores the location of the mouse pointer on the topBar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        /// <summary>
        /// For dragging and moving the form. Sends the location of the form up to the parent and sets the new location
        /// when the mouse pointer is being moved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBar_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Parent.Parent.Location = new Point((Parent.Parent.Location.X - lastLocation.X) + e.X, (Parent.Parent.Location.Y - lastLocation.Y) + e.Y);

                Parent.Update();
            }
        }

        /// <summary>
        /// For dragging and moving the form. When the mouse is no longer clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopBar_MouseUp_1(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        /// <summary>
        /// Positioning of the folder label name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topBarLabel_SizeChanged(object sender, EventArgs e)
        {
            topBarLabel.Location = new Point((topBarPanel.Width - topBarLabel.Width - offset) / 2, (topBarPanel.Height - topBarLabel.Height) / 2);
        }

        /// <summary>
        /// Limits the length of the folder's name if the name is larger that 30 chars. 
        /// </summary>
        /// <param name="labelText"></param>
        /// <returns></returns>
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
