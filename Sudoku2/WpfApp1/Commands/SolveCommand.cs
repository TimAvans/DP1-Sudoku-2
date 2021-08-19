using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.ViewModel;
using Sudoku.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Commands
{
    public class SolveCommand : ICustomCommand
    {
        private MainViewModel _mvm;

        private BaseSudoku solvedSudoku;

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

            try
            {
                Solve(null);
            }
            catch (InsufficientExecutionStackException)
            {
                Console.WriteLine("Oopsie");
            }

            _mvm.Sudoku = new SudokuVM(solvedSudoku);
        }

        private bool Solve(Cell cell)
        {
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

                        RuntimeHelpers.EnsureSufficientExecutionStack();
                        return Solve(null);
                    }
                }

                cell.Value = 0;

                RuntimeHelpers.EnsureSufficientExecutionStack();
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
