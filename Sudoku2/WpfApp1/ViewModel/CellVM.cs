using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Models;
using WpfApp1.State;

namespace Sudoku.ViewModel
{
    public class CellVM : ViewModelBase
    {
        private Cell _cell;

        public string Value
        {
            get
            {
                return _cell.Value > 0 ? _cell.Value.ToString() : "";
            }
            set
            {
                int temp;
                if (Int32.TryParse(value, out temp))
                {
                    if (temp <= 9 && temp >= 0)
                    {
                        _cell.Value = StateManager.Instance().CurrentState.ChangeNumber(_cell, temp); ;
                        RaisePropertyChanged("Value");
                    }
                }
            }
        }

        private int _x, _y;
        public int X { get { return _x; } set { _x = value * Size; } }
        public int Y { get { return _y; } set { _y = value * Size; } }

        public string ValidationMessage { get { return _cell.ValidationMessage; } set { _cell.ValidationMessage = value; } }

        public NumberType NumberState { get { return _cell.NumberState; } set { _cell.NumberState = value; } }

        public int Size{ get { return 30; } }

        public CellVM(Cell cell) 
        {
            _cell = cell;
            X = cell.X;
            Y = cell.Y;
        }

        public Cell getCell()      
        {
            return _cell;
        }
    }
}
