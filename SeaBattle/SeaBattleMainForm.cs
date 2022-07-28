using SeaBattleLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class SeaBattleMainForm : Form
    {
        private Bitmap _original;
        private readonly GameEngine _gameEngine;
        private readonly int CellWidth;
        private readonly int CellHeight;

        public SeaBattleMainForm()
        {
            _gameEngine = new GameEngine(new DefaultShipRules());
            _gameEngine.SetupPCLogic(new DefaultRandomPCLogic(_gameEngine.Size));
            InitializeComponent();
            CellWidth = pictureBoxPlayerLeftZone.Width / _gameEngine.Size;
            CellHeight = pictureBoxPlayerLeftZone.Height / _gameEngine.Size;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DrawGameBoard(pictureBoxPlayerLeftZone, true);
            DrawGameBoard(pictureBoxPlayerRightZone, false);
        }

        private void DrawGameBoard(PictureBox pictureBox, bool leftBoard)
        {
            int size = _gameEngine.Size;

            int boardWidth = size * CellWidth;
            int boardHeight = size * CellHeight;
            int shift = 1;
            using (var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                DrawBoard(
                 graphics,
                 size,
                 boardWidth,
                 boardHeight,
                 shift);

                DrawShips(graphics, leftBoard, shift);
                DrawShots(graphics, leftBoard);
                DrawCellsIndexes(graphics, size);

                pictureBox.Image?.Dispose();
                pictureBox.Image = (Bitmap)bitmap.Clone();
            }
        }

        private void DrawShots(Graphics graphics, bool leftBoard)
        {
            foreach (var cell in _gameEngine.GetCells(true, x => x.IsShooted))
            {
                DrawCross(Map(cell), graphics);
            }
        }

        private System.Drawing.Point Map(SeaBattleLibrary.Point point)
        {
            return new System.Drawing.Point(point.X, point.Y);
        }

        private void DrawBoard(Graphics graphics, int size, int boardWidth, int boardHeight, int shift)
        {
            for (int i = 0; i <= size; i++)
            {
                graphics.DrawLine(
                    Pens.Red,
                    shift + i * CellWidth,
                    shift,
                    shift + i * CellWidth,
                    boardHeight);
                graphics.DrawLine(
                    Pens.Blue,
                    shift,
                    shift + i * CellHeight,
                    boardWidth,
                    shift + i * CellHeight);
            }
        }

        private void DrawCellsIndexes(Graphics graphics, int size)
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    var currentX = 1 + i * CellWidth - CellWidth / 4 * 3;
                    var currentY = 1 + j * CellHeight - CellHeight / 4 * 3;
                    graphics.DrawString($"{j - 1} {i - 1}", drawFont, drawBrush,
                        currentX, currentY);
                }
            }
        }

        private void DrawShips(
            Graphics graphics,
            bool leftBoard,
            int shift)
        {
            foreach (var pointWithShip in _gameEngine.GetCells(
                leftBoard, x => x.Ship != null))
            {
                graphics.FillRectangle(
                    Brushes.Red,
                    CellWidth * pointWithShip.X + shift,
                    CellHeight * pointWithShip.Y + shift,
                    CellWidth,
                    CellHeight);
            }
        }

        private void pictureBoxPlayerLeftZone_MouseMove(object sender, MouseEventArgs e)
        {
            var cell = GetCell(e.Location);
            textBox1.Text = $"{cell.X} {cell.Y}";
            if(_original == null)
            {
                _original = (Bitmap)pictureBoxPlayerLeftZone.Image.Clone();
            }

            DrawShotCell(pictureBoxPlayerLeftZone, cell);
        }

        private void DrawShotCell(
            PictureBox pictureBox,
            System.Drawing.Point cell)
        {
            using (var bitmap = new Bitmap(_original,
                pictureBox.Width,
                pictureBox.Height))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                DrawRectangle(cell, graphics);

                pictureBox.Image?.Dispose();
                pictureBox.Image = (Bitmap)bitmap.Clone();
            }
        }

        private void DrawRectangle(System.Drawing.Point cell, Graphics graphics)
        {
            using (var pen = new Pen(Color.Gray, 3))
            {
                graphics.DrawRectangle(
                    pen,
                    cell.Y * CellWidth,
                    cell.X * CellHeight,
                    CellWidth,
                    CellHeight);
            }
        }

        private void DrawCross(System.Drawing.Point cell, Graphics graphics)
        {
            graphics.DrawLine(
                Pens.Gray,
                cell.Y * CellWidth,
                cell.X * CellHeight,
                (cell.Y + 1) * CellWidth,
                (cell.X + 1) * CellHeight);
            graphics.DrawLine(
                Pens.Gray,
                (cell.Y + 1) * CellWidth,
                cell.X * CellHeight,
                cell.Y * CellWidth,
                (cell.X + 1) * CellHeight);
        }

        private System.Drawing.Point GetCell(System.Drawing.Point location)
        {
            return new System.Drawing.Point(location.Y / CellHeight, location.X / CellWidth);
        }

        private void pictureBoxPlayerLeftZone_MouseDown(object sender, MouseEventArgs e)
        {
            var cell = GetCell(e.Location);
            var shotResult = _gameEngine.Shoot(new SeaBattleLibrary.Point(cell.Y, cell.X), false);
            using (var bitmap = new Bitmap(_original,
                pictureBoxPlayerLeftZone.Width,
                pictureBoxPlayerLeftZone.Height))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                switch (shotResult)
                {
                    case ShotResult.Miss:
                        _original = null;
                        DrawCross(cell, graphics);
                        break;
                    case ShotResult.Damaged:
                        _original = null;
                        FillRectangle(cell, graphics);
                        break;
                    case ShotResult.Incorrect:
                        break;
                }

                pictureBoxPlayerLeftZone.Image?.Dispose();
                pictureBoxPlayerLeftZone.Image = (Bitmap)bitmap.Clone();
            }
        }

        private void FillRectangle(System.Drawing.Point cell, Graphics graphics)
        {
            graphics.FillRectangle(
                  Brushes.Black,
                  cell.Y * CellWidth,
                  cell.X * CellHeight,
                  CellWidth,
                  CellHeight);
        }
    }
}
