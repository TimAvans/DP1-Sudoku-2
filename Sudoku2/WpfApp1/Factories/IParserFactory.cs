using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Factories
{
    public interface IParserFactory<T> : IAbstractFactory<T>
    {
        IParserFactory<T> Clone();
    }
}
