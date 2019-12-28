using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_Battleship.Exceptions
{
    public class InvalidInputException : Exception
    {
        public string message { get; set; }
        public InvalidInputException(string message)
        {
            this.message = message;
        }
    }
}
