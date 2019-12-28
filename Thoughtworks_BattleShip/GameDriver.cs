using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Thoughtworks_Battleship;
using Thoughtworks_Battleship.Exceptions;
using Thoughtworks_BattleShip.Interface;

namespace Thoughtworks_BattleShip
{
    public class GameDriver
    {
        private IPlayer player1;
        private IPlayer player2;
        private ILogger _logger;
        public string Winner { get; private set; }


        public GameDriver(ILogger logger)
        {
            this._logger = logger;
        }
        public void Initialize(string[] input)
        {
          
            player1 = new Player("Player-1");
            player2 = new Player("Player-2");

            string[] dimensionArr = input[0].Split(' ');

            int width, height, totalShips = 0;

            int.TryParse(dimensionArr[0], out width);
            height = Utils.ParseInt(dimensionArr[1][0]);

            player1.SetBattleField(width, height);
            player2.SetBattleField(width, height);
            totalShips = int.Parse(input[1]);

            for (int i = 1; i <= totalShips; i++)
            {
                string[] shipDetails = input[1 + i].Split(' ');
                Utils.ShipType type;
                Enum.TryParse(shipDetails[0], out type);

                int shipWidth = int.Parse(shipDetails[1]);
                int shipHeight = int.Parse(shipDetails[2]);
                IShip ship = new Ship(shipWidth, shipHeight, type);

                player1.AddShipToFleet(ship, shipDetails[3]);
                player2.AddShipToFleet(ship, shipDetails[4]);
            }
            string[] missileLocationsPlayer1 = input[totalShips + 2].Split(' ');
            foreach (var loc in missileLocationsPlayer1)
            {
                IMissile missile = new Missile(loc);
                player1.AddMissile(missile);
            }
            string[] missileLocationsPlayer2 = input[totalShips + 3].Split(' ');
            foreach (var loc in missileLocationsPlayer2)
            {
                IMissile missile = new Missile(loc);
                player2.AddMissile(missile);
            }

        }
        public void Start(string[] input)
        {
            ValidateInputs(input);

            Initialize(input);

            Shoot(player1, player2);
        }
        public void Shoot(IPlayer shooter, IPlayer defender)
        {
            if (!shooter.HasAmmuntion() && !defender.HasAmmuntion())
            {
                _logger.Log("Battle is draw");
                Winner = "None";
            }
            else if (!shooter.HasAmmuntion())
            {
                _logger.Log(shooter.Name + " has no more missiles left to launch");
                Shoot(defender, shooter);
            }
            else
            {
                IMissile missile = shooter.GetMissile();
                if (defender.MissileReceived(missile))
                {
                    _logger.Log($"{shooter.Name} fires a missile with target {missile.Target} which got hit");
                    if (!defender.HasStrength())
                    {
                        Winner = shooter.Name;
                        _logger.Log($"{shooter.Name} won the battle");
                    }
                    else
                    {
                        Shoot(shooter, defender);
                    }
                }
                else
                {
                    _logger.Log($"{shooter.Name} fires a missile with target {missile.Target} which got miss");
                    Shoot(defender, shooter);
                }
            }
        }
        public bool ValidateInputs(string[] input)
        {
            if (input.Length == 0)
                throw new InvalidInputException("Empty Input File.");

            string[] dimensionArr = input[0].Split(' ');

            int width, height, totalShips = 0;

            int.TryParse(dimensionArr[0], out width);
            height = Utils.ParseInt(dimensionArr[1][0]);
            if (!Validations.ValidateRange(width, height, Utils.MAX_WIDTH, Utils.MAX_HEIGHT))
                throw new InvalidInputException("Invalid Arena Dimensions");

            totalShips = int.Parse(input[1]);
            if (!Validations.ValidateTotalShips(totalShips, width, height))
                throw new InvalidInputException("Invalid Total Ship Count");

            for (int i = 1; i <= totalShips; i++)
            {
                string[] shipDetails = input[1 + i].Split(' ');
                if (!Validations.ValidateShipType(shipDetails[0]))
                    throw new InvalidInputException("Invalid Ship Type");

                int shipWidth = int.Parse(shipDetails[1]);
                int shipHeight = int.Parse(shipDetails[2]);
                if (!Validations.ValidateRange(shipWidth, shipHeight, width, height))
                    throw new InvalidInputException("Invalid Ship Dimensions");

                if (!Validations.ValidateShipLocation(shipWidth, shipHeight, shipDetails[3], width, height)
                    || !Validations.ValidateShipLocation(shipWidth, shipHeight, shipDetails[4], width, height))
                    throw new InvalidInputException("Invalid Ship Location, Index Out of Range");
            }
            if (!Validations.ValidateTargets(input[totalShips + 2], width, height)
                || !Validations.ValidateTargets(input[totalShips + 3], width, height))
                throw new InvalidInputException("Invalid Missile Targets");

            return true;
        }
    }
}
