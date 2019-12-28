using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_Battleship;
using Thoughtworks_Battleship.Exceptions;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_BattleShip
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = string.Empty;

            ILogger logger = ConsoleLogger.Intance;
            IInputReader inputReader = FileInputReader.Intance;

            if (args.Length > 0)
            {
                try
                {
                    filePath = args[0];
                    string[] input = inputReader.ReadInput(filePath);
                    GameDriver driver = new GameDriver(logger);
                    driver.Start(input);
                }
                catch (InvalidFilePathException)
                {
                    logger.Log("InValid file path.");
                }
                catch (InvalidInputException ex)
                {
                    logger.Log($"Exception occured : {ex.message}");
                }
                catch (Exception ex)
                {
                    logger.Log($"Error occured , please reach out to support team. Message : { ex.Message}");
                }
            }
            else
            {
                logger.Log("Please provide file path in arguments.");
            }

            logger.Log("Press any key to Exit!");
            Console.ReadKey();
        }
    }
}
