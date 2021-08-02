using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

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

        public Cell(int value, int maxvalue, int x, int y)
        {
            Value = value;
            MaxValue = maxvalue;
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
        public int MaxValue { get; set; }
        public NumberType NumberState { get; set; }
        public bool IsValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
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
