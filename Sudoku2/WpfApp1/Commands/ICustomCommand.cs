using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Commands
{
    public interface ICustomCommand
    {
        void Execute();
    }
}
