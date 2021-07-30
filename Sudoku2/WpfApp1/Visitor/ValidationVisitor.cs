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
                cell.isValidated = true;
            }
            else 
            {
                cell.isValidated = false;
            }
            Console.WriteLine("Cell validation: " + cell.isValidated.ToString());
        }

        public void visitGrid(Grid grid)
        {
            List<int> integers = new List<int>();

            foreach (var cell in grid.Parts)
            {
                if (cell.isValidated)
                {
                    if (!integers.Contains(cell.Value))
                    {
                        integers.Add(cell.Value);
                    }
                    else
                    {
                        grid.isValidated = false;
                        cell.isValidated = false;
                        return;
                    }
                }
                else 
                {
                    grid.isValidated = false;
                    return;
                }
            }
            grid.isValidated = true;
            Console.WriteLine("Grid validation: " + grid.isValidated.ToString());
        }

        public void visitMainGrid(MainGrid maingrid)
        {
            foreach (var grid in maingrid.Parts)
            {
                Dictionary<int, List<int>> integersX = new Dictionary<int, List<int>>();
                Dictionary<int, List<int>> integersY = new Dictionary<int, List<int>>();
                if (grid.isValidated)
                {
                    foreach (var cell in grid.Parts)
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
                            cell.isValidated = false;
                            grid.isValidated = false;
                            maingrid.isValidated = false;
                            return;
                        }

                        if (!integersY[cell.Y].Contains(cell.Value))
                        {
                            integersY[cell.Y].Add(cell.Value);
                        }
                        else
                        {
                            cell.isValidated = false;
                            grid.isValidated = false;
                            maingrid.isValidated = false;
                            return;
                        }
                    }
                }
                else
                {
                    maingrid.isValidated = false;
                    return; 
                }          
            }
            maingrid.isValidated = true;
            Console.WriteLine("MainGrid validation: " + maingrid.isValidated.ToString());
        }

        public void visitSudoku(BaseSudoku sudoku)
        {
            foreach (var maingrid in sudoku.Grids)
            {
                if (!maingrid.isValidated)
                {
                    sudoku.isValidated = false;
                    return;
                }
            }
            sudoku.isValidated = true;
            Console.WriteLine("Sudoku validation: " + sudoku.isValidated.ToString());
        }
    }
}
