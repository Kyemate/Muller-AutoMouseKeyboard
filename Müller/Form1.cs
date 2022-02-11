using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;

namespace Müller
{
    public partial class Form1 : Form
    {
        readonly GlobalKeyboardHook _hook = new GlobalKeyboardHook();
        
        //private KeyStampCode[]? _recording;
       // private KeyStampCode[]? _recordingOriginal;
        
        //ManualResetEvent _wait = new ManualResetEvent(false);
        private InputWorker? _inputWorker;
        ScreenDimmer _screenDimmer = new ScreenDimmer();

        long _totalDuration = 0;

        //Todo add setting
        Keys _startKey = Keys.F3;
        Keys _stopKey = Keys.F4;

        public Form1()
        {
            using (Process p = Process.GetCurrentProcess())
                p.PriorityClass = ProcessPriorityClass.High;
            Program.ValidateFileSystem();
            InitializeComponent();
            Keys[] hotkeys = { _startKey, _stopKey };
            _hook.HookedKeys.AddRange(hotkeys);
            _hook.KeyUp += Hook_KeyUp;
            
        }

        private void Hook_KeyUp(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == _startKey)
            {
                if (_inputWorker?.Playing is true)
                    return;
                Text = "Müller {Working hard*}";
                _inputWorker!.Start();
            }
            else if(e.KeyCode == _stopKey)
            {
                if (_inputWorker?.Playing is false)
                    return;

                _inputWorker!.Stop();
                Text = "Müller {Ciggarte break*}";
            }
        }

        private void recordBtn_Click(object sender, EventArgs e)
        {
            if (enableBtn.Text == "Disable Hotkeys")
                _hook.unhook();
            RecorderForm rf = new RecorderForm();
            TopMost = false;
            rf.ShowDialog();
            TopMost = true;
            if (enableBtn.Text == "Disable Hotkeys")
                _hook.hook();
        }

        private void enableBtn_Click(object sender, EventArgs e)
        {
            if (enableBtn.Text == "Disable Hotkeys")
            {
                enableBtn.Text = "Enable Hotkeys";
                _hook.unhook(); 
            }
            else
            {
                enableBtn.Text = "Disable Hotkeys";
                _hook.hook();
            }
        }
       
        private void loadPilotBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Müller Replays|*.mul",
                InitialDirectory = Program.ReplayFolderPath };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] bot = File.ReadAllLines(ofd.FileName);
                List<KeyStampCode> ksc = new List<KeyStampCode>();
                _totalDuration = long.Parse(bot[0].Split('/')[2]);
                foreach (var kp in bot.Skip(1))
                {
                    
                    string[] data = kp.Split(':');
                    if (data.Length == 3)
                        ksc.Add(new KeyStampCode(int.Parse(data[0]),
                                data[1] == "D", int.Parse(data[2])));
                    else
                        ksc.Add(new KeyStampCode(int.Parse(data[0]),
                               data[1] == "D", int.Parse(data[2]), 
                               int.Parse(data[3]), int.Parse(data[4])));
                }
                _inputWorker = new InputWorker(ksc.ToArray(), this);
               
                //_recording = ksc.ToArray();
                //_recordingOriginal = ksc.ToArray();
                instructionLabel.Text = "Replay Loaded: " + ofd.SafeFileName;
                //offsetTextbox.Text = string.Empty;
                //offsetBtn.Enabled = true;
                //numericUpDown1.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _inputWorker?.Stop();
        }

        private void dimBar_Scroll(object sender, EventArgs e)
        {
            _screenDimmer.Opacity = (double)dimBar.Value / 100 + 0.3;
        }

        private void dimBtn_Click(object sender, EventArgs e)
        {
            if (_screenDimmer.IsDisposed)
            {
                _screenDimmer = new ScreenDimmer();
                _screenDimmer.Opacity = (double)dimBar.Value / 100;
                dimBtn.Text = "Hide Dim";
            }
            else if (_screenDimmer.Visible)
            { 
                _screenDimmer.Hide();
                dimBtn.Text = "Show Dim";
            }
            else
            {
                _screenDimmer.Show();
                dimBtn.Text = "Hide Dim";
            }

        }

        private void offsetBtn_Click(object sender, EventArgs e)
        {
            //_inputWorker?.SetOffset((long)numericUpDown1.Value);
            
            //_recording = _recordingOriginal;
            //List<KeyStampCode> keys = new List<KeyStampCode>();
            //double input;
            //string sign = offsetTextbox.Text.Substring(0,1);
            //if (!double.TryParse(offsetTextbox.Text, out input))
            //{
            //     input = double.Parse(offsetTextbox.Text.Remove(0, 1));
            //}
            
            
            //foreach (var item in _recordingOriginal)
            //{
            //    int minus = (int)(item.Time - input) > 0 ? 
            //        (int)(item.Time - input)
            //        : 1;
            //    int plus = (int)(item.Time + input) > 0 ? 
            //        (int)(item.Time + input)
            //        : 1;
            //    int multi = (int)(item.Time * input) > 0 ? 
            //        (int)(item.Time * input) : 1;
            //    int devided = (int)(item.Time / input) > 0 ? 
            //        (int)(item.Time / input) :
            //        1;
            //    if (sign == "-")
            //        keys.Add(new KeyStampCode((int)item.Char, item.Hold, minus, item.X, item.Y ));
            //    else if(sign == "*")
            //        keys.Add(new KeyStampCode((int)item.Char, item.Hold, multi, item.X, item.Y));
            //    else if(sign == "/")
            //        keys.Add(new KeyStampCode((int)item.Char, item.Hold, devided, item.X, item.Y));
            //    else
            //        keys.Add(new KeyStampCode((int)item.Char, item.Hold, plus, item.X, item.Y));
            //}
            //_recording = keys.ToArray();    
        }
    }
}