using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.State
{
    public class HelpState : State
    {
        public override int ChangeNumber(Cell cell, int newValue)
        {
            if(cell.NumberState != NumberType.HELP)
            {
                return cell.Value;
            }
            if(cell.Value == newValue)
            {
                cell.NumberState = NumberType.HELP;
                return 0;
            }
            cell.NumberState = NumberType.HELP;
            return newValue;
        }
    }
}
