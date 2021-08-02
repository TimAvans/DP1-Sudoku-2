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
                cell.ValidationMessage = "    ** Cell (" + cell.X + ", " + cell.Y + ") with value " + cell.Value + " is not valid" ;
            }
            Console.WriteLine("Cell validation: " + cell.isValidated.ToString());
        }

        public void visitGrid(Grid grid)
        {
            grid.isValidated = true;
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
                        grid.ValidationMessage = " -- At grid " + grid.ID;
                        cell.isValidated = false;
                    }
                }
                else 
                {
                    grid.isValidated = false;
                    grid.ValidationMessage = " -- At grid " + grid.ID;
                }
            }
            Console.WriteLine("Grid validation: " + grid.isValidated.ToString());
        }

        public void visitMainGrid(MainGrid maingrid)
        {
            maingrid.isValidated = true;
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
                            maingrid.ValidationMessage = "At maingrid " + maingrid.ID;
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
                            maingrid.ValidationMessage = "At maingrid " + maingrid.ID;
                        }
                    }
                }
                else
                {
                    maingrid.isValidated = false;
                    maingrid.ValidationMessage = "At maingrid " + maingrid.ID;
                }
            }
            Console.WriteLine("MainGrid validation: " + maingrid.isValidated.ToString());
        }

        public void visitSudoku(BaseSudoku sudoku)
        {
            sudoku.isValidated = true;
            foreach (var maingrid in sudoku.Grids)
            {
                if (!maingrid.isValidated)
                {
                    sudoku.isValidated = false;
                }
            }
            Console.WriteLine("Sudoku validation: " + sudoku.isValidated.ToString());
        }
    }
}
