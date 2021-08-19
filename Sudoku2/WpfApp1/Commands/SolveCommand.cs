using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.ViewModel;
using Sudoku.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Commands
{
    public class SolveCommand : ICustomCommand
    {
        private MainViewModel _mvm;

        private BaseSudoku solvedSudoku;

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
            Solve();

            _mvm.Sudoku = new SudokuVM(solvedSudoku);
        }

        private bool Solve()
        {
            Cell cell = FindEmptyCell();
            if (cell != null)
            {
                for (int i = 1; i <= cell.MaxValue; i++)
                {
                    if (IsValid(cell, i))
                    {
                        cell.Value = i;
                        if (Solve())
                        {
                            Console.WriteLine("SOLVED : " + i);
                            return true;
                        }
                    }
                }
                return false;
            }
            //Checken of validated
            return false;
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
                            if (checkCell.X == 5 && checkCell.Y == 0)
                            {
                                Console.WriteLine("fkldajfla");
                            }

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
