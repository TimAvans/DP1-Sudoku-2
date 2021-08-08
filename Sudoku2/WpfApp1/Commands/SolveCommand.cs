using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Commands
{
    public class SolveCommand : ICustomCommand
    {
        private MainViewModel _mvm;


        public SolveCommand(MainViewModel mvm)
        {
            this._mvm = mvm;
        }

        public void Execute()
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
    }
}
