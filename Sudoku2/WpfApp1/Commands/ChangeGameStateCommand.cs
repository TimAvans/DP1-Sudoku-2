using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.State;

namespace Sudoku.Commands
{
    public class ChangeGameStateCommand : ICustomCommand
    {
        private MainViewModel _mvm;

        public ChangeGameStateCommand(MainViewModel mvm) 
        {
            _mvm = mvm;
        }

        public void Execute()
        {
            if (_mvm.StateText.Contains("Definitive"))
            {
                StateManager.Instance().ChangeState(new DefinitiveState());
                _mvm.StateText = "Change To Help State";
            }
            else
            {
                StateManager.Instance().ChangeState(new HelpState());
                _mvm.StateText = "Change To Definitive State";
            }
        }
    }
}
