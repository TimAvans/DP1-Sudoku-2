using Sudoku.Models;
using Sudoku.Models.Sudokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Visitor
{
    public class ValidationVisitor : IVisitor
    {
        public void visitCell(Cell cell)
        {
            if (cell.Value <= 9 && cell.Value >= 1)
            {
                cell.IsValidated = true;
            }
            else 
            {
                cell.IsValidated = false;
            }
            Console.WriteLine("Cell validation: " + cell.IsValidated.ToString());
        }

        public void visitGrid(Grid grid)
        {
            grid.IsValidated = true;
            List<int> integers = new List<int>();

            foreach (Cell cell in grid.Children)
            {
                if (cell.IsValidated)
                {
                    if (!integers.Contains(cell.Value))
                    {
                        integers.Add(cell.Value);
                    }
                    else
                    {
                        grid.IsValidated = false;
                        cell.IsValidated = false;
                    }
                }
                else 
                {
                    grid.IsValidated = false;
                }
            }
            Console.WriteLine("Grid validation: " + grid.IsValidated.ToString());
        }

        public void visitMainGrid(MainGrid maingrid)
        {
            maingrid.IsValidated = true;
            foreach (Grid grid in maingrid.Children)
            {
                Dictionary<int, List<int>> integersX = new Dictionary<int, List<int>>();
                Dictionary<int, List<int>> integersY = new Dictionary<int, List<int>>();
                if (grid.IsValidated)
                {
                    foreach (Cell cell in grid.Children)
                    {
                        if (!integersX.ContainsKey(cell.X))
                        {
                            integersX.Add(cell.X, new List<int>());
                        }
                        if (!integersY.ContainsKey(cell.Y))
                        {
                            integersY.Add(cell.Y, new List<int>());
                        }

                        if (!integersX[cell.X].Contains(cell.Value))
                        {
                            integersX[cell.X].Add(cell.Value);
                        }
                        else
                        {
                            cell.IsValidated = false;
                            grid.IsValidated = false;
                            maingrid.IsValidated = false;
                        }

                        if (!integersY[cell.Y].Contains(cell.Value))
                        {
                            integersY[cell.Y].Add(cell.Value);
                        }
                        else
                        {
                            cell.IsValidated = false;
                            grid.IsValidated = false;
                            maingrid.IsValidated = false;
                        }
                    }
                }
                else
                {
                    maingrid.IsValidated = false;
                }
            }
            Console.WriteLine("MainGrid validation: " + maingrid.IsValidated.ToString());
        }

        public void visitSudoku(BaseSudoku sudoku)
        {
            sudoku.IsValidated = true;
            foreach (MainGrid maingrid in sudoku.Children)
            {
                if (!maingrid.IsValidated)
                {
                    sudoku.IsValidated = false;
                }
            }
            Console.WriteLine("Sudoku validation: " + sudoku.IsValidated.ToString());
        }
    }
}
