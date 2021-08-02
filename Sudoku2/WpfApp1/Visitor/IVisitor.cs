using Sudoku.Models;
using Sudoku.Models.Sudokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Visitor
{
    public interface IVisitor
    {
        void visitCell(Cell cell);
        void visitGrid(Grid grid);
        void visitMainGrid(MainGrid maingrid);
        void visitSudoku(BaseSudoku sudoku);
    }
}
