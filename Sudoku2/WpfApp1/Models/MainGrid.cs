using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models
{
    public class MainGrid : ISudokuPart, IVisitable
    {
        public MainGrid()
        {
            Parts = new List<Grid>();
        }

        public MainGrid(int x, int y)
        {
            Parts = new List<Grid>();
            X = x;
            Y = y;
        }

        public List<Grid> Parts { get; set; }
        public bool isValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.visitMainGrid(this);
        }
    }
}
