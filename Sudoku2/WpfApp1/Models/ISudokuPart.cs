using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Visitor;

namespace Sudoku.Models
{
    public interface ISudokuPart
    {
        bool IsValidated { get; set; }

        string ValidationMessage { get; }

        int X { get; }
        int Y { get; }
        void Accept(IVisitor visitor);
        List<string> GetValidationMessages();

    }
}
