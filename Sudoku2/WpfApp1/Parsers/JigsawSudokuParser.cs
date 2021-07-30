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
    public class JigsawSudokuParser : IIrregularSudokuParser
    {
        public const string TYPE = "jigsaw";

        public IIrregularSudokuParser Clone()
        {
            return (JigsawSudokuParser)MemberwiseClone();
        }

        public BaseSudoku Parse(string filedata)
        {
            MainGrid board = new MainGrid();
            board.X = 100;
            board.Y = 100;

            string line = File.ReadAllLines(filedata)[0];

            string[] data = line.Split('=');

            int sudokuX = 0;
            int sudokuY = 0;
            int gridWidth = (int)Math.Sqrt(data.Length - 1);

            Grid[] regions = new Grid[gridWidth];
            for (int i = 0; i < gridWidth; i++)
            {
                regions[i] = new Grid();
            }

            for (int i = 1; i < data.Length; i++)
            {
                Cell cell = new Cell((int)Char.GetNumericValue(data[i].Split('J')[0][0]), sudokuX, sudokuY);
                regions[(int)Char.GetNumericValue(data[i].Split('J')[1][0])].Parts.Add(cell);

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
                board.Parts.Add(grid);
            }

            return new JigsawSudoku(board);
        }
    }
}
