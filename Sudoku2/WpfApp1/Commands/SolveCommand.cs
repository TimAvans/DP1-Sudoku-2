using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.ViewModel;
using Sudoku.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sudoku.Commands
{
    public class SolveCommand : ICustomCommand
    {
        private MainViewModel _mvm;

        private BaseSudoku solvedSudoku;

        private int iterations = 0;

        Stack<Cell> cells = new Stack<Cell>();
        public SolveCommand(MainViewModel mvm)
        {
            this._mvm = mvm;
        }

        public void Execute()
        {
            if (_mvm.Sudoku == null)
            {
                return;
            }
            solvedSudoku = _mvm.Sudoku.getSudoku();

            iterations = 0;
            bool solved = Solve(null);

            if(iterations >= 7525 && !solved)
            {
                iterations = 0;
                Solve(null);
            }

            _mvm.Sudoku = new SudokuVM(solvedSudoku);
        }

        private bool Solve(Cell cell)
        {
            iterations++;

            if(iterations >= 7525)
            {
                return false;
            }

            if (cell == null)
            {
                cell = FindEmptyCell();
            } 

            if (cell != null)
            {
                for (int i = cell.Value; i <= cell.MaxValue; i++)
                {
                    if (IsValid(cell, i))
                    {
                        cell.Value = i;
                        cells.Push(cell);
                        return Solve(null);
                    }
                }

                cell.Value = 0;
                return Solve(cells.Pop());
            }
            //Checken of validated
            return true;
        }

        private bool IsValid(Cell checkCell, int value)
        {
            bool inMainGrid = false;

            foreach (MainGrid mainGrid in solvedSudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    if (grid.Children.Contains(checkCell))
                    {
                        inMainGrid = true;

                        foreach (Cell c in grid.Children)
                        {
                            if (c.Value == value)
                            {
                                return false;
                            }
                        }
                        break;
                    }
                }

                foreach (Grid grid in mainGrid.Children)
                {
                    if (inMainGrid)
                    {
                        foreach (Cell c in grid.Children)
                        {
                            if ((c.X == checkCell.X ^ c.Y == checkCell.Y) && c.Value == value)
                            {
                                return false;
                            }
                        }
                    }
                }

                inMainGrid = false;
            }
            return true;
        }

        private Cell FindEmptyCell()
        {
            foreach (MainGrid mainGrid in solvedSudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    foreach (Cell cell in grid.Children)
                    {
                        if (cell.Value == 0)
                        {
                            return cell;
                        }
                    }
                }
            }
            return null;
        }
    }
}
