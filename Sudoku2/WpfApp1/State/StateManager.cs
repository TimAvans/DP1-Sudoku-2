using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.State
{
    public class StateManager{
        public State CurrentState { get; private set; }
        public bool HasSudokuChanged { get; set; }

        private StateManager()
        {
            CurrentState = new HelpState();
            HasSudokuChanged = false;
        }

        private static StateManager _stateManager;
        public static StateManager Instance()
        {
            if(_stateManager == null)
            {
                _stateManager = new StateManager();
            }
            return _stateManager;
        }

        public void ChangeState(State newState)
        {
            CurrentState = newState;
        }
    }
}
