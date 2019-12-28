using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_Battleship
{
    public static class Utils
    {
        public static int ParseInt(char s)
        {
            return s - 64;
        }
        public enum ShipType
        {
            P = 1,
            Q = 2
        }

        public static readonly int MAX_WIDTH = 9;
        
        public static readonly int MAX_HEIGHT = 26;
    }
}
