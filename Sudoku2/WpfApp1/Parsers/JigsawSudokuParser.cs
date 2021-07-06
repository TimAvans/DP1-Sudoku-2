using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Parsers
{
    public class JigsawSudokuParser : IIrregularSudokuParser
    {
        public IIrregularSudokuParser Clone()
        {
            return (JigsawSudokuParser)MemberwiseClone();
        }
    }
}
