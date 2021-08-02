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
using WpfApp1.State;
using WpfApp1.Visitor;

namespace Sudoku.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public SudokuVM Sudoku { get; set; }

        public string StateText { get; set; }
        public List<string> ValidationMessages { get; set; }

        public ICommand LoadSudokuCommand { get; set; }
        public ICommand ChangeStateCommand { get; set; }
        public ICommand ValidateCommand { get; set; }

        private ConcreteParserFactory _concreteParserFactory;

        private StateManager _stateManager;
        public MainViewModel()
        {
            LoadSudokuCommand = new RelayCommand(LoadSudoku);
            ChangeStateCommand = new RelayCommand(ChangeGameState);
            ValidateCommand = new RelayCommand(ValidateSudoku);

            ValidationMessages = new List<string>();

            StateText = "Change To Definitive State";

            _concreteParserFactory = new ConcreteParserFactory();
            _stateManager = StateManager.Instance();
        }

        private void ChangeGameState()
        {
            if (StateText.Contains("Definitive"))
            {
                _stateManager.ChangeState(new DefinitiveState());
                StateText = "Change To Help State";
            } else
            {
                _stateManager.ChangeState(new HelpState());
                StateText = "Change To Definitive State";
            }

            RaisePropertyChanged("StateText");
        }        
        
        private void ValidateSudoku()
        {
            if (Sudoku != null)
            {

                ValidationVisitor v = new ValidationVisitor();
                foreach (var maingrid in Sudoku.Grids)
                {
                    foreach (var grid in maingrid.Grids)
                    {
                        foreach (var cell in grid.Cells)
                        {
                            cell.getCell().Accept(v);
                        }
                        grid.getGrid().Accept(v);
                    }
                    maingrid.getGrid().Accept(v);
                }
                Sudoku.getSudoku().Accept(v);

                LoadValidationMessages();
            }
        }

        private void LoadValidationMessages()
        {
            List<string> strings = new List<string>();
            if (!Sudoku.getSudoku().isValidated)
            {
                foreach(MainGrid maingrid in Sudoku.getSudoku().Grids)
                {
                    if (!maingrid.isValidated)
                    {
                        strings.Add(maingrid.ValidationMessage);
                        foreach(Grid grid in maingrid.Parts)
                        {
                            if (!grid.isValidated)
                            {
                                strings.Add(grid.ValidationMessage);
                                foreach(Cell cell in grid.Parts)
                                {
                                    if (!cell.isValidated)
                                    {
                                        strings.Add(cell.ValidationMessage);
                                    }
                                }
                            }
                        }
                    }
                }
            } else
            {
                strings.Add("CONGRATULATIONS");
                strings.Add("YOU HAVE COMPLETED THE SUDOKU!");
            }
            ValidationMessages = strings;
            RaisePropertyChanged("ValidationMessages");
        }

        private void LoadSudoku()
        {
            string workingDirectory = Environment.CurrentDirectory;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "\\Files";
            if (dialog.ShowDialog() == true)
            {
                BaseSudoku sudoku;
                if (dialog.FileName.Contains("4x4") || dialog.FileName.Contains("6x6") || dialog.FileName.Contains("9x9"))
                {
                    RegularSudokuParserFactory parserFactory = (RegularSudokuParserFactory)_concreteParserFactory.Create("NormalSudoku");
                    IRegularSudokuParser parser = parserFactory.Create("normal");
                    sudoku = parser.Parse(dialog.FileName);
                }
                else
                {
                    IrregularSudokuParserFactory parserFactory = (IrregularSudokuParserFactory)_concreteParserFactory.Create("NotNormalSudoku");
                    IIrregularSudokuParser parser = parserFactory.Create(dialog.FileName.Split('.')[1]);
                    sudoku = parser.Parse(dialog.FileName);
                }

                Sudoku = new SudokuVM(sudoku);
                RaisePropertyChanged("Sudoku");
            }
        }
    }
}