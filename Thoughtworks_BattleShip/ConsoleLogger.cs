using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_Battleship
{
    public sealed class ConsoleLogger : ILogger
    {
        private static ConsoleLogger _instace;

        private ConsoleLogger()
        {

        }
        public static ConsoleLogger Intance { get { return _instace ?? (_instace = new ConsoleLogger()); } }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
