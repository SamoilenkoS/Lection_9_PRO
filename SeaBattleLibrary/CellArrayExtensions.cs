using System.Collections.Generic;

namespace SeaBattleLibrary
{
    public static class CellArrayExtensions
    {
        public static Cell[] GetShipCells
            (this Cell[,] source, ShipPlacementDetails shipPlacementDetails)
        {
            int xShift = shipPlacementDetails.IsHorizontal ? 1 : 0;
            int yShift = shipPlacementDetails.IsHorizontal ? 0 : 1;
            Cell[] result = new Cell[shipPlacementDetails.Size];
            for (int i = 0; i < shipPlacementDetails.Size; i++)
            {
                result[i] = source[shipPlacementDetails.PlacementCoordinate.X + xShift * i,
                      shipPlacementDetails.PlacementCoordinate.Y + yShift * i];
            }

            return result;
        }

        public static IEnumerable<Cell> GetShipAndNearestCells(
            this Cell[,] source,
            ShipPlacementDetails shipPlacementDetails)
        {
            int xShift = shipPlacementDetails.IsHorizontal ? 1 : 0;
            int yShift = shipPlacementDetails.IsHorizontal ? 0 : 1;
            List<Cell> result = new List<Cell>((shipPlacementDetails.Size + 2) * 3);
            for (int i = shipPlacementDetails.PlacementCoordinate.X - 1; i <=
                shipPlacementDetails.PlacementCoordinate.X + 1
                    + shipPlacementDetails.Size * xShift; i++)
            {
                for (int j = shipPlacementDetails.PlacementCoordinate.Y - 1; j <=
                    shipPlacementDetails.PlacementCoordinate.Y + 1
                    + shipPlacementDetails.Size * yShift; j++)
                {
                    if (i >= 0 &&
                        i < source.GetLength(0)&&
                        j >= 0 &&
                        j < source.GetLength(1))
                    {
                        result.Add(source[i, j]);
                    }
                }
            }

            return result;
        }
    }
}
