using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    public class SudokuVM : ViewModelBase
    {
        private BaseSudoku _sudoku;

        private ObservableCollection<MainGridVM> _grids;
        public ObservableCollection<MainGridVM> Grids { get { return _grids; } set { _grids = value; RaisePropertyChanged("Grids"); } }

        public SudokuVM(BaseSudoku sudoku) 
        {
            _sudoku = sudoku;
            _grids = new ObservableCollection<MainGridVM>();
            foreach (Grid g in sudoku.grids)
            {
                _grids.Add(new MainGridVM(g));
            }
        }
    }
}
