using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class SeaBattleMainForm : Form
    {
        public SeaBattleMainForm()
        {
            InitializeComponent();
            pictureBoxPlayerLeftZone.Invalidate();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DrawGameBoard();
        }

        private void DrawGameBoard()
        {
            int size = 10;
            int cellWidth = pictureBoxPlayerLeftZone.Width / size;
            int cellHeight = pictureBoxPlayerLeftZone.Height / size;
            int boardWidth = size * cellWidth;
            int boardHeight = size * cellHeight;
            int shift = 1;
            using (var bitmap = new Bitmap(pictureBoxPlayerLeftZone.Width, pictureBoxPlayerLeftZone.Height))
            using (var graphics = Graphics.FromImage(bitmap))
            using (var pen = new Pen(Color.White))
            {

                DrawBoard(
                 graphics,
                 size,
                 cellWidth,
                 cellHeight,
                 boardWidth,
                 boardHeight,
                 shift);

                DrawCellsIndexes(graphics, size, cellWidth, cellHeight);
                // copy the bitmap to the picturebox (double buffered)
                pictureBoxPlayerLeftZone.Image?.Dispose();
                pictureBoxPlayerLeftZone.Image = (Bitmap)bitmap.Clone();
            }
        }

        private static void DrawBoard(Graphics graphics, int size, int cellWidth, int cellHeight, int boardWidth, int boardHeight, int shift)
        {
            for (int i = 0; i <= size; i++)
            {
                graphics.DrawLine(
                    Pens.Red,
                    shift + i * cellWidth,
                    shift,
                    shift + i * cellWidth,
                    boardHeight);
                graphics.DrawLine(
                    Pens.Blue,
                    shift,
                    shift + i * cellHeight,
                    boardWidth,
                    shift + i * cellHeight);
            }
        }

        private static void DrawCellsIndexes(Graphics graphics, int size, int cellWidth, int cellHeight)
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    var currentX = 1 + i * cellWidth - cellWidth / 4 * 3;
                    var currentY = 1 + j * cellHeight - cellHeight / 4 * 3;
                    graphics.DrawString($"{j - 1} {i - 1}", drawFont, drawBrush,
                        currentX, currentY);
                }
            }
        }

        private void SeaBattleMainForm_Paint(object sender, PaintEventArgs e)
        {
            buttonStart_Click(sender, e);
        }

        private void pictureBoxPlayerLeftZone_Paint(object sender, PaintEventArgs e)
        {
            DrawGameBoard();
        }
    }
}
