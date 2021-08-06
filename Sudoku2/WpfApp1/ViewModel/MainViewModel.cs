using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Sudoku.Factories;
using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.State;
using WpfApp1.Visitor;

namespace Sudoku.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private SudokuVM _sudoku;
        public SudokuVM Sudoku { get { return _sudoku; } set { _sudoku = value; RaisePropertyChanged("Sudoku"); } }
       
        private string _stateText;
        public string StateText { get { return _stateText; } set { _stateText = value; RaisePropertyChanged("StateText"); } }
        
        private List<string> _validationMessages;
        public List<string> ValidationMessages { get { return _validationMessages; } set { _validationMessages = value; RaisePropertyChanged("ValidationMessages"); } }
        public ICommand LoadSudokuCommand { get; set; }
        public ICommand ChangeStateCommand { get; set; }
        public ICommand ValidateCommand { get; set; }

        public MainViewModel()
        {
            //Functie creeer commands, return dictionary met commands.
            //Dan maak relay commands.
            var commands = CreateCommands();
            ValidationMessages = new List<string>();

            StateText = "Change To Definitive State";
        }

        private void solvesudoku() 
        {
            //Pak het bord.
            //Loop door alle grids.
            //Voor iedere grid loop door de cellen.
            //Check bij ieder cel of deze ingevuld is of niet.
            //Is het niet ingevuld zet het eerste nummer er neer, check of de sudoku nog klopt.
            //Klopt de sudoku ga verder naar de volgende cell, klopt de sudoku niet ga terug en pas de vorige cel aan.


            //Zie pseudo code:
            //https://bb.avans.nl/bbcswebdav/pid-2087828-dt-content-rid-69825701_1/courses/AII-2021D-INDP1/Practicumopdracht_DP1_2021_Sudoku.pdf

            //find = find_empty(bo)
            //if not find:
            //            return True
            //else:
            //    row, col = find

            //for i in range(1, 10):
            //    if valid(bo, i, (row, col)):
            //        bo[row][col] = i
            //        if solve(bo):
            //            return True
            //        bo[row][col] = 0
            //return False
        }

        private Dictionary<string, ICustomCommand> CreateCommands() 
        {
            return new Dictionary<string, ICustomCommand>() { {"Openfile", new OpenFileCommand(this) } };
        }
    }
}