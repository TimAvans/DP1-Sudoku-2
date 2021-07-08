using Sudoku.Models;
using Sudoku.Models.Sudokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public interface IIrregularSudokuParser 
    {
        IIrregularSudokuParser Clone();

        BaseSudoku Parse(string filedata);
    }
}