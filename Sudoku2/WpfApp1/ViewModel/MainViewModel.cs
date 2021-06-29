using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Sudoku.Models;
using System;
using System.IO;
using System.Windows.Input;

namespace Sudoku.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public SudokuVM sudokuVM { get; set; }

        public ICommand LoadSudokuCommand { get; set; }
        public MainViewModel()
        {

            LoadSudokuCommand = new RelayCommand(LoadSudoku);

            Cell c1 = new Cell();
            c1.Value = 1;
            c1.X = 150;
            c1.Y = 150;            
            
            Cell c2 = new Cell();
            c2.Value = 2;
            c2.X = 180;
            c2.Y = 150;            
            
            Cell c3 = new Cell();
            c3.Value = 3;
            c3.X = 210;
            c3.Y = 150;            
            
            Cell c4 = new Cell();
            c4.Value = 4;
            c4.X = 150;
            c4.Y = 180;            
            
            Cell c5 = new Cell();
            c5.Value = 5;
            c5.X = 180;
            c5.Y = 180;            
            
            Cell c6 = new Cell();
            c6.Value = 6;
            c6.X = 210;
            c6.Y = 180;

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
        }

        private void LoadSudoku()
        {
            string workingDirectory = Environment.CurrentDirectory;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "\\Files";
            if (dialog.ShowDialog() == true)
            {
                //Make sudoku here
            }
        }
    }
}