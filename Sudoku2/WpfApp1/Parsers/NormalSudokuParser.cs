using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public class NormalSudokuParser : IRegularSudokuParser
    {
        public const string TYPE = "normal";

        public IRegularSudokuParser Clone()
        {
            return (NormalSudokuParser)MemberwiseClone();
        }

        public BaseSudoku Parse(string filedata)
        {
            string line = File.ReadAllLines(filedata)[0];

            string[] colors = new string[] {
            "blue",
            "green",
            "yellow",
            "red",
            "orange",
            "cyan",
            "purple",
            "pink",
            "brown"
            };

            MainGrid board = new MainGrid(0);
            board.X = 300;
            board.Y = 100;

            int gridWidth = (int)Math.Sqrt(line.Length);
            double amt_regionrow = gridWidth / (gridWidth / Math.Floor(Math.Sqrt(gridWidth)));
            double regionrowsize = gridWidth / amt_regionrow;

            if(line.Length % gridWidth != 0)
            {
                return null;
            }

            int regBegin = 0;
            int regY = 0; //Y in region
            int regX = -1; //X in region
            int currX = -1; //X in total

            int sudokuY = 0;
            int sudokuX = -1;

            int regNumber = 0;

            Grid[] regions = new Grid[gridWidth];
            for(int i = 0; i < gridWidth; i++)
            {
                regions[i] = new Grid(i);
            }

            foreach (char c in line)
            {
                if (char.IsLetter(c))
                {
                    return null;
                }

                if (currX >= gridWidth - 1) //Go row down
                {
                    sudokuY++;
                    sudokuX = 0;
                    if (regY >= amt_regionrow - 1)
                    { //region down
                        regX = 0;
                        currX = 0;
                        regY = 0;
                        regNumber++;
                        regBegin = regNumber;
                    }
                    else //region to the left
                    {
                        regX = 0;
                        currX = 0;
                        regY++;
                        regNumber = regBegin;
                    }
                }
                else
                {
                    if (regX >= regionrowsize - 1) //region to the right
                    {
                        regX = -1;
                        regNumber++;
                    }
                    regX++;
                    currX++;
                    sudokuX++;
                }

                Cell cell = new Cell((int)Char.GetNumericValue(c), gridWidth, sudokuX, sudokuY, colors[regNumber]);
                regions[regNumber].Children.Add(cell);
            }
            
            foreach(Grid grid in regions)
            {
                board.Children.Add(grid);
            }

            return new NormalSudoku(board);
        }
    }
}
