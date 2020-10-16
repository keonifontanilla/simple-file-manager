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
            this.homeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.newFolderButton = new System.Windows.Forms.Button();
            this.sideBarPanel = new System.Windows.Forms.Panel();
            this.moveButton = new System.Windows.Forms.Button();
            this.sideBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderListView
            // 
            this.folderListView.HideSelection = false;
            this.folderListView.LargeImageList = this.iconsList;
            this.folderListView.Location = new System.Drawing.Point(142, 59);
            this.folderListView.Name = "folderListView";
            this.folderListView.Size = new System.Drawing.Size(782, 426);
            this.folderListView.SmallImageList = this.iconsList;
            this.folderListView.TabIndex = 0;
            this.folderListView.UseCompatibleStateImageBehavior = false;
            this.folderListView.SelectedIndexChanged += new System.EventHandler(this.folderListView_SelectedIndexChanged);
            // 
            // iconsList
            // 
            this.iconsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconsList.ImageSize = new System.Drawing.Size(48, 48);
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(32, 59);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(75, 23);
            this.homeButton.TabIndex = 1;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(32, 103);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(201, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(639, 20);
            this.searchTextBox.TabIndex = 3;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.ForeColor = System.Drawing.Color.White;
            this.SearchLabel.Location = new System.Drawing.Point(138, 20);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(57, 20);
            this.SearchLabel.TabIndex = 4;
            this.SearchLabel.Text = "Search";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(846, 20);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(78, 20);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Find";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(32, 147);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // newFolderButton
            // 
            this.newFolderButton.Location = new System.Drawing.Point(32, 191);
            this.newFolderButton.Name = "newFolderButton";
            this.newFolderButton.Size = new System.Drawing.Size(75, 23);
            this.newFolderButton.TabIndex = 7;
            this.newFolderButton.Text = "New Folder";
            this.newFolderButton.UseVisualStyleBackColor = true;
            this.newFolderButton.Click += new System.EventHandler(this.newFolderButton_Click);
            // 
            // sideBarPanel
            // 
            this.sideBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.sideBarPanel.Controls.Add(this.moveButton);
            this.sideBarPanel.Controls.Add(this.homeButton);
            this.sideBarPanel.Controls.Add(this.newFolderButton);
            this.sideBarPanel.Controls.Add(this.backButton);
            this.sideBarPanel.Controls.Add(this.openButton);
            this.sideBarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarPanel.Location = new System.Drawing.Point(0, 0);
            this.sideBarPanel.Name = "sideBarPanel";
            this.sideBarPanel.Size = new System.Drawing.Size(136, 532);
            this.sideBarPanel.TabIndex = 8;
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(32, 234);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 8;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // OpenFolderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(930, 532);
            this.Controls.Add(this.sideBarPanel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.folderListView);
            this.Name = "OpenFolderUI";
            this.Text = "OpenFolderUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenFolderUI_FormClosed);
            this.sideBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView folderListView;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button newFolderButton;
        private System.Windows.Forms.Panel sideBarPanel;
        private System.Windows.Forms.Button moveButton;
    }
}