using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Visitor;

namespace Sudoku.Models.Sudokus
{
    public class SamuraiSudoku : BaseSudoku
    {
        public SamuraiSudoku(List<MainGrid> grids) : base(grids) { }
    }
}
