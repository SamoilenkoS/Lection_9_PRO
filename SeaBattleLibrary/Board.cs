using System;
using System.Linq;

namespace SeaBattleLibrary
{
    public class Board
    {
        private const int DefaultSize = 10;
        public int Size { get; }
        public Cell[,] Cells { get; private set; }

        public Board(int size = DefaultSize)
        {
            Size = size;
            InitializeCells();
        }

        private void InitializeCells()
        {
            Cells = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }

        internal bool IsValidPlacement(ShipPlacementDetails shipPlacementDetails)
        {
            int xShift = shipPlacementDetails.IsHorizontal ? 1 : 0;
            int yShift = shipPlacementDetails.IsHorizontal ? 0 : 1;
            xShift *= shipPlacementDetails.Size;
            yShift *= shipPlacementDetails.Size;
            if((xShift + shipPlacementDetails.PlacementCoordinate.X) >= Size ||
                (yShift + shipPlacementDetails.PlacementCoordinate.Y) >= Size)
            {
                return false;
            }

            var cells = Cells.GetShipAndNearestCells(shipPlacementDetails);

            return cells.All(x => x.Ship == null);
        }

        internal void PlaceShip(
            ShipPlacementDetails shipPlacementDetails)
        {
            var shipCells = Cells.GetShipCells(shipPlacementDetails);
            var ship = new Ship(shipCells);
            foreach (var item in shipCells)
            {
                item.Ship = ship;
            }
            //shipCells.Select(x => x.Ship = ship);
        }

        internal ShotResult Shoot(Point shotCell)
        {
            if(
                shotCell.X >= Size ||
                shotCell.Y >= Size)
            {
                throw new ArgumentException();
            }

            var targetCell = Cells[shotCell.X, shotCell.Y];
            if (targetCell.IsShooted)
            {
                return ShotResult.Incorrect;
            }

            targetCell.IsShooted = true;
            return targetCell.Ship != null
                ? ShotResult.Damaged
                : ShotResult.Miss;
        }
    }
}
