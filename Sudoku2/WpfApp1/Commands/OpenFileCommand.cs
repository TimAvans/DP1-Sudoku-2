using Microsoft.Win32;
using Sudoku.Factories;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using Sudoku.State;
using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Commands
{
    public class OpenFileCommand : ICustomCommand
    {
        private ConcreteParserFactory _concreteParserFactory;
        private MainViewModel _mvm;
        public OpenFileCommand(MainViewModel mvm) 
        {
            _concreteParserFactory = new ConcreteParserFactory();
            this._mvm = mvm;
        }

        public void Execute()
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

                StateManager.Instance().HasSudokuChanged = true;
                _mvm.Sudoku = new SudokuVM(sudoku);
            }
        }
    }
}
