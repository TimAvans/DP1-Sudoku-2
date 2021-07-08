using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Cell : ISudokuPart
    {

        public Cell(int value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
        public int Value { get; set; }
        public bool isValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
