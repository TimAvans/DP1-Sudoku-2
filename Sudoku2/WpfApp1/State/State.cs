using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.State
{
    public abstract class State
    {
        public abstract int ChangeNumber(Cell cell, int newValue);
    }
}
