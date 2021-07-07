using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Factories
{
    public abstract class AbstractParserFactory
    {
        public abstract AbstractParserFactory Clone();
    }
}
