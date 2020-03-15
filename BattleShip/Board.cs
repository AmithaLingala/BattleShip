using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip
{

    public class Board
    {
        private int gridSize;
        private int gridCount;
        private Canvas Area;
        private double boardSize;
        public Board(Canvas Area)
        {
            this.Area = Area;
            this.gridCount = 10;
            double size = Area.ActualWidth > Area.ActualHeight ? Area.ActualHeight : Area.ActualWidth;
            boardSize = size;
            gridSize = ((int)boardSize / 10) - 5;
            GenerateBoard();

        }
        
        public void GenerateBoard()
        {
            
            var yoffset = gridCount * 5;
            var xoffset = ((Area.ActualWidth - boardSize) / 2) + yoffset ;
            
            for (int x = 0; x < gridCount; x++)
            {
                Rectangle Cell = new Rectangle();
                Cell.Fill = new SolidColorBrush(Colors.Gray);
                Cell.Stroke = new SolidColorBrush(Colors.White);
                Cell.Width = gridSize;
                Cell.Height = yoffset;
                Canvas.SetLeft(Cell, xoffset + (x * gridSize));
                TextBlock text = new TextBlock();
                text.Text = (x + 1).ToString();
                text.FontSize = 20;
                text.FontWeight = FontWeights.Bold;
                Canvas.SetLeft(text, xoffset + (x * gridSize) + yoffset * 0.7);
                Canvas.SetTop(text, yoffset * 0.3);
                Area.Children.Add(Cell);
                Area.Children.Add(text);
            }
            for (int y = 0; y < gridCount; y++)
            {
                Rectangle Cell = new Rectangle();
                Cell.Fill = new SolidColorBrush(Colors.Gray);
                Cell.Stroke = new SolidColorBrush(Colors.White);
                Cell.Width = yoffset;
                Cell.Height = gridSize;
                Canvas.SetLeft(Cell, xoffset - yoffset);
                Canvas.SetTop(Cell, yoffset + (y * gridSize));
                Area.Children.Add(Cell);
            }
            for (int x = 0; x < gridCount; x++)
            {
                for (int y = 0; y < gridCount; y++)
                {
                    Rectangle Cell = new Rectangle();
                    Cell.Fill = new SolidColorBrush(Colors.Navy);
                    Cell.Stroke = new SolidColorBrush(Colors.White);
                    Cell.Width = gridSize;
                    Cell.Height = gridSize;
                    Canvas.SetLeft(Cell, xoffset + (x * gridSize));
                    Canvas.SetTop(Cell, yoffset + (y * gridSize));
                    Area.Children.Add(Cell);
                }
            }


        }
    }
}
