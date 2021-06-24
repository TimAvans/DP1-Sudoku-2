﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Models;

namespace Sudoku.ViewModel
{
    public class CellVM : ViewModelBase
    {
        private Cell _cell;

        public string Value
        {
            get
            {
                return _cell.Value.ToString();
            }
            set
            {
                int temp;
                if (Int32.TryParse(value, out temp))
                {
                    if (temp <= 9 && temp >= 0)
                    {
                        _cell.Value = temp;
                        RaisePropertyChanged("Value");
                    }
                }
            }
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int size{ get { return 30; } }

        public CellVM(Cell cell) 
        {
            _cell = cell;
            X = cell.X;
            Y = cell.Y;
        }
    }
}