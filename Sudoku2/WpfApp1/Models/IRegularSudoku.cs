﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public interface IRegularSudoku
    {
        IIrregularSudoku Clone();

        bool Validate();
    }
}