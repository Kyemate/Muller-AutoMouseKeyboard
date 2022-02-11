using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace Müller;

internal readonly struct KeyStamp

{
    public KeyStamp(int c, bool hold, long time)
    {
        Hold = hold;
        Char = c;
        Time = time;
    }
    public KeyStamp(int c, bool hold, long time, int x, int y)
    {
        Hold = hold;
        Char = c;
        Time = time;
        X = x;
        Y = y;
    }

    public readonly bool Hold;
    public readonly int Char;
    public readonly long Time;

    public readonly int X = 0;
    public readonly int Y = 0;
}
internal readonly struct KeyStampCode
{
    public KeyStampCode(int charValue, bool hold, long time)
    {
        Hold = hold;
        Char = (VirtualKeyCode)charValue;
        Time = time;
    }
    public KeyStampCode(int charValue, bool hold, long time, int x, int y)
    {
        Hold = hold;
        Char = (VirtualKeyCode)charValue;
        Time = time;
        X = x;
        Y = y;
    }

    public readonly VirtualKeyCode Char;
    public readonly bool Hold;
    public readonly long Time;

    public readonly int X = 0;
    public readonly int Y = 0;
}
