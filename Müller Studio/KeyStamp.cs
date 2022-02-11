using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Müller_Studio
{
    internal struct KeyStamp

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
        public readonly int Y= 0;
    }
}
