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
        private Grid _grid;

        private ObservableCollection<GridVM> _grids;
        public ObservableCollection<GridVM> Grids { get { return _grids; } set { _grids = value; RaisePropertyChanged("Grids"); } }

        public int X { get { return _grid.X; } set { _grid.X = value; RaisePropertyChanged("X"); } }
        public int Y { get { return _grid.Y; } set { _grid.Y = value; RaisePropertyChanged("Y"); } }

        public MainGridVM(Grid grid) 
        {
            _grid = grid;
            _grids = new ObservableCollection<GridVM>();

            foreach (Grid g in grid.Parts)
            {
                _grids.Add(new GridVM(g));
            }
        }
    }
}
