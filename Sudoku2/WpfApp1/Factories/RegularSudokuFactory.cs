using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Factories
{
    public class RegularSudokuFactory : IAbstractSudokuFactory<RegularSudoku>
    {
        public Dictionary<string, RegularSudoku> Types { get; set; }

        public RegularSudoku Create()
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
