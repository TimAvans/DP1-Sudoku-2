using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models
{
    public class MainGrid : CompoundSudokuObject
    {
        public MainGrid(int id) : base()
        {
            ID = id;
        }

        public override string ValidationMessage { get { return "At maingrid " + ID; } }

        public override void Accept(IVisitor visitor)
        {
            base.Accept(visitor);

            visitor.visitMainGrid(this);
        }
    }
}