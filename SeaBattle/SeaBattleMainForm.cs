using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class SeaBattleMainForm : Form
    {
        public SeaBattleMainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            DrawGameBoard();
        }

        private void DrawGameBoard()
        {
            var graphics = pictureBoxPlayerLeftZone.CreateGraphics();
            graphics.Clear(Color.White);
            int size = 10;
            int cellWidth = pictureBoxPlayerLeftZone.Width / size;
            int cellHeight = pictureBoxPlayerLeftZone.Height / size;
            int boardWidth = size * cellWidth;
            int boardHeight = size * cellHeight;
            int shift = 1;
            DrawBoard(
                graphics,
                size,
                cellWidth,
                cellHeight,
                boardWidth,
                boardHeight,
                shift);

            DrawCellsIndexes(graphics, size, cellWidth, cellHeight);
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
    }
}
