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
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.destPictureBox = new System.Windows.Forms.PictureBox();
            this.confrimButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(91, 32);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(122, 112);
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // destPictureBox
            // 
            this.destPictureBox.Location = new System.Drawing.Point(354, 32);
            this.destPictureBox.Name = "destPictureBox";
            this.destPictureBox.Size = new System.Drawing.Size(122, 112);
            this.destPictureBox.TabIndex = 1;
            this.destPictureBox.TabStop = false;
            // 
            // confrimButton
            // 
            this.confrimButton.Location = new System.Drawing.Point(177, 188);
            this.confrimButton.Name = "confrimButton";
            this.confrimButton.Size = new System.Drawing.Size(75, 23);
            this.confrimButton.TabIndex = 2;
            this.confrimButton.Text = "OK";
            this.confrimButton.UseVisualStyleBackColor = true;
            this.confrimButton.Click += new System.EventHandler(this.confrimButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(308, 188);
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
            this.sourceLabel.Location = new System.Drawing.Point(133, 147);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(35, 13);
            this.sourceLabel.TabIndex = 4;
            this.sourceLabel.Text = "label1";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(397, 147);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(35, 13);
            this.destLabel.TabIndex = 5;
            this.destLabel.Text = "label2";
            // 
            // MoveFilesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(570, 229);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confrimButton);
            this.Controls.Add(this.destPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Name = "MoveFilesUI";
            this.Text = "MoveFilesUI";
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox destPictureBox;
        private System.Windows.Forms.Button confrimButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label destLabel;
    }
}