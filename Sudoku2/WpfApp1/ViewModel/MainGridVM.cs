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
    public class MainGridVM : ViewModelBase
    {
        private Grid _grid;

        private ObservableCollection<GridVM> _grids;
        public ObservableCollection<GridVM> Grids { get { return _grids; } set { _grids = value; RaisePropertyChanged("Grids"); } }

        public int X { get; set; }
        public int Y { get; set; }

        public MainGridVM(Grid grid) 
        {
            _grid = grid;
            X = grid.X;
            Y = grid.Y;
            _grids = new ObservableCollection<GridVM>();

            foreach (Grid g in grid.Parts)
            {
                _grids.Add(new GridVM(g));
            }
        }
    }
}
