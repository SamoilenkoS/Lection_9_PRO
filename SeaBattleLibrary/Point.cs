using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleLibrary
{
    public struct Point
    {
        private int _x;
        private int _y;

        public int X { get => _x; }
        public int Y { get => _y; }

        public Point(int x, int y)
        {
            if(x < 0 || y < 0)
            {
                throw new ArgumentException();
            }

            _x = x;
            _y = y;
        }
    }
}
