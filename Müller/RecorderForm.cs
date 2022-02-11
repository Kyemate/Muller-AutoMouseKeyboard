using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using static Müller.Program;

namespace Müller
{
    public partial class RecorderForm : Form
    {
        IKeyboardMouseEvents _mouseHook = Hook.GlobalEvents();
        GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();
        private Stopwatch timer;
        List<KeyStamp> keyStamps = new List<KeyStamp>();
        bool recording = false;
        List<int> keysdown;
        //Todo add setting
        const Keys _startKey = Keys.F3;
        const Keys _stopKey = Keys.F4;

        public RecorderForm()
        {
           
            InitializeComponent();
            ValidateFileSystem();

            string[] settingsFile = File.ReadAllLines(KeySettingsPath);

            if (settingsFile != null && settingsFile.Length > 0)
            {
                foreach (string? s in settingsFile.Skip(3))
                {
                    KeyList.Add((Keys)Enum.Parse(typeof(Keys), s));
                }
                RecordMouse = settingsFile[0] == "mouse=true";
                RecordMouseMove = settingsFile[1] == "mouseMove=true";
                MouseMoveInterval = long.Parse(settingsFile[2]);
            }
            else
                keySettingsBtn_Click(null, null);
            
            _keyboardHook.HookedKeys.AddRange(KeyList.Where(k => k != Keys.LButton && k != Keys.RButton));
            _keyboardHook.HookedKeys.AddRange(new Keys[]{ _startKey, _stopKey});
            _keyboardHook.KeyDown += GlobalHook_KeyDown;
            _keyboardHook.KeyUp += GlobalHook_KeyUp;
            _keyboardHook.hook();

            keysdown = new List<int>(KeyList.Count);
        }

        private void _mouseHook_MouseUp(object? sender, MouseEventArgs e)
        {
            if (recording)
            { 
                if(e.Button == MouseButtons.Left)
                    keyStamps.Add(new KeyStamp(1, false, timer.ElapsedMilliseconds, e.X, e.Y));
                else if(e.Button == MouseButtons.Right)
                    keyStamps.Add(new KeyStamp(2, false, timer.ElapsedMilliseconds, e.X, e.Y));
            }

        }

        private void _mouseHook_MouseDown(object? sender, MouseEventArgs e)
        {
            if (recording)
            {
                if (e.Button == MouseButtons.Left)
                    keyStamps.Add(new KeyStamp(1, true, timer.ElapsedMilliseconds, e.X, e.Y));
                else if (e.Button == MouseButtons.Right)
                    keyStamps.Add(new KeyStamp(2, true, timer.ElapsedMilliseconds, e.X, e.Y));
            }
        }
        long _mouseMoveDelay = 0;
        int _currentMouseX = 0;
        int _currentMouseY = 0;
        private void _mouseHook_MouseMove(object? sender, MouseEventArgs e)
        {
            if (recording && (_currentMouseX != e.X || _currentMouseY != e.Y) && timer.ElapsedMilliseconds >= _mouseMoveDelay + MouseMoveInterval)
            { 
                keyStamps.Add(new KeyStamp(134, true, timer.ElapsedMilliseconds, e.X, e.Y));
                _mouseMoveDelay = timer.ElapsedMilliseconds;
                _currentMouseX = e.X;
                _currentMouseY = e.Y;
            }
        }

        private void GlobalHook_KeyUp(object? sender, KeyEventArgs e)
        {
            if (recording)
            {
                keyStamps.Add(new KeyStamp(e.KeyValue, false, timer.ElapsedMilliseconds));
                keysdown.Remove(e.KeyValue);
            }
            else if (e.KeyCode == _startKey)
            {
                
                keySettingsBtn.Enabled = false;
                keyStamps = new List<KeyStamp>();
                timer = new Stopwatch();
                timer.Start();
                recording = true;
                Text = Text + " {Learning*}";
                if (RecordMouse)
                {
                    _mouseHook = Hook.GlobalEvents();
                    _mouseHook.MouseDown += _mouseHook_MouseDown;
                    _mouseHook.MouseUp += _mouseHook_MouseUp;
                }
                if (RecordMouseMove)
                    _mouseHook.MouseMove += _mouseHook_MouseMove;
            }
            if (e.KeyCode == _stopKey)
            {
                timer.Stop();
                textBox1.Text = timer.ElapsedMilliseconds.ToString();
                keySettingsBtn.Enabled = true;
                recording = false;
                saveButton.Enabled = true;
                saveButton.Text = "Save";
                Text = "Müller School";
                if (RecordMouseMove)
                    _mouseHook.MouseMove -= _mouseHook_MouseMove;
                if (RecordMouse)
                {
                    _mouseHook.MouseDown -= _mouseHook_MouseDown;
                    _mouseHook.MouseUp -= _mouseHook_MouseUp;
                    _mouseHook.Dispose();
                }
            }
        }

        private void GlobalHook_KeyDown(object? sender, KeyEventArgs e)
        {
            if(recording && !keysdown.Contains(e.KeyValue))
            {
                keyStamps.Add(new KeyStamp(e.KeyValue, true, timer.ElapsedMilliseconds));
                keysdown.Add(e.KeyValue);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //start timer loop through array and check array[x] = timer.mili
            if (File.Exists(ReplayFolderPath + textBox1.Text + ".mul")) { MessageBox.Show("Replay already exists!"); return; }

            long endTimeUp = keyStamps.First(o => o.Char == (int)_stopKey && !o.Hold).Time;
            keyStamps.RemoveAll(o => o.Char == (int)_stopKey);
            KeyStamp endkey = new KeyStamp();

            //endkey.Add(new KeyStamp(135, true, endTimeDown));
            endkey = new KeyStamp(135, false, endTimeUp);

            List<string> recording = new List<string>();
            recording.Add($"</TotalDuration/{endTimeUp}/>");

            recording.AddRange(keyStamps.Select(k => $"{k.Char}:{(k.Hold ? 'D' : 'U')}:" +
            $"{k.Time}{(k.X == 0 && k.Y == 0 ? string.Empty : $":{k.X}:{k.Y}")}"));
            recording.Add(endkey.Char + ":" + 'U' + ":" + endkey.Time);

            File.WriteAllLines(ReplayFolderPath + textBox1.Text + ".mul", recording);
        }

        private void keySettingsBtn_Click(object? sender, EventArgs? e)
        {
            _keyboardHook.unhook();
            if(RecordMouseMove)
                _mouseHook.MouseMove -= _mouseHook_MouseMove;
            if (RecordMouse)
            {
                _mouseHook.MouseDown -= _mouseHook_MouseDown;
                _mouseHook.MouseUp -= _mouseHook_MouseUp;
                
                _mouseHook.Dispose();
            }
            KeyListForm klf = new KeyListForm();
            klf.ShowDialog();
            _keyboardHook.HookedKeys.Clear();
            _keyboardHook.HookedKeys.AddRange(KeyList.Where(k => k != Keys.LButton && k != Keys.RButton));
            _keyboardHook.HookedKeys.AddRange(new Keys[] { _startKey, _stopKey });
            if (RecordMouse)
            {
                _mouseHook = Hook.GlobalEvents();
                _mouseHook.MouseDown += _mouseHook_MouseDown;
                _mouseHook.MouseUp += _mouseHook_MouseUp;
            }
            if (RecordMouseMove)
                _mouseHook.MouseMove += _mouseHook_MouseMove;
            keysdown = new List<int>(KeyList.Count);
            _keyboardHook.hook();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void RecorderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mouseHook.Dispose();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
