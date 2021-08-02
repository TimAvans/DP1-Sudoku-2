using Sudoku.Models;
using Sudoku.Models.Sudokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Visitor
{
    public class ValidationMessageVisitor : IVisitor
    {
        public void visitCell(Cell cell)
        {
            throw new NotImplementedException();
        }

        public void visitGrid(Grid grid)
        {
            throw new NotImplementedException();
        }

        public void visitMainGrid(MainGrid maingrid)
        {
            throw new NotImplementedException();
        }

        public void visitSudoku(BaseSudoku sudoku)
        {
            throw new NotImplementedException();
        }
    }
}
