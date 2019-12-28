using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_Battleship
{
    public class Missile : IMissile
    {
        public Missile(string location)
        {
            this.X = Utils.ParseInt(location[0]) - 1;
            this.Y = int.Parse(location[1].ToString()) - 1;
            this.Target = location;
        }

        public string Target { get; }

        public int X { get; }
        public int Y { get; }

    }
}
