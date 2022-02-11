using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Müller;

internal class InputWorker
{
    readonly Form1 _parentForm;

    readonly InputSimulator _virtualInput = new InputSimulator();
    //KeyStampCode[] _ksc;
    private readonly KeyStampCode[] _keyDownKsc;
    private readonly KeyStampCode[] _keyUpKsc;
    private readonly KeyStampCode[] _mouseMoveKsc;

    //ManualResetEventSlim _downMre;
    //ManualResetEventSlim _upMre;  
    //ManualResetEventSlim _mouseMre;
    private readonly Stopwatch _timer = new Stopwatch();

    private volatile bool _dispose = false;
    private volatile bool _playing = false;


    private readonly double _screenWidth;
    private readonly double _screenHeight;

    
    public InputWorker(KeyStampCode[] ksc, Form1 parentForm)
    {
        _screenWidth = 65535.0d / Screen.PrimaryScreen.Bounds.Width;
        _screenHeight = 65535.0d / Screen.PrimaryScreen.Bounds.Height;
        _parentForm = parentForm;
        List<KeyStampCode> downKsc = new List<KeyStampCode>();
        List<KeyStampCode> upKsc = new List<KeyStampCode>();
        List<KeyStampCode> mouseMoveKsc = new List<KeyStampCode>();

        foreach (KeyStampCode keyTStamp in ksc)
        {
            if (keyTStamp.Char == VirtualKeyCode.F23)
                mouseMoveKsc.Add(keyTStamp);
            else if (keyTStamp.Hold)
                downKsc.Add(keyTStamp);
            else
                upKsc.Add(keyTStamp);
        }
        _mouseMoveKsc = mouseMoveKsc.ToArray();
        _keyDownKsc = downKsc.ToArray();
        _keyUpKsc = upKsc.ToArray();

       
    }
    long originalOffset = 0;
    public void SetOffset(long offset)
        {
            for (int i = 0; i < _keyDownKsc.Length; i++)
            {
                _keyDownKsc[i] = new KeyStampCode((int)_keyDownKsc[i].Char, _keyDownKsc[i].Hold,
                    _keyDownKsc[i].Time - originalOffset + offset, _keyDownKsc[i].X, _keyDownKsc[i].Y);
            } 
            for (int i = 0; i < _keyUpKsc.Length; i++)
            {
                _keyUpKsc[i] = new KeyStampCode((int)_keyUpKsc[i].Char, _keyUpKsc[i].Hold,
                    _keyUpKsc[i].Time - originalOffset + offset, _keyUpKsc[i].X, _keyUpKsc[i].Y);
            }
            for (int i = 0; i < _mouseMoveKsc.Length; i++)
            {
                _mouseMoveKsc[i] = new KeyStampCode((int)_mouseMoveKsc[i].Char, _mouseMoveKsc[i].Hold,
                    _mouseMoveKsc[i].Time - originalOffset + offset, _mouseMoveKsc[i].X, _mouseMoveKsc[i].Y);
            }
            originalOffset = offset;
        }

    public bool Playing { get { return _playing; } set { _playing = value; } }

    public void Start()
    {
        _playing = true;
        
        var task = Task.Factory.StartNew(() =>
        {
            //Task _keyDownThread;
            //Task _keyUpThread;
            //Task _mouseMoveThread;

            //_keyDownThread.IsBackground = true;

            for (int i = 0; i < _parentForm.RepeatNum.Value; i++)
            {
                InvokeUI(() => {
                    _parentForm.RepeatCountLabel.Text = "Repeated Replay: " + i;
                });
                if (_dispose)
                    break;

                Task keyDownThread = Task.Run(() => KeyDownWorker(in _keyDownKsc));
                Task keyUpThread = Task.Run(() => KeyUpWorker(in _keyUpKsc));
                Task mouseMoveThread = Task.Run(() => MouseWorker(in _mouseMoveKsc));
                _timer.Restart();

                Task.WaitAll(keyUpThread, keyDownThread, mouseMoveThread);
            }
            _timer.Stop();


            _playing = false;
            _dispose = false;
            InvokeUI(() =>
            {
                _parentForm.TimeLabel.Text = "Execution time: " + _timer.ElapsedMilliseconds.ToString();
                _parentForm.Text = "Müller {Ciggarte break*}";
            });

            
        });
        
      

    }

    public bool Stop()
        {
            _playing = false;
            _dispose = true;

            return true;
        }

    private void InvokeUI(Action a)
        {
            _parentForm.BeginInvoke(new MethodInvoker(a));
        }

    private void KeyDownWorker(in KeyStampCode[] ksc)
        {
            
            foreach (KeyStampCode keyTStamp in ksc)
            {
                while (keyTStamp.Time > _timer.ElapsedMilliseconds) ;

                if (keyTStamp.Char == VirtualKeyCode.LBUTTON || keyTStamp.Char == VirtualKeyCode.RBUTTON)
                {
                    _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);

                    if (keyTStamp.Char == VirtualKeyCode.LBUTTON)
                        _virtualInput.Mouse.LeftButtonDown();
                    else
                        _virtualInput.Mouse.RightButtonDown();
                }
                else 
                    _virtualInput.Keyboard.KeyDown(keyTStamp.Char);
                if (_dispose) return;
            }


           
        }
    private void KeyUpWorker(in KeyStampCode[] ksc)
        {
            SpinWait spinWait = new SpinWait();
            foreach (KeyStampCode keyTStamp in ksc)
            {
                while (keyTStamp.Time > _timer.ElapsedMilliseconds) spinWait.SpinOnce();
                if (keyTStamp.Char == VirtualKeyCode.LBUTTON || keyTStamp.Char == VirtualKeyCode.RBUTTON)
                {
                    _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);

                    if (keyTStamp.Char == VirtualKeyCode.LBUTTON)
                        _virtualInput.Mouse.LeftButtonUp();
                    else
                        _virtualInput.Mouse.RightButtonUp();
                }
                else
                    _virtualInput.Keyboard.KeyUp(keyTStamp.Char);

                if (_dispose) return;
            }
            
        }
    private void MouseWorker(in KeyStampCode[] ksc)
        {
            SpinWait spinWait = new SpinWait();
            foreach (KeyStampCode keyTStamp in ksc)
            {
                while (keyTStamp.Time > _timer.ElapsedMilliseconds) spinWait.SpinOnce();
                _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                #region MouseClickOld
                //if (keyTStamp.Char == VirtualKeyCode.LBUTTON)
                //{
                //    if (keyTStamp.Hold)
                //    {
                //        _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                //        _virtualInput.Mouse.LeftButtonDown();
                //    }
                //    else
                //    {
                //        _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                //        _virtualInput.Mouse.LeftButtonUp();
                //    }
                //}
                //else if (keyTStamp.Char == VirtualKeyCode.RBUTTON)
                //{
                //    if (keyTStamp.Hold)
                //    {
                //        _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                //        _virtualInput.Mouse.RightButtonDown();
                //    }
                //    else
                //    {
                //        _virtualInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                //        _virtualInput.Mouse.RightButtonUp();
                //    }
                //}
                #endregion
                if (_dispose) return;
            }
        }
}

