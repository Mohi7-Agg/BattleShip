using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_Battleship.Exceptions;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_BattleShip
{
    public class FileInputReader : IInputReader
    {
        private static FileInputReader _instace;

        private FileInputReader()
        {

        }
        public static FileInputReader Intance { get { return _instace ?? (_instace = new FileInputReader()); } }
        public string[] ReadInput(string path)
        {
            if (!File.Exists(path))
                throw new InvalidFilePathException();

            string[] input = File.ReadAllLines(path);
            return input;
        }
    }
}
