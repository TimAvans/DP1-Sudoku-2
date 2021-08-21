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
        
        private bool inMainGrid = false;

        private BaseSudoku solvedSudoku;

        Stack<Cell> cells = new Stack<Cell>();
        Stack<Cell> emptycells = new Stack<Cell>();

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
            emptycells = FindEmptyCells();
            try
            {
                Solve(null);
            }
            catch (InsufficientExecutionStackException)
            {
                Console.WriteLine("Too many tries please try again. ");
            }

            _mvm.Sudoku = new SudokuVM(solvedSudoku);
        }

        //private bool solver() 
        //{
        //    //zoek een empty cell.
        //    //wnr er geen gevonden wordt return true want dan is het t einde
        //    //Wel eentje gevonden kijk of deze cel valid is met alle waardes van 1 tm max value
        //    //Kan er geen valid gemaakt worden dan ga 1 cel terug en probeer andere waardes.
        //}

        private bool Solve(Cell cell)
        {
            if (cell == null)
            {
                if (emptycells.Count > 0)
                {
                    cell = emptycells.Pop();
                }
                else
                {
                    return true;
                }
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
                Cell tempcell = cells.Pop();
                return Solve(tempcell);
            }
            return true;
        }

        private bool IsValid(Cell checkCell, int value)
        {

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

        private Stack<Cell> FindEmptyCells()
        {
            Stack<Cell> cells = new Stack<Cell>();
            foreach (MainGrid mainGrid in solvedSudoku.Children)
            {
                foreach (Grid grid in mainGrid.Children)
                {
                    foreach (Cell cell in grid.Children)
                    {
                        if (cell.Value == 0)
                        {
                            cells.Push(cell);
                        }
                    }
                }
            }
            return cells;
        }
    }
}
