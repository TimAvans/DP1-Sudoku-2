using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Grid : ISudokuPart
    {
        public Grid()
        {
            Parts = new List<ISudokuPart>();
        }

        public Grid(int x, int y)
        {
            Parts = new List<ISudokuPart>();
            X = x;
            Y = y;
        }

        public List<ISudokuPart> Parts { get; set; }
        public bool isValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
