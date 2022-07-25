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
            Board targetBoard = GetBoard(leftBoard);

            bool result = false;
            if (targetBoard.IsValidPlacement(shipPlacementDetails))
            {

                targetBoard.PlaceShip(shipPlacementDetails);
                result = true;
            }

            return result;
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
