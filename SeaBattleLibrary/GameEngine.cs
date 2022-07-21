using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleLibrary
{
    public class GameEngine
    {
        private Board _leftBoard;
        private Board _rightBoard;
        public bool LeftPlayerTurn { get; private set; }
        public delegate void PropertyValueChanged();

        public GameEngine()
        {
            _leftBoard = new Board();
            _rightBoard = new Board();
            LeftPlayerTurn = true;
        }

        public bool PlaceShip(bool leftBoard,
            ShipPlacementDetails shipPlacementDetails)
        {
            Board target = GetBoard(leftBoard);

            bool result = false;
            if (target.IsValidPlacement(shipPlacementDetails))
            {
                Ship ship = GenerateShip(shipPlacementDetails);
                target.PlaceShip(ship);
                result = true;
            }

            return result;
        }

        private Ship GenerateShip(ShipPlacementDetails shipPlacementDetails)
        {//TODO implement
            throw new NotImplementedException();
        }

        private Board GetBoard(bool leftBoard)
            => leftBoard ? _leftBoard : _rightBoard;

        public ShotResult Shoot(Point shotCell)
        {
            Board target = GetBoard(LeftPlayerTurn);
            ShotResult shotResult = target.Shoot(shotCell);

            if(shotResult == ShotResult.Miss)
            {
                LeftPlayerTurn = !LeftPlayerTurn;
            }

            return shotResult;
        }
    }
}
