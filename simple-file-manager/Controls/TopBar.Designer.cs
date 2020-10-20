namespace simple_file_manager
{
    partial class TopBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopBar));
            this.topBarLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // topBarLabel
            // 
            this.topBarLabel.AutoSize = true;
            this.topBarLabel.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.topBarLabel.ForeColor = System.Drawing.Color.White;
            this.topBarLabel.Location = new System.Drawing.Point(3, 0);
            this.topBarLabel.Name = "topBarLabel";
            this.topBarLabel.Size = new System.Drawing.Size(65, 24);
            this.topBarLabel.TabIndex = 0;
            this.topBarLabel.Text = "label1";
            this.topBarLabel.SizeChanged += new System.EventHandler(this.topBarLabel_SizeChanged);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(110, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(37, 29);
            this.closeButton.TabIndex = 19;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // TopBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.topBarLabel);
            this.Name = "TopBar";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopBar_MouseDown_1);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopBar_MouseMove_1);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopBar_MouseUp_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topBarLabel;
        private System.Windows.Forms.Button closeButton;
    }
}
