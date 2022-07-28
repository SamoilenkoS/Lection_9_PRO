using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleLibrary
{
    public interface IPCLogic
    {
        Point GetNextShotCoordinates();
        void UpdateLastShotResult(ShotResult shotResult);
    }
}
