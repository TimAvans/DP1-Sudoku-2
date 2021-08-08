using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Models;
using Sudoku.State;

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
                    if (temp <= _cell.MaxValue && temp >= 0)
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

        public NumberType NumberState { get { return _cell.NumberState; } set { _cell.NumberState = value; RaisePropertyChanged("NumberState"); RaisePropertyChanged("ForegroundColor") ; } }

        public int Size{ get { return 30; } }

        public string Color { get { return _cell.Color; } set { _cell.Color = value; } }
        public CellVM(Cell cell) 
        {
            _cell = cell;
            X = cell.X;
            Y = cell.Y;
        }
    }
}
