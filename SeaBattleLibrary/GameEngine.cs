using System;
using System.Collections.Generic;

namespace SeaBattleLibrary
{
    public class GameEngine
    {
        private IPCLogic _pCLogic;
        private static readonly Random _random;
        private readonly List<(int shipSize, int count)> _shipRules;
        private Board _leftBoard;
        private Board _rightBoard;
        private bool _isWithPC;
        public bool LeftPlayerTurn { get; private set; }
        public delegate void PropertyValueChanged();

        public int Size => _leftBoard.Size;

        static GameEngine()
        {
            _random = new Random();
        }

        public GameEngine(
            IShipsRules shipsRules,
            bool leftAutofill = true,
            bool rightAutofill = true,
            bool isWithPC = true)
        {
            _shipRules = shipsRules.GetShips();
            _leftBoard = new Board();
            _rightBoard = new Board();
            _isWithPC = isWithPC;
            LeftPlayerTurn = false;
            if (leftAutofill)
            {
                AutofillBoard(_leftBoard);
            }
            if (rightAutofill)
            {
                AutofillBoard(_rightBoard);
            }
        }

        public void SetupPCLogic(IPCLogic pCLogic)
        {
            _pCLogic = pCLogic;
        }

        public bool TryPlaceShip(Board targetBoard,
            ShipPlacementDetails shipPlacementDetails)
        {
            bool result = false;
            if (targetBoard.IsValidPlacement(shipPlacementDetails))
            {
                targetBoard.PlaceShip(shipPlacementDetails);
                result = true;
            }

            return result;
        }

        public IEnumerable<Point> GetCells(bool leftBoard, Func<Cell, bool> filter)
        {
            Board board = GetBoard(leftBoard);
            for (int i = 0; i < board.Size; ++i)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (filter.Invoke(board.Cells[i, j]))
                    {
                        yield return new Point(i, j);
                    }
                }
            }
        }

        private void AutofillBoard(Board board)
        {
            foreach (var item in _shipRules)
            {
                for (int i = 0; i < item.count; i++)
                {
                    bool currentResult;
                    do
                    {
                        currentResult = TryPlaceShip(board, new ShipPlacementDetails
                        {
                            IsHorizontal = _random.NextDouble() >= 0.5,
                            PlacementCoordinate = new Point(
                                _random.Next(0, board.Size),
                                _random.Next(0, board.Size)),
                            Size = item.shipSize
                        });
                    }
                    while (!currentResult);
                }
            }
        }

        private Board GetBoard(bool leftBoard)
            => leftBoard ? _leftBoard : _rightBoard;

        public ShotResult Shoot(Point shotCell, bool leftPlayer)
        {
            var playerShot = PlayerShot(shotCell, leftPlayer);
            if(playerShot == ShotResult.Miss)
            {
                if (_isWithPC && LeftPlayerTurn)
                {
                    PCShot();
                }
            }

            return playerShot;
        }

        private void PCShot()
        {
            var nextCords = _pCLogic.GetNextShotCoordinates();
            ShotResult shotResult;
            do
            {
                shotResult = PlayerShot(nextCords, LeftPlayerTurn);
                _pCLogic.UpdateLastShotResult(shotResult);
            } while (shotResult != ShotResult.Miss);
        }

        private ShotResult PlayerShot(Point shotCell, bool leftPlayer)
        {
            if (LeftPlayerTurn != leftPlayer)
            {
                return ShotResult.Incorrect;
            }

            Board target = GetBoard(LeftPlayerTurn);
            ShotResult shotResult = target.Shoot(shotCell);

            if (shotResult == ShotResult.Miss)
            {
                LeftPlayerTurn = !LeftPlayerTurn;
            }

            return shotResult;
        }
    }
}
