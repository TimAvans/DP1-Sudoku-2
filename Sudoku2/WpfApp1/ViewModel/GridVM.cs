using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Models;

namespace Sudoku.ViewModel
{
    public class GridVM : ViewModelBase
    {
        private Grid _grid;

        private ObservableCollection<CellVM> _cells;
        public ObservableCollection<CellVM> Cells { get { return _cells; } set { _cells = value; RaisePropertyChanged("Cells"); } }

        public GridVM(Grid grid) 
        {
            _grid = grid;
            _cells = new ObservableCollection<CellVM>();
            foreach (Cell c in grid.Parts) 
            {
                _cells.Add(new CellVM(c));
            }
        }
    }
}
