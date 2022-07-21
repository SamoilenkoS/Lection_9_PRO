using System;
using static SeaBattleLibrary.GameEngine;

namespace SeaBattleLibrary
{
    public class Ship
    {
        public int Size
        {
            get => ShipCells.Length;
        }

        public bool IsAlive
        {
            get//ShipCells.Any(x => !x.IsShooted)
            {
                for (int i = 0; i < ShipCells.Length; i++)
                {
                    if (!ShipCells[i].IsShooted)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public Cell[] ShipCells { get; }

        public event PropertyValueChanged ShipDied;

        public Ship(Cell[] cells)
        {
            if(cells == null || cells.Length == 0)
            {
                throw new ArgumentException();
            }

            ShipCells = cells;
            foreach (var cell in cells)
            {
                cell.CellShooted += CheckShipIsAlive;
            }
        }

        private void CheckShipIsAlive()
        {
            if (!IsAlive)
            {
                ShipDied?.Invoke();
            }
        }
    }
}