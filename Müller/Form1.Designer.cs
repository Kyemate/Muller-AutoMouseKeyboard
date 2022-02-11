namespace Müller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RepeatNum = new System.Windows.Forms.NumericUpDown();
            this.RepeatCountLabel = new System.Windows.Forms.Label();
            this.enableBtn = new System.Windows.Forms.Button();
            this.dimBtn = new System.Windows.Forms.Button();
            this.recordBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loadPilotBtn = new System.Windows.Forms.Button();
            this.dimBar = new System.Windows.Forms.TrackBar();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimBar)).BeginInit();
            this.SuspendLayout();
            // 
            // RepeatNum
            // 
            this.RepeatNum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RepeatNum.Location = new System.Drawing.Point(3, 36);
            this.RepeatNum.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.RepeatNum.Name = "RepeatNum";
            this.RepeatNum.Size = new System.Drawing.Size(56, 23);
            this.RepeatNum.TabIndex = 3;
            this.RepeatNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RepeatCountLabel
            // 
            this.RepeatCountLabel.AccessibleName = "";
            this.RepeatCountLabel.AutoSize = true;
            this.RepeatCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.RepeatCountLabel.Location = new System.Drawing.Point(0, 18);
            this.RepeatCountLabel.Name = "RepeatCountLabel";
            this.RepeatCountLabel.Size = new System.Drawing.Size(84, 15);
            this.RepeatCountLabel.TabIndex = 4;
            this.RepeatCountLabel.Text = "Repeat Replay:";
            // 
            // enableBtn
            // 
            this.enableBtn.Location = new System.Drawing.Point(112, 65);
            this.enableBtn.Name = "enableBtn";
            this.enableBtn.Size = new System.Drawing.Size(103, 45);
            this.enableBtn.TabIndex = 5;
            this.enableBtn.Text = "Enable Hotkeys";
            this.enableBtn.UseVisualStyleBackColor = true;
            this.enableBtn.Click += new System.EventHandler(this.enableBtn_Click);
            // 
            // dimBtn
            // 
            this.dimBtn.Location = new System.Drawing.Point(112, 116);
            this.dimBtn.Name = "dimBtn";
            this.dimBtn.Size = new System.Drawing.Size(103, 45);
            this.dimBtn.TabIndex = 6;
            this.dimBtn.Text = "Show Dimmmer";
            this.dimBtn.UseVisualStyleBackColor = true;
            this.dimBtn.Click += new System.EventHandler(this.dimBtn_Click);
            // 
            // recordBtn
            // 
            this.recordBtn.Location = new System.Drawing.Point(3, 116);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(103, 45);
            this.recordBtn.TabIndex = 7;
            this.recordBtn.Text = "Record";
            this.recordBtn.UseVisualStyleBackColor = true;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "F3 to start\r\nF4 to stop";
            // 
            // loadPilotBtn
            // 
            this.loadPilotBtn.Location = new System.Drawing.Point(3, 65);
            this.loadPilotBtn.Name = "loadPilotBtn";
            this.loadPilotBtn.Size = new System.Drawing.Size(103, 45);
            this.loadPilotBtn.TabIndex = 9;
            this.loadPilotBtn.Text = "Load Instruction";
            this.loadPilotBtn.UseVisualStyleBackColor = true;
            this.loadPilotBtn.Click += new System.EventHandler(this.loadPilotBtn_Click);
            // 
            // dimBar
            // 
            this.dimBar.BackColor = System.Drawing.SystemColors.Control;
            this.dimBar.Location = new System.Drawing.Point(3, 167);
            this.dimBar.Maximum = 70;
            this.dimBar.Name = "dimBar";
            this.dimBar.Size = new System.Drawing.Size(277, 45);
            this.dimBar.TabIndex = 10;
            this.dimBar.TickFrequency = 7;
            this.dimBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.dimBar.Value = 50;
            this.dimBar.Scroll += new System.EventHandler(this.dimBar_Scroll);
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(0, 3);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(87, 15);
            this.instructionLabel.TabIndex = 11;
            this.instructionLabel.Text = "Replay Loaded:";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(112, 44);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(78, 15);
            this.TimeLabel.TabIndex = 13;
            this.TimeLabel.Text = "execute time:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 203);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dimBar);
            this.Controls.Add(this.loadPilotBtn);
            this.Controls.Add(this.recordBtn);
            this.Controls.Add(this.dimBtn);
            this.Controls.Add(this.enableBtn);
            this.Controls.Add(this.RepeatCountLabel);
            this.Controls.Add(this.RepeatNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Müller 2021";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.RepeatNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public NumericUpDown RepeatNum;
        public Label RepeatCountLabel;
        private Button enableBtn;
        private Button dimBtn;
        private Button recordBtn;
        private Label label2;
        private Button loadPilotBtn;
        private TrackBar dimBar;
        private Label instructionLabel;
        public Label TimeLabel;
    }
}