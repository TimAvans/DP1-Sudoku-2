using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Factories
{
    public class IrregularSudokuFactory : IAbstractSudokuFactory<IrregularSudoku>
    {
        public Dictionary<string, IrregularSudoku> Types { get; set; }

        public IrregularSudoku Create()
        {
            throw new NotImplementedException();
        }

        public void LoadTypes()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
