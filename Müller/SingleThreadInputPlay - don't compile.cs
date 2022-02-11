        private void PlayKeyStampCodes(KeyStampCode[] kts)
        {
            Stopwatch timer = new Stopwatch();
            InvokeUI(() => {
                RepeatCountLabel.Text = "Repeat Replay:";
            });

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                InvokeUI(() => {
                    RepeatCountLabel.Text = "Repeated Replay: " + i;
                });
                timer.Restart();
                foreach (KeyStampCode keyTStamp in kts)
                {
                    if (_dispose)
                    {
                        _dispose = false;
                        return;
                    }
                    //_wait.WaitOne((int)(keyTStamp.Time - timer.ElapsedMilliseconds));
                    while (keyTStamp.Time > timer.ElapsedMilliseconds) ;

                    if (keyTStamp.Char == VirtualKeyCode.LBUTTON)
                    {
                        if (keyTStamp.Hold)
                        {
                            _virutalInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                            _virutalInput.Mouse.LeftButtonDown();
                        }
                        else
                        {
                            _virutalInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                            _virutalInput.Mouse.LeftButtonUp();
                        }
                    }
                    else if(keyTStamp.Char == VirtualKeyCode.RBUTTON)
                    {
                        if (keyTStamp.Hold)
                        {
                            _virutalInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                            _virutalInput.Mouse.RightButtonDown();
                        }
                        else
                        {
                            _virutalInput.Mouse.MoveMouseTo(keyTStamp.X * _screenWidth, keyTStamp.Y * _screenHeight);
                            _virutalInput.Mouse.RightButtonUp();
                        }
                    }
                    else if (keyTStamp.Hold)
                        _virutalInput.Keyboard.KeyDown(keyTStamp.Char);
                    else
                        _virutalInput.Keyboard.KeyUp(keyTStamp.Char);

                }
            }
            timer.Stop();

            _playing = false;
            _dispose = false;

            InvokeUI(() => {
                TimeLabel.Text = "Execution time: " + timer.ElapsedMilliseconds.ToString();
                Text = "Müller {Ciggarte break*}";
            });

        }