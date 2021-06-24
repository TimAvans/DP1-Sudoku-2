﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Models
{
    public class BaseSudoku : ISudoku
    {
        public List<Grid> grids { get; set; }

        public bool isValidated { get; set; }

        public virtual bool Validate()
        {
            return false;
        }
    }
}