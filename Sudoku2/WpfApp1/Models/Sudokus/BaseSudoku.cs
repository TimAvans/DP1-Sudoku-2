using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models.Sudokus
{
    public abstract class BaseSudoku : CompoundSudokuObject
    {       
        public BaseSudoku(List<MainGrid> grids): base(new List<ISudokuPart>(grids))
        {
        }

        public BaseSudoku(MainGrid grid) : base(grid)
        {
        }

        public override string ValidationMessage { get { return "Sudoku Incorrect: "; } }

        public override void Accept(IVisitor visitor)
        {
            base.Accept(visitor);

            visitor.visitSudoku(this);
        }

    }
}
