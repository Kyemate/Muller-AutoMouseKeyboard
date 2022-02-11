namespace Müller
{
    partial class KeyListForm
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
            this.keyListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.recordAllKeysCheckbox = new System.Windows.Forms.CheckBox();
            this.mouseCB = new System.Windows.Forms.CheckBox();
            this.mouseMoveCB = new System.Windows.Forms.CheckBox();
            this.mouseMoveInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mouseMoveInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // keyListBox
            // 
            this.keyListBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyListBox.FormattingEnabled = true;
            this.keyListBox.Location = new System.Drawing.Point(12, 35);
            this.keyListBox.Name = "keyListBox";
            this.keyListBox.Size = new System.Drawing.Size(104, 277);
            this.keyListBox.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(12, 316);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(104, 23);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // recordAllKeysCheckbox
            // 
            this.recordAllKeysCheckbox.AutoSize = true;
            this.recordAllKeysCheckbox.Enabled = false;
            this.recordAllKeysCheckbox.Location = new System.Drawing.Point(12, 428);
            this.recordAllKeysCheckbox.Name = "recordAllKeysCheckbox";
            this.recordAllKeysCheckbox.Size = new System.Drawing.Size(104, 34);
            this.recordAllKeysCheckbox.TabIndex = 3;
            this.recordAllKeysCheckbox.Text = "Ingore list and \r\nrecord all keys.";
            this.recordAllKeysCheckbox.UseVisualStyleBackColor = true;
            this.recordAllKeysCheckbox.CheckedChanged += new System.EventHandler(this.recordAllKeysCheckbox_CheckedChanged);
            // 
            // mouseCB
            // 
            this.mouseCB.AutoSize = true;
            this.mouseCB.Location = new System.Drawing.Point(10, 341);
            this.mouseCB.Name = "mouseCB";
            this.mouseCB.Size = new System.Drawing.Size(94, 19);
            this.mouseCB.TabIndex = 4;
            this.mouseCB.Text = "Mouse clicks";
            this.mouseCB.UseVisualStyleBackColor = true;
            this.mouseCB.CheckedChanged += new System.EventHandler(this.mouseCB_CheckedChanged);
            // 
            // mouseMoveCB
            // 
            this.mouseMoveCB.AutoSize = true;
            this.mouseMoveCB.Location = new System.Drawing.Point(10, 357);
            this.mouseMoveCB.Name = "mouseMoveCB";
            this.mouseMoveCB.Size = new System.Drawing.Size(117, 19);
            this.mouseMoveCB.TabIndex = 5;
            this.mouseMoveCB.Text = "Mouse movment";
            this.mouseMoveCB.UseVisualStyleBackColor = true;
            this.mouseMoveCB.CheckedChanged += new System.EventHandler(this.mouseMoveCB_CheckedChanged);
            // 
            // mouseMoveInterval
            // 
            this.mouseMoveInterval.Enabled = false;
            this.mouseMoveInterval.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mouseMoveInterval.Location = new System.Drawing.Point(10, 389);
            this.mouseMoveInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mouseMoveInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mouseMoveInterval.Name = "mouseMoveInterval";
            this.mouseMoveInterval.Size = new System.Drawing.Size(75, 22);
            this.mouseMoveInterval.TabIndex = 6;
            this.mouseMoveInterval.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.mouseMoveInterval.ValueChanged += new System.EventHandler(this.mouseMoveInterval_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mouse move interval";
            // 
            // KeyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(128, 419);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mouseMoveInterval);
            this.Controls.Add(this.mouseMoveCB);
            this.Controls.Add(this.mouseCB);
            this.Controls.Add(this.recordAllKeysCheckbox);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.keyListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KeyListForm";
            this.Text = "Input Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyListForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mouseMoveInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox keyListBox;
        private TextBox textBox1;
        private Button deleteBtn;
        private CheckBox recordAllKeysCheckbox;
        private CheckBox mouseCB;
        private CheckBox mouseMoveCB;
        private NumericUpDown mouseMoveInterval;
        private Label label1;
    }
}