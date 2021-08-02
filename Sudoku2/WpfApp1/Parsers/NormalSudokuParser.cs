﻿using Sudoku.Models;
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
            //Grid array
            // -> subrosters -> cells
            int gridWidth = (int)Math.Sqrt(line.Length);
            double amt_regionrow = gridWidth / (gridWidth / Math.Floor(Math.Sqrt(gridWidth)));
            double regionrowsize = gridWidth / amt_regionrow;

            int regBegin = 0;
            int regY = 0; //Y in region
            int regX = -1; //X in region
            int currX = -1; //X in total

            int sudokuY = 0;
            int sudokuX = -1;

            int regNumber = 0;

            //List<Dictionary<string, int>> cell_data = new List<Dictionary<string, int>>();

            Grid[] regions = new Grid[gridWidth];
            for(int i = 0; i < gridWidth; i++)
            {
                regions[i] = new Grid(i);
            }

            foreach (char c in line)
            {
                //gridwidth behaald, regeltje omlaag
                if (currX >= gridWidth - 1) //Ga row naar beneden
                {
                    sudokuY++;
                    sudokuX = 0;
                    if (regY >= amt_regionrow - 1)
                    {//regio omlaag
                        regX = 0;
                        currX = 0;
                        regY = 0;
                        regNumber++;
                        regBegin = regNumber;
                    }
                    else //regio naar links
                    {
                        regX = 0;
                        currX = 0;
                        regY++;
                        regNumber = regBegin;
                    }
                }
                else
                {
                    if (regX >= regionrowsize - 1) //regio naar rechts
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

                //cell_data.Add(new Dictionary<string, int>
                //{
                //    { "value", (int)Char.GetNumericValue(c) },
                //    { "region", regNumber},
                //    { "superregion", 0 },
                //    { "x", sudokuX },
                //    { "y", sudokuY }
                //});
            }
            
            foreach(Grid grid in regions)
            {
                board.Children.Add(grid);
            }

            //foreach (Cell cell in cells)
            //{
            //    Console.WriteLine(cell.value + ": " + cell.X + " " + cell.Y + "-----" + cell.region);
            //}

            return new NormalSudoku(board);
        }
    }
}
