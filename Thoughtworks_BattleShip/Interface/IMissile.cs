using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_BattleShip.Interface
{
    public interface IMissile
    {
        string Target { get; }
        int X { get; }
        int Y { get; }
    }
}
