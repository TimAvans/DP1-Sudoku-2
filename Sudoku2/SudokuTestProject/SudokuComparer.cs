using Sudoku.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTestProject
{
    public class SudokuComparer : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {

            MainGrid mainGridX = (MainGrid)x;
            MainGrid mainGridY = (MainGrid)y;
            for (int g = 0; g < mainGridX.Children.Count; g++)
            {
                Grid gridX = (Grid)mainGridX.Children[g];
                Grid gridY = (Grid)mainGridY.Children[g];
                for (int c = 0; c < gridX.Children.Count; c++)
                {
                    Cell cellX = (Cell)gridX.Children[c];
                    Cell cellY = (Cell)gridY.Children[c];

                    if (cellX.Value != cellY.Value || cellX.X != cellY.X || cellX.Y != cellY.Y)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
