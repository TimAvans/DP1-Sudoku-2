using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public enum NumberType
    {
        START,
        DEFINITIVE,
        HELP
    }
    public class Cell : ISudokuPart
    {

        public Cell(int value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;

            if (Value > 0)
            {
                NumberState = NumberType.START;
            } else
            {
                NumberState = NumberType.HELP;
            }
        }
        public int Value { get; set; }
        public NumberType NumberState { get; set; }
        public bool isValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
