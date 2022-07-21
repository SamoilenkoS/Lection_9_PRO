using System;
using static SeaBattleLibrary.GameEngine;

namespace SeaBattleLibrary
{
    public class Cell
    {
        private bool _isShooted;
        public bool IsShooted
        {
            get => _isShooted;
            set
            {
                _isShooted = value;
                if(_isShooted == true)
                {
                    CellShooted?.Invoke();
                }
            }
        }
        public Ship Ship { get; set; }
        public event PropertyValueChanged CellShooted;
    }
}
