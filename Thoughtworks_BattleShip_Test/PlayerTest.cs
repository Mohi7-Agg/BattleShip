using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_Battleship;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_BattleShip_Test
{
    [TestClass]
    public class PlayerTest
    {

        Player player;
        [TestInitialize]
        public void setup()
        {
            player = new Player("Player-Test");
            player.SetBattleField(5, 5);
        }

        [TestMethod]
        public void TestPlayerName()
        {
            string expected = "Player-Test";
            Assert.AreEqual(expected, player.Name);
        }
        [TestMethod]
        public void TestHasAmmunition()
        {
            Assert.AreEqual(false, player.HasAmmuntion());
            IMissile missile = new Missile("A1");
            player.AddMissile(missile);
            Assert.AreEqual(true, player.HasAmmuntion());
        }
        [TestMethod]
        public void TestHasStrength()
        {
            Assert.AreEqual(false, player.HasStrength());
            Ship ship = new Ship(2, 2, Utils.ShipType.P);
            player.AddShipToFleet(ship, "A1");
            Assert.AreEqual(true, player.HasStrength());
        }

        [TestMethod]
        public void TestGetMisile()
        {
            Assert.AreEqual(null, player.GetMissile());
            IMissile missile = new Missile("A1");
            player.AddMissile(missile);
            Assert.AreEqual(missile, player.GetMissile());
        }
    }
}
