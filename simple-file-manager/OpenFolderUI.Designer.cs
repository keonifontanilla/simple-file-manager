namespace simple_file_manager
{
    partial class OpenFolderUI
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
            this.components = new System.ComponentModel.Container();
            this.folderListView = new System.Windows.Forms.ListView();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.HomeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.MoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderListView
            // 
            this.folderListView.HideSelection = false;
            this.folderListView.LargeImageList = this.iconsList;
            this.folderListView.Location = new System.Drawing.Point(142, 59);
            this.folderListView.Name = "folderListView";
            this.folderListView.Size = new System.Drawing.Size(776, 426);
            this.folderListView.SmallImageList = this.iconsList;
            this.folderListView.TabIndex = 0;
            this.folderListView.UseCompatibleStateImageBehavior = false;
            // 
            // iconsList
            // 
            this.iconsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconsList.ImageSize = new System.Drawing.Size(64, 64);
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(32, 59);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(75, 23);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(32, 103);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(201, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(624, 20);
            this.searchTextBox.TabIndex = 3;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(138, 20);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(57, 20);
            this.SearchLabel.TabIndex = 4;
            this.SearchLabel.Text = "Search";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(843, 20);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 20);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Find";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(32, 147);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(32, 191);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(75, 23);
            this.MoveButton.TabIndex = 7;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            // 
            // OpenFolderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(930, 532);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.folderListView);
            this.Name = "OpenFolderUI";
            this.Text = "OpenFolderUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView folderListView;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button MoveButton;
    }
}