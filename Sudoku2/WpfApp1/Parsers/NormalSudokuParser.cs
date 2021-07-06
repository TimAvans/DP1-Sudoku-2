using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public class NormalSudokuParser : IRegularSudokuParser
    {
        public IRegularSudokuParser Clone()
        {
            return (NormalSudokuParser)MemberwiseClone();
        }
    }
}
