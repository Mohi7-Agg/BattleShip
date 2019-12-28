using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_Battleship;
using Thoughtworks_BattleShip;
using Thoughtworks_BattleShip.Interface;
using Thoughtworks_Battleship.Exceptions;

namespace Thoughtworks_BattleShip_Test
{
    [TestClass]
    public class GameDriverTest
    {
        IInputReader inputReader;
        ILogger logger;

        [TestInitialize]
        public void setup()
        {
            logger = ConsoleLogger.Intance;
            inputReader = FileInputReader.Intance;
        }

        [ExpectedException(typeof(InvalidFilePathException))]
        [TestMethod]
        public void TestInputFile()
        {
            var file = "dummy.txt";
            inputReader.ReadInput(file);
        }

        [ExpectedException(typeof(InvalidInputException))]
        [TestMethod]
        public void TestInvalidInputException()
        {
            var file = "InvalidInput.txt";
            string[] inputs = inputReader.ReadInput(file);
            GameDriver gameDriver = new GameDriver(logger);
            gameDriver.ValidateInputs(inputs);
        }

        [TestMethod]
        public void TestInvalidInputExceptionMsg()
        {
            try
            {
                var file = "InvalidInput.txt";
                string[] inputs = inputReader.ReadInput(file);
                GameDriver gameDriver = new GameDriver(logger);
                gameDriver.ValidateInputs(inputs);
            }
            catch (InvalidInputException ex)
            {
                Assert.AreEqual("Invalid Arena Dimensions", ex.message);
            }           
        }

        [TestMethod]      
        public void TestGamePlayer2()
        {
            var file = "Input1.txt";
            string[] input = inputReader.ReadInput(file);
            GameDriver gameDriver = new GameDriver(logger);
            gameDriver.Start(input);
            string winner = "Player-2";
            Assert.AreEqual(winner, gameDriver.Winner);
           
        }

        [TestMethod]
        public void TestGamePlayer1()
        {
            var file = "Input2.txt";
            string[] input = inputReader.ReadInput(file);
            GameDriver gameDriver = new GameDriver(logger);
            gameDriver.Start(input);
            string winner = "Player-1";
            Assert.AreEqual(winner, gameDriver.Winner);

        }
        [TestMethod]
        public void TestGameDraw()
        {
            var file = "Input3.txt";
            string[] input = inputReader.ReadInput(file);
            GameDriver gameDriver = new GameDriver(logger);
            gameDriver.Start(input);
            string winner = "None";
            Assert.AreEqual(winner, gameDriver.Winner);

        }

    }
}
