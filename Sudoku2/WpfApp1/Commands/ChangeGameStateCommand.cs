using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.State;

namespace WpfApp1.Commands
{
    public class ChangeGameStateCommand : ICustomCommand
    {
        MainViewModel mvm;

        public ChangeGameStateCommand(MainViewModel mvm) 
        {
            this.mvm = mvm;
        }

        public void Execute()
        {
            if (mvm.StateText.Contains("Definitive"))
            {
                StateManager.Instance().ChangeState(new DefinitiveState());
                mvm.StateText = "Change To Help State";
            }
            else
            {
                StateManager.Instance().ChangeState(new HelpState());
                mvm.StateText = "Change To Definitive State";
            }
        }
    }
}
