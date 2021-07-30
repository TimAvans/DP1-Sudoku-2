using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models.Sudokus
{
    public class NormalSudoku : BaseSudoku
    {
        public NormalSudoku(MainGrid grid) : base(grid) { }

        public override bool Validate()
        {
            return false;
        }
    }
}
