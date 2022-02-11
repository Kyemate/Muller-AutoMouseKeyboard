namespace Müller_Studio
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deleteProjectBtn = new System.Windows.Forms.Button();
            this.createProjectBtn = new System.Windows.Forms.Button();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.projectListbox = new System.Windows.Forms.ListBox();
            this.mulListView = new BrightIdeasSoftware.ObjectListView();
            this.addMulBtn = new System.Windows.Forms.Button();
            this.buildBtn = new System.Windows.Forms.Button();
            this.loadProjectBtn = new System.Windows.Forms.Button();
            this.deleteMulBtn = new System.Windows.Forms.Button();
            this.outputFolderBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mulListView)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteProjectBtn
            // 
            this.deleteProjectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteProjectBtn.Enabled = false;
            this.deleteProjectBtn.Location = new System.Drawing.Point(12, 510);
            this.deleteProjectBtn.Name = "deleteProjectBtn";
            this.deleteProjectBtn.Size = new System.Drawing.Size(120, 32);
            this.deleteProjectBtn.TabIndex = 0;
            this.deleteProjectBtn.Text = "Delete Project";
            this.deleteProjectBtn.UseVisualStyleBackColor = true;
            this.deleteProjectBtn.Click += new System.EventHandler(this.deleteProjectBtn_Click);
            // 
            // createProjectBtn
            // 
            this.createProjectBtn.Enabled = false;
            this.createProjectBtn.Location = new System.Drawing.Point(138, 11);
            this.createProjectBtn.Name = "createProjectBtn";
            this.createProjectBtn.Size = new System.Drawing.Size(120, 32);
            this.createProjectBtn.TabIndex = 1;
            this.createProjectBtn.Text = "Create Project";
            this.createProjectBtn.UseVisualStyleBackColor = true;
            this.createProjectBtn.Click += new System.EventHandler(this.createProjectBtn_Click);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.projectNameTextBox.Location = new System.Drawing.Point(264, 12);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(246, 31);
            this.projectNameTextBox.TabIndex = 2;
            this.projectNameTextBox.TextChanged += new System.EventHandler(this.projectNameTextBox_TextChanged);
            // 
            // projectListbox
            // 
            this.projectListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.projectListbox.BackColor = System.Drawing.SystemColors.Window;
            this.projectListbox.FormattingEnabled = true;
            this.projectListbox.ItemHeight = 15;
            this.projectListbox.Location = new System.Drawing.Point(12, 12);
            this.projectListbox.Name = "projectListbox";
            this.projectListbox.Size = new System.Drawing.Size(120, 454);
            this.projectListbox.TabIndex = 3;
            this.projectListbox.SelectedIndexChanged += new System.EventHandler(this.projectListbox_SelectedIndexChanged);
            // 
            // mulListView
            // 
            this.mulListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mulListView.CellEditUseWholeCell = false;
            this.mulListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.mulListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mulListView.FullRowSelect = true;
            this.mulListView.GridLines = true;
            this.mulListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mulListView.Location = new System.Drawing.Point(138, 49);
            this.mulListView.MultiSelect = false;
            this.mulListView.Name = "mulListView";
            this.mulListView.ShowGroups = false;
            this.mulListView.Size = new System.Drawing.Size(650, 455);
            this.mulListView.TabIndex = 4;
            this.mulListView.View = System.Windows.Forms.View.Details;
            this.mulListView.SelectedIndexChanged += new System.EventHandler(this.mulListView_SelectedIndexChanged);
            // 
            // addMulBtn
            // 
            this.addMulBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addMulBtn.Enabled = false;
            this.addMulBtn.Location = new System.Drawing.Point(416, 510);
            this.addMulBtn.Name = "addMulBtn";
            this.addMulBtn.Size = new System.Drawing.Size(120, 32);
            this.addMulBtn.TabIndex = 5;
            this.addMulBtn.Text = "Add Mul File";
            this.addMulBtn.UseVisualStyleBackColor = true;
            this.addMulBtn.Click += new System.EventHandler(this.addMulBtn_Click);
            // 
            // buildBtn
            // 
            this.buildBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buildBtn.Enabled = false;
            this.buildBtn.Location = new System.Drawing.Point(668, 510);
            this.buildBtn.Name = "buildBtn";
            this.buildBtn.Size = new System.Drawing.Size(120, 32);
            this.buildBtn.TabIndex = 6;
            this.buildBtn.Text = "Build To Output";
            this.buildBtn.UseVisualStyleBackColor = true;
            this.buildBtn.Click += new System.EventHandler(this.buildBtn_Click);
            // 
            // loadProjectBtn
            // 
            this.loadProjectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadProjectBtn.Enabled = false;
            this.loadProjectBtn.Location = new System.Drawing.Point(12, 472);
            this.loadProjectBtn.Name = "loadProjectBtn";
            this.loadProjectBtn.Size = new System.Drawing.Size(120, 32);
            this.loadProjectBtn.TabIndex = 7;
            this.loadProjectBtn.Text = "Load Project";
            this.loadProjectBtn.UseVisualStyleBackColor = true;
            this.loadProjectBtn.Click += new System.EventHandler(this.loadProjectBtn_Click);
            // 
            // deleteMulBtn
            // 
            this.deleteMulBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteMulBtn.Enabled = false;
            this.deleteMulBtn.Location = new System.Drawing.Point(542, 510);
            this.deleteMulBtn.Name = "deleteMulBtn";
            this.deleteMulBtn.Size = new System.Drawing.Size(120, 32);
            this.deleteMulBtn.TabIndex = 8;
            this.deleteMulBtn.Text = "Delete Mul";
            this.deleteMulBtn.UseVisualStyleBackColor = true;
            this.deleteMulBtn.Click += new System.EventHandler(this.deleteMulBtn_Click);
            // 
            // outputFolderBtn
            // 
            this.outputFolderBtn.Location = new System.Drawing.Point(516, 11);
            this.outputFolderBtn.Name = "outputFolderBtn";
            this.outputFolderBtn.Size = new System.Drawing.Size(120, 32);
            this.outputFolderBtn.TabIndex = 9;
            this.outputFolderBtn.Text = "Output Folder";
            this.outputFolderBtn.UseVisualStyleBackColor = true;
            this.outputFolderBtn.Click += new System.EventHandler(this.outputFolderBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.outputFolderBtn);
            this.Controls.Add(this.deleteMulBtn);
            this.Controls.Add(this.loadProjectBtn);
            this.Controls.Add(this.buildBtn);
            this.Controls.Add(this.addMulBtn);
            this.Controls.Add(this.mulListView);
            this.Controls.Add(this.projectListbox);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.createProjectBtn);
            this.Controls.Add(this.deleteProjectBtn);
            this.Name = "Form1";
            this.Text = "Müller Studio";
            ((System.ComponentModel.ISupportInitialize)(this.mulListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button deleteProjectBtn;
        private Button createProjectBtn;
        private TextBox projectNameTextBox;
        private ListBox projectListbox;
        private BrightIdeasSoftware.ObjectListView mulListView;
        private Button addMulBtn;
        private Button buildBtn;
        private Button loadProjectBtn;
        private Button deleteMulBtn;
        private Button outputFolderBtn;
    }
}