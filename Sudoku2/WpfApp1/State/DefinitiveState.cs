using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.State
{
    public class DefinitiveState : State
    {
        public override int ChangeNumber(Cell cell, int newValue)
        {
            if(cell.NumberState == NumberType.START)
            {
                return cell.Value;
            }
            if (cell.Value == newValue)
            {
                cell.NumberState = NumberType.DEFINITIVE;
                return 0;
            }
            cell.NumberState = NumberType.DEFINITIVE;
            return newValue;
        }
    }
}
