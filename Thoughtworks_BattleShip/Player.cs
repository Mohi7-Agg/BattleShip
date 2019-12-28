using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_Battleship
{
    public class Player : IPlayer
    {
        private IBattleField battleField;
        private Queue<IMissile> missiles;

        public Player(string name)
        {
            this.Name = name;
            this.missiles = new Queue<IMissile>();
        }

        public string Name { get; }
        public void SetBattleField(int width, int height)
        {
            this.battleField = new BattleField(width, height);
        }
        public void AddShipToFleet(IShip ship, string position)
        {
            this.battleField.AddShip(ship, position);
        }
        public void AddMissile(IMissile missile)
        {
            this.missiles.Enqueue(missile);
        }
        public IMissile GetMissile()
        {
            if (this.missiles.Count > 0)
                return this.missiles.Dequeue();
            else
                return null;
        }
        public bool MissileReceived(IMissile missile)
        {
            return this.battleField.MissileReceived(missile);
        }
        public bool HasAmmuntion()
        {
            return this.missiles.Count > 0 ? true : false;
        }
        public bool HasStrength()
        {
            return this.battleField.TotalStrength > 0 ? true : false;
        }
    }
}
