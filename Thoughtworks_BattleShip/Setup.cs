using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoughtworks_BattleShip
{
    public class Setup
    {
        public void SetupGame(string path)
        {
            try
            {
                string filePath = path;
                IInputReader inputReader = FileInputReader.Instance;
                string[] input = inputReader.ReadInput(filePath);

                GameDriver driver = new GameDriver(logger);
                driver.ValidateInputs(input);
                driver.Initialize(input);
                driver.StartGame();
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
    }
}
