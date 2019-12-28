using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_BattleShip.Interface
{
    public interface IPlayer
    {
        string Name { get; }

        void SetBattleField(int width, int height);

        void AddShipToFleet(IShip ship, string position);

        void AddMissile(IMissile missile);
        IMissile GetMissile();
        bool MissileReceived(IMissile missile);
        bool HasStrength();

        bool HasAmmuntion();
    }
}
