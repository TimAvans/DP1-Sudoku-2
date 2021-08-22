using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.State;
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

        private List<Cell> editablecells = new List<Cell>();
        private int currentCell;
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

            if (StateManager.Instance().HasSudokuChanged)
            {
                currentCell = 0;
                StateManager.Instance().HasSudokuChanged = false;
            }

            editablecells = FindEditableCells();
            try
            {
                Solve(null);
            }
            catch (InsufficientExecutionStackException)
            {
                _mvm.ValidationMessages.Clear();
                _mvm.ValidationMessages.Add("Too many tries, please try again.");
            }

            _mvm.Sudoku = new SudokuVM(solvedSudoku);
        }

        private bool Solve(Cell cell)
        {
            if (cell == null)
            {
                if (currentCell < editablecells.Count)
                {
                    cell = editablecells[currentCell];
                }
                else
                {
                    return true;
                }
            }

            for (int i = editablecells[currentCell].Value; i <= editablecells[currentCell].MaxValue; i++)
            {
                if (IsValid(editablecells[currentCell], i))
                {
                    editablecells[currentCell].Value = i;
                    currentCell++;

                    RuntimeHelpers.EnsureSufficientExecutionStack();
                    return Solve(null);
                }
            }

            cell.Value = 0;

            currentCell = --currentCell < 0 ? 0 : currentCell--;
            RuntimeHelpers.EnsureSufficientExecutionStack();
            Cell tempcell = editablecells[currentCell];
            return Solve(tempcell);
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

        private List<Cell> FindEditableCells()
        {
            List<Cell> cells = new List<Cell>();
            foreach (MainGrid mainGrid in solvedSudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    foreach (Cell cell in grid.Children)
                    {
                        if (cell.NumberState != NumberType.START)
                        {
                            cells.Add(cell);
                        }
                    }
                }
            }
            return cells;
        }
    }
}
