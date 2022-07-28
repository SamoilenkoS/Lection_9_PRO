using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleLibrary
{
    public class DefaultRandomPCLogic : IPCLogic
    {
        private Random _random;
        private ShotResult?[,] _cells;
        private int _lastX;
        private int _lastY;

        public DefaultRandomPCLogic(int boardSize)
        {
            _cells = new ShotResult?[boardSize, boardSize];
            _random = new Random();
        }

        public Point GetNextShotCoordinates()
        {
            do
            {
                _lastX = _random.Next(0, _cells.GetLength(0));
                _lastY = _random.Next(0, _cells.GetLength(1));
            } while (_cells[_lastX, _lastY] != null);

            return new Point(_lastX, _lastY);
        }

        public void UpdateLastShotResult(ShotResult shotResult)
        {
            _cells[_lastX, _lastY] = shotResult;
        }
    }
}
