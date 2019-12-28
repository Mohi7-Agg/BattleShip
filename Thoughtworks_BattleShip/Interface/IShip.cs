using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_BattleShip.Interface
{
    public interface IShip
    {
        int Width { get; }
        int Height { get; }
        int Strength { get; }
    }
}
