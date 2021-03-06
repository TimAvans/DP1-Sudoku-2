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
    public class MainGridVM : ViewModelBase
    {
        private MainGrid _grid;

        private ObservableCollection<GridVM> _grids;
        public ObservableCollection<GridVM> Grids { get { return _grids; } set { _grids = value; RaisePropertyChanged("Grids"); } }

        public string ValidationMessage { get { return _grid.ValidationMessage; }}

        public int X { get { return _grid.X; } }
        public int Y { get { return _grid.Y; } }

        public MainGridVM(MainGrid grid) 
        {
            _grid = grid;
            _grids = new ObservableCollection<GridVM>();

            foreach (Grid g in grid.Children)
            {
                _grids.Add(new GridVM(g));
            }
        }
    }
}
