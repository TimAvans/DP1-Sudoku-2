using Sudoku.ViewModel;
using Sudoku.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Commands
{
    public class ValidateCommand : ICustomCommand
    {
        private MainViewModel _mvm;
        public ValidateCommand(MainViewModel mvm) 
        {
            this._mvm = mvm;
        }

        public void Execute()
        {
            if (_mvm.Sudoku != null)
            {
                ValidationVisitor v = new ValidationVisitor();
                _mvm.Sudoku.getSudoku().Accept(v);

                LoadValidationMessages();
            }
        }
        private void LoadValidationMessages()
        {
            _mvm.ValidationMessages = _mvm.Sudoku.getSudoku().GetValidationMessages();
        }
    }
}
