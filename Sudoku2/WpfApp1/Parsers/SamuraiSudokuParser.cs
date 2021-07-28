using Sudoku.Models;
using Sudoku.Models.Sudokus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public class SamuraiSudokuParser : IIrregularSudokuParser
    {
        public const string TYPE = "samurai";

        public IIrregularSudokuParser Clone()
        {
            return (SamuraiSudokuParser)MemberwiseClone();
        }

        public BaseSudoku Parse(string filedata)
        {
            List<string> file = File.ReadAllLines(filedata).ToList();

            List<Grid> boards = new List<Grid>();

            int superRegNumber = 0;

            foreach (string line in file)
            {
                int regNumber = 0;
                int gridWidth = (int)Math.Sqrt(line.Length);
                double amt_regionrow = gridWidth / (gridWidth / Math.Floor(Math.Sqrt(gridWidth)));
                double regionrowsize = gridWidth / amt_regionrow;

                int regBegin = 0;
                int regY = 0; //Y in region
                int regX = -1; //X in region
                int currX = -1; //X in total

                int sudokuY = 0;
                int sudokuX = -1;

                Grid[] regions = new Grid[gridWidth];
                for (int i = 0; i < gridWidth; i++)
                {
                    regions[i] = new Grid();
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

                    Console.WriteLine("x: " + regX + "; y: " + regY + "; reg:" + regNumber);

                    Cell cell = new Cell((int)Char.GetNumericValue(c), sudokuX, sudokuY);
                    regions[regNumber].Parts.Add(cell);
                }

                boards.Add(new Grid());
                foreach (Grid grid in regions)
                {
                    boards[superRegNumber].Parts.Add(grid);
                }
                superRegNumber++;
            }

            boards[2].Parts[0] = boards[0].Parts[8];
            boards[2].Parts[2] = boards[1].Parts[6];
            boards[2].Parts[6] = boards[3].Parts[2];
            boards[2].Parts[8] = boards[4].Parts[0];

            boards[0].X = 100;
            boards[0].Y = 100;

            boards[1].X = 460;
            boards[1].Y = 100;

            boards[2].X = 280;
            boards[2].Y = 280;

            boards[3].X = 100;
            boards[3].Y = 460;

            boards[4].X = 460;
            boards[4].Y = 460;

            return new SamuraiSudoku(boards);
        }
    }
}
