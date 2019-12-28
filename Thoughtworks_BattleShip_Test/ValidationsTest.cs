using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thoughtworks_Battleship;

namespace Thoughtworks_BattleShip_Test
{
    [TestClass]
    public class ValidationsTest
    {
        [TestMethod]
        public void TestTotalShips()
        {
            int width = 2;
            int height = 2;
            int totalShips = 4;            
            Assert.AreEqual(true, Validations.ValidateTotalShips(totalShips, height, width));
            totalShips = 5;
            Assert.AreEqual(false, Validations.ValidateTotalShips(totalShips, height, width));
        }
        [TestMethod]
        public void TestShipLocation()
        {
            int width = 2;
            int height = 2;
            int maxWidth = 5;
            int maxHeight = 5;
            string location = "B2";
            Assert.AreEqual(true, Validations.ValidateShipLocation(width, height, location, maxWidth, maxHeight));
            location = "F2";
            Assert.AreEqual(false, Validations.ValidateShipLocation(width, height, location, maxWidth, maxHeight));
        }
        [TestMethod]
        public void TestShipType()
        {
            string type = "P";
            Assert.AreEqual(true, Validations.ValidateShipType(type));
            type = "R";
            Assert.AreEqual(false, Validations.ValidateShipType(type));
        }

        [TestMethod]
        public void TestTargets()
        {
            int maxWidth = 5;
            int maxHeight = 5;
            string target = "B1";
            Assert.AreEqual(true, Validations.ValidateTargets(target, maxWidth, maxHeight));
            target = "F1";
            Assert.AreEqual(false, Validations.ValidateTargets(target, maxWidth, maxHeight));
            target = "B6";
            Assert.AreEqual(false, Validations.ValidateTargets(target, maxWidth, maxHeight));
        }

        [TestMethod]
        public void TestRange()
        {
            int max1= 5;
            int max2 = 5;
            Assert.AreEqual(true, Validations.ValidateRange(2, 3, max1, max2));
            Assert.AreEqual(true, Validations.ValidateRange(5, 5, max1, max2));
            Assert.AreEqual(false, Validations.ValidateRange(6, 3, max1, max2));
        }
    }
}
