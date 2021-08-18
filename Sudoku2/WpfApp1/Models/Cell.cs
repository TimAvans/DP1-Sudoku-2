using Sudoku.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class Cell : ISudokuPart
    {

        public Cell(int value, int maxvalue, int x, int y, string color)
        {
            Value = value;
            MaxValue = maxvalue;
            X = x;
            Y = y;
            Color = color;

            if (Value > 0)
            {
                NumberState = NumberType.START;
            } else
            {
                NumberState = NumberType.HELP;
            }
        }
        public int Value { get; set; }
        public int MaxValue { get; private set; }
        public string Color { get; set; }
        public NumberType NumberState { get; set; }
        public bool IsValidated { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string ValidationMessage { get {return "    ** Cell (" + X + ", " + Y + ") with value " + Value + " is not valid"; } }

        public void Accept(IVisitor visitor)
        {
            visitor.visitCell(this);
        }

        public List<string> GetValidationMessages()
        {
            return new List<string>() { ValidationMessage };
        }
    }
}
