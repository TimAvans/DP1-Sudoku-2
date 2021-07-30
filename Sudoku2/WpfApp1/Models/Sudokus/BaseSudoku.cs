using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models.Sudokus
{
    public abstract class BaseSudoku : IVisitable
    {
        public List<MainGrid> Grids { get; set; }
        
        public bool isValidated { get; set; }

        public BaseSudoku(List<MainGrid> grids)
        {
            Grids = grids;
        }

        public BaseSudoku(MainGrid grid)
        {
            Grids = new List<MainGrid>();
            Grids.Add(grid);
        }

        public abstract bool Validate();

        public void Accept(IVisitor visitor)
        {
            visitor.visitSudoku(this);
        }
    }
}
