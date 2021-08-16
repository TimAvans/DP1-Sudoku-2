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
    public enum SolveState
    {
        TRUE,
        FALSE,
        TBD
    }

    public class SolveCommand : ICustomCommand
    {
        private MainViewModel _mvm;

        private SolveState _state;
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

            _state = SolveState.TBD;
            _mvm.ValidationMessages.Clear();
            _mvm.ValidationMessages.Add("Trying to solve sudoku.");

            Cell emptyCell = FindEmptyCell();

            if (emptyCell == null)
            {
                ValidationVisitor v = new ValidationVisitor();
                _mvm.Sudoku.getSudoku().Accept(v);

                _state = _mvm.Sudoku.getSudoku().IsValidated ? SolveState.FALSE : SolveState.TRUE;

                if (_state == SolveState.FALSE)
                {
                    _mvm.ValidationMessages.Add("Could not solve Sudoku.");
                    _mvm.ValidationMessages.Add("Cuz u fucked up.");
                }
                else
                {
                    _mvm.ValidationMessages.Add("Solved Sudoku");
                }
                return;
            }

            for (int i = 1; i <= emptyCell.MaxValue; i++)
            {
                if (IsValid(emptyCell, i))
                {
                    emptyCell.Value = i;
                    Execute();
                    if (_state == SolveState.FALSE)
                    {
                        emptyCell.Value = 0;
                    }
                }
            }
        }

        private bool IsValid(Cell checkCell, int value)
        {
            bool inMainGrid = false;
            foreach (MainGrid mainGrid in _mvm.Sudoku.getSudoku().Children)
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
                    }
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
            foreach (MainGrid mainGrid in _mvm.Sudoku.getSudoku().Children)
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
