using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class SamuraiSudoku : IIrregularSudoku
    {
        public SamuraiSudoku() { }

        public IIrregularSudoku Clone()
        {
            return (SamuraiSudoku)MemberwiseClone();
        }

        public List<Grid> grids { get; set; }

        public bool isValidated { get; set; }

        public virtual bool Validate()
        {
            return false;
        }
    }
}
