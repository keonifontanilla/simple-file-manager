namespace simple_file_manager
{
    partial class MoveFilesUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveFilesUI));
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.destPictureBox = new System.Windows.Forms.PictureBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.setButton1 = new System.Windows.Forms.Button();
            this.setButton2 = new System.Windows.Forms.Button();
            this.rightArrowPictureBox = new System.Windows.Forms.PictureBox();
            this.topBarPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrowPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(108, 58);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(97, 91);
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // destPictureBox
            // 
            this.destPictureBox.Location = new System.Drawing.Point(362, 58);
            this.destPictureBox.Name = "destPictureBox";
            this.destPictureBox.Size = new System.Drawing.Size(97, 89);
            this.destPictureBox.TabIndex = 1;
            this.destPictureBox.TabStop = false;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(182, 231);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(313, 231);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.ForeColor = System.Drawing.Color.White;
            this.sourceLabel.Location = new System.Drawing.Point(156, 152);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(0, 13);
            this.sourceLabel.TabIndex = 4;
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.ForeColor = System.Drawing.Color.White;
            this.destLabel.Location = new System.Drawing.Point(410, 152);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(0, 13);
            this.destLabel.TabIndex = 5;
            // 
            // setButton1
            // 
            this.setButton1.Location = new System.Drawing.Point(134, 168);
            this.setButton1.Name = "setButton1";
            this.setButton1.Size = new System.Drawing.Size(44, 21);
            this.setButton1.TabIndex = 6;
            this.setButton1.Text = "Set";
            this.setButton1.UseVisualStyleBackColor = true;
            this.setButton1.Click += new System.EventHandler(this.setButton1_Click);
            // 
            // setButton2
            // 
            this.setButton2.Location = new System.Drawing.Point(389, 168);
            this.setButton2.Name = "setButton2";
            this.setButton2.Size = new System.Drawing.Size(43, 21);
            this.setButton2.TabIndex = 7;
            this.setButton2.Text = "Set";
            this.setButton2.UseVisualStyleBackColor = true;
            this.setButton2.Click += new System.EventHandler(this.setButton2_Click);
            // 
            // rightArrowPictureBox
            // 
            this.rightArrowPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("rightArrowPictureBox.Image")));
            this.rightArrowPictureBox.Location = new System.Drawing.Point(233, 78);
            this.rightArrowPictureBox.Name = "rightArrowPictureBox";
            this.rightArrowPictureBox.Size = new System.Drawing.Size(100, 50);
            this.rightArrowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.rightArrowPictureBox.TabIndex = 8;
            this.rightArrowPictureBox.TabStop = false;
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(597, 52);
            this.topBarPanel.TabIndex = 30;
            // 
            // MoveFilesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(597, 269);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.rightArrowPictureBox);
            this.Controls.Add(this.setButton2);
            this.Controls.Add(this.setButton1);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.destPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MoveFilesUI";
            this.Text = "MoveFilesUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveFilesUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightArrowPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox destPictureBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.Button setButton1;
        private System.Windows.Forms.Button setButton2;
        private System.Windows.Forms.PictureBox rightArrowPictureBox;
        private System.Windows.Forms.Panel topBarPanel;
    }
}