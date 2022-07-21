using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal bool IsValidPlacement(//TODO add neighbours validation
            ShipPlacementDetails shipPlacementDetails)
        {
            int xShift = shipPlacementDetails.IsHorizontal ? 1 : 0;
            int yShift = shipPlacementDetails.IsHorizontal ? 0 : 1;
            bool result = true;
            for (int i = 0; i < shipPlacementDetails.Size; i++)
            {
                if (Cells[shipPlacementDetails.PlacementCoordinate.X + xShift * i,
                    shipPlacementDetails.PlacementCoordinate.Y + yShift * i].Ship
                    != null)
                {
                    result = false;
                    break;
                }
            }

            return result;

        }

        internal void PlaceShip(Ship ship)//TODO implement
        {
            throw new NotImplementedException();
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
