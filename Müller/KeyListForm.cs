using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Müller.Program;

namespace Müller
{
    public partial class KeyListForm : Form
    {
       
        public KeyListForm()
        {
            ValidateFileSystem();
            string[] settingsFile = File.ReadAllLines(KeySettingsPath);
            InitializeComponent();
            KeyList = new List<Keys>();

            if (settingsFile != null && settingsFile.Length > 0)
            {
                mouseCB.Checked = settingsFile[0] == "mouse=true";
                mouseMoveCB.Checked = settingsFile[1] == "mouseMove=true";
                mouseMoveInterval.Enabled = settingsFile[1] == "mouseMove=true";
                mouseMoveInterval.Value = int.Parse(settingsFile[2]);

                foreach (string? s in settingsFile.Skip(3))
                {
                    KeyList.Add((Keys)Enum.Parse(typeof(Keys), s));
                    keyListBox.Items.Add(s);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            textBox1.Text = e.KeyCode.ToString();
            if (KeyList.Contains(e.KeyCode))
                return;
            keyListBox.Items.Add(e.KeyCode);
            KeyList.Add(e.KeyCode);
        }

        private void KeyListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] settingsFile = { mouseCB.Checked ? "mouse=true" : "mouse=false", 
                mouseMoveCB.Checked ? "mouseMove=true" : "mouseMove=false", mouseMoveInterval.Value.ToString() };
            settingsFile = settingsFile.Concat(KeyList.Select(k => k.ToString())).ToArray();
            
            File.WriteAllLines(KeySettingsPath, settingsFile);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (keyListBox.SelectedIndex == -1)
                return;
            KeyList.RemoveAt(keyListBox.SelectedIndex);
            keyListBox.Items.RemoveAt(keyListBox.SelectedIndex);
            ////var selectedIndcies = keyListBox.SelectedIndices;
            //for(int i = 0; i > keyListBox.SelectedIndices.Count; i++)
            //{
            //    keyListBox.Items.RemoveAt(keyListBox.SelectedIndex);
            //}
            ////keyListBox.Items.Clear();
            ////keyListBox.Items.AddRange(keyList.Select(s => s.ToString()).ToArray());
        }

        private void recordAllKeysCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void mouseCB_CheckedChanged(object sender, EventArgs e)
        {
            RecordMouse = mouseCB.Checked;
        }

        private void mouseMoveCB_CheckedChanged(object sender, EventArgs e)
        {
            RecordMouseMove = mouseMoveCB.Checked;
            mouseMoveInterval.Enabled = mouseMoveCB.Checked;
        }

        private void mouseMoveInterval_ValueChanged(object sender, EventArgs e)
        {
            MouseMoveInterval = (long)mouseMoveInterval.Value;
        }
    }
}
