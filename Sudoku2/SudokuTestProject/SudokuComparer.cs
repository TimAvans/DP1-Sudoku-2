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

            MainGrid sudoku = (MainGrid)x;
            MainGrid testsudoku = (MainGrid)y;
            for (int g = 0; g < sudoku.Children.Count; g++)
            {
                Grid gridSudoku = (Grid)sudoku.Children[g];
                Grid gridTestsudoku = (Grid)testsudoku.Children[g];
                for (int c = 0; c < gridSudoku.Children.Count; c++)
                {
                    Cell cellSudoku = (Cell)gridSudoku.Children[c];
                    Cell cellTestsudoku = (Cell)gridTestsudoku.Children[c];

                    if (cellSudoku.Value != cellTestsudoku.Value || cellSudoku.X != cellTestsudoku.X || cellSudoku.Y != cellTestsudoku.Y)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}
