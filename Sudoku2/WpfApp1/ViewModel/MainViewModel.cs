using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Sudoku.Commands;
using Sudoku.Factories;
using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Sudoku.Visitor;
using System.Collections.ObjectModel;

namespace Sudoku.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private SudokuVM _sudoku;
        public SudokuVM Sudoku { get { return _sudoku; } set { _sudoku = value; RaisePropertyChanged("Sudoku"); } }
       
        private string _stateText;
        public string StateText { get { return _stateText; } set { _stateText = value; RaisePropertyChanged("StateText"); } }
        
        public ObservableCollection<string> ValidationMessages { get; set; }
        public ICommand ExecuteCustomCommand { get; set; }

        private Dictionary<string, ICustomCommand> _commands;
        public MainViewModel()
        {

            CreateCommands();

            ValidationMessages = new ObservableCollection<string>();

            ExecuteCustomCommand = new RelayCommand<string>(ExecuteCommand);

            StateText = "Change To Definitive State";

        }

        private void ExecuteCommand(string command)
        {
            _commands[command].Execute();
        }

        private void CreateCommands() 
        {
            _commands = new Dictionary<string, ICustomCommand>() {  
                { "LoadSudoku", new OpenFileCommand(this) } ,
                { "ChangeState", new ChangeGameStateCommand(this)},
                { "Validate", new ValidateCommand(this)},
                { "Solve", new SolveCommand(this) }
            };

        }
    }
}