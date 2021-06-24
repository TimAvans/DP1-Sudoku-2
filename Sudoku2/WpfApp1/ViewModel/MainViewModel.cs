using GalaSoft.MvvmLight;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        public SudokuVM sudokuVM { get; set; }

        public MainViewModel()
        {

            Cell c1 = new Cell();
            c1.Value = 1;
            c1.X = 150;
            c1.Y = 150;            
            
            Cell c2 = new Cell();
            c1.Value = 1;
            c1.X = 170;
            c1.Y = 150;            
            
            Cell c3 = new Cell();
            c1.Value = 1;
            c1.X = 190;
            c1.Y = 150;            
            
            Cell c4 = new Cell();
            c1.Value = 1;
            c1.X = 150;
            c1.Y = 170;            
            
            Cell c5 = new Cell();
            c1.Value = 1;
            c1.X = 170;
            c1.Y = 170;            
            
            Cell c6 = new Cell();
            c1.Value = 1;
            c1.X = 190;
            c1.Y = 170;

            Grid g = new Grid();
            g.X = 150;
            g.Y = 150;


            g.Parts = new System.Collections.Generic.List<ISudokuPart>() 
            { 
                c1,c2,c3,c4,c5,c6,
            };

            Grid mg = new Grid();
            mg.X = 150;
            mg.Y = 150;

            mg.Parts = new System.Collections.Generic.List<ISudokuPart>() { g };
            RegularSudoku rs = new RegularSudoku();

            rs.grids = new System.Collections.Generic.List<Grid>() 
            {
               mg
            };

            sudokuVM = new SudokuVM(rs);
            RaisePropertyChanged("sudokuVM");
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}