using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_BattleShip.Interface
{
    interface IBattleField
    {
        int[,] strength { get; }

        int TotalStrength { get; }

        void AddShip(IShip ship, string position);

        bool MissileReceived(IMissile missile);

    }
}
