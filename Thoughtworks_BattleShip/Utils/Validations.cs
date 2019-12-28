using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_Battleship
{
    public static class Validations
    {
        public static bool ValidateTotalShips(int totalCount, int maxWidth, int maxHeight)
        {
            if (totalCount > maxHeight * maxWidth || totalCount < 1)
            {
                return false;
            }                
            return true;
        }

        public static bool ValidateShipType(string type)
        {
            Utils.ShipType result;
            if(!Enum.TryParse(type, out result))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateShipLocation(int width, int height, string location, int maxWidth, int maxHeight)
        {
            int y = Utils.ParseInt(location[0]) + height  - 1;
            int x = int.Parse(location[1].ToString()) + width - 1;

            return ValidateRange(x, y, maxWidth, maxHeight);
        }

        public static bool ValidateTargets(string targets, int maxWidth, int maxHeight)
        {
            string[] targetArr = targets.Split(' ');
            foreach(var location in targetArr)
            {
                int height = Utils.ParseInt(location[0]);
                int width = int.Parse(location[1].ToString());
                if (!ValidateRange(width, height, maxWidth, maxHeight))
                    return false;
            }
            return true;
        }

        public static bool ValidateRange(int value1, int value2, int maxValue1, int maxValue2, int minValue1 = 1, int minValue2 = 1)
        {
            if (value1 > maxValue1 || value1 < minValue1 ||value2 > maxValue2 || value2 < minValue2)
                return false;
            return true;
        }
    }
}
