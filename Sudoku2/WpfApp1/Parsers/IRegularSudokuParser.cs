using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public interface IRegularSudokuParser 
    {
        IRegularSudokuParser Clone();
    }
}
