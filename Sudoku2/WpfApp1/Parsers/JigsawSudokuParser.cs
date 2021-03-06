using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public class JigsawSudokuParser : IIrregularSudokuParser
    {
        public const string TYPE = "jigsaw";

        public IIrregularSudokuParser Clone()
        {
            return (JigsawSudokuParser)MemberwiseClone();
        }

        public BaseSudoku Parse(string filedata)
        {
            MainGrid board = new MainGrid(0);
            board.X = 300;
            board.Y = 100;

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

            string line = File.ReadAllLines(filedata)[0];

            Match m = Regex.Match(line, "(SumoCueV1(=[0-9]J[0-9]){1,})");

            if (line.Length != m.Value.Length)
            {
                return null;
            }

            string[] data = line.Split('=');

            int sudokuX = 0;
            int sudokuY = 0;
            int gridWidth = (int)Math.Sqrt(data.Length - 1);

            Grid[] regions = new Grid[gridWidth];
            for (int i = 0; i < gridWidth; i++)
            {
                regions[i] = new Grid(i);
            }

            for (int i = 1; i < data.Length; i++)
            {
                int regNumber = (int)Char.GetNumericValue(data[i].Split('J')[1][0]);
                Cell cell = new Cell((int)Char.GetNumericValue(data[i].Split('J')[0][0]), gridWidth, sudokuX, sudokuY, colors[regNumber]);
                regions[regNumber].Children.Add(cell);

                if (sudokuX + 1 == gridWidth)
                {
                    sudokuX = 0;
                    sudokuY++;
                }
                else
                {
                    sudokuX++;
                }
            }

            foreach (Grid grid in regions)
            {
                board.Children.Add(grid);
            }

            return new JigsawSudoku(board);
        }
    }
}
