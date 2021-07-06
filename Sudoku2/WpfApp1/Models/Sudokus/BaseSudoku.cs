using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models.Sudokus
{
    public abstract class BaseSudoku
    {
        public List<Grid> Grids { get; set; }
        
        public bool IsValidated { get; set; }

        public BaseSudoku(List<Grid> grids)
        {
            Grids = grids;
        }

        public BaseSudoku(Grid grid)
        {
            Grids = new List<Grid>();
            Grids.Add(grid);
        }

        public virtual bool Validate()
        {
            return false;
        }
    }
}
