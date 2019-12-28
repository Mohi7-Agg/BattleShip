using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_Battleship
{
    public class Ship : IShip
    {
        public Utils.ShipType Type;
        public Ship(int width, int height, Utils.ShipType shipType)
        {
            this.Height = height;
            this.Width = width;
            this.Strength = (int)shipType;
        }

        public int Strength { get; private set; }
        public int Width { get; }
        public int Height { get; }
    }
}
