using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models.Sudokus
{
    public class JigsawSudoku : BaseSudoku
    {
        public JigsawSudoku(MainGrid grid) : base(grid) { }

        public override bool Validate()
        {
            return false;
        }
    }
}
