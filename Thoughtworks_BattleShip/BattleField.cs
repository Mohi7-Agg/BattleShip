using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_Battleship
{
    public class BattleField : IBattleField
    {
        private readonly int width;
        private readonly int height;
        private List<IShip> ships;
        public int[,] strength { get; set; }

        public BattleField(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.strength = new int[height, width];
            this.ships = new List<IShip>();
    }

        public int TotalStrength { get; private set; }

        public void AddShip(IShip ship, string position)
        {
            int y = Utils.ParseInt(position[0]) - 1;
            int x = int.Parse(position[1].ToString()) - 1;

            for (int i = 0; i < ship.Height; i++)
            {
                for (int j = 0; j < ship.Width; j++)
                {
                    strength[y + i, x + j] = ship.Strength;
                    TotalStrength += ship.Strength;
                }
            }
            this.ships.Add(ship);
        }

        public bool MissileReceived(IMissile missile)
        {
            if (this.strength[missile.X, missile.Y] > 0)
            {
                this.strength[missile.X, missile.Y] = this.strength[missile.X, missile.Y] - 1;
                this.TotalStrength -= 1;
                return true;
            }
            return false;
        }
    }
}
