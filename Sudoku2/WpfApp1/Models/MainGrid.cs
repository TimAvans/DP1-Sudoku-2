﻿using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models
{
    public class MainGrid : ISudokuPart, IVisitable
    {
        public MainGrid(int id)
        {
            ID = id;
            Parts = new List<Grid>();
        }

        public List<Grid> Parts { get; set; }
        public bool isValidated { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        public int ID { get; set; }
        public string ValidationMessage { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.visitMainGrid(this);
        }
    }
}