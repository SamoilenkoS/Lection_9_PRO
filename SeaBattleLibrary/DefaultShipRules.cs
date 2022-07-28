using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleLibrary
{
    public class DefaultShipRules : IShipsRules
    {
        public List<(int shipSize, int count)> GetShips()
        {
            return new List<(int shipSize, int count)>
            {
                (4, 1),
                (3, 2),
                (2, 3),
                (1, 4)
            };
        }
    }
}
