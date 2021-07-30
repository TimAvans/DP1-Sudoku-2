﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models
{
    public class Grid : ISudokuPart, IVisitable
    {
        public Grid()
        {
            Parts = new List<Cell>();
        }

        public Grid(int x, int y)
        {
            Parts = new List<Cell>();
            X = x;
            Y = y;
        }

        public List<Cell> Parts { get; set; }
        public bool isValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.visitGrid(this);
        }
    }
}
