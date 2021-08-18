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

        private BaseSudoku solvedSudoku;

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
            solvedSudoku = _mvm.Sudoku.getSudoku();
            Solve();
            //_state = SolveState.TBD;
            //_mvm.ValidationMessages.Clear();
            //_mvm.ValidationMessages.Add("Trying to solve sudoku.");

            //Cell emptyCell = FindEmptyCell();

            //if (emptyCell == null)
            //{
            //    ValidationVisitor v = new ValidationVisitor();
            //    solvedSudoku.Accept(v);

            //    _state = solvedSudoku.IsValidated ? SolveState.TRUE : SolveState.FALSE;
               
            //    if (_state == SolveState.FALSE)
            //    {
            //        _mvm.ValidationMessages.Add("Could not solve Sudoku.");
            //    }
            //    else
            //    {
            //        _mvm.ValidationMessages.Add("Solved Sudoku");
            //        _mvm.Sudoku = new SudokuVM(solvedSudoku);
            //    }
            //    return;
            //}

            //for (int i = 1; i <= emptyCell.MaxValue; i++)
            //{
            //    if (IsValid(emptyCell, i))
            //    {
            //        emptyCell.Value = i;
            //        Execute();
            //        if (_state == SolveState.FALSE)
            //        {
            //            emptyCell.Value = 0;
            //        }
            //    }
            //}
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
                    }
                    if (inMainGrid)
                    {
                        foreach (Cell c in grid.Children)
                        {
                            if (c.X == checkCell.X)
                            {
                                if (c.Value == value)
                                {
                                    return false;
                                }
                            }
                            if (c.Y == checkCell.Y)
                            {
                                if (c.Value == value)
                                {
                                    return false;
                                }
                            }
                            //if((c.X == checkCell.X ^ c.Y == checkCell.Y) && c.Value == value)
                            //{
                            //    return false;
                            //}
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
