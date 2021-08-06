using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace WpfApp1.Commands
{
    public class ValidateCommand : ICustomCommand
    {
        MainViewModel mvm;
        public ValidateCommand(MainViewModel mvm) 
        {
            this.mvm = mvm;
        }

        public void Execute()
        {
            if (mvm.Sudoku != null)
            {
                ValidationVisitor v = new ValidationVisitor();
                mvm.Sudoku.getSudoku().Accept(v);

                LoadValidationMessages();
            }
        }
        private void LoadValidationMessages()
        {
            mvm.ValidationMessages = mvm.Sudoku.getSudoku().GetValidationMessages();
        }
    }
}
