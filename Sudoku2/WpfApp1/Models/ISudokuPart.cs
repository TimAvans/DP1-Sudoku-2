using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public interface ISudokuPart
    {
        bool isValidated { get; set; }

        int X { get; set; }
        int Y { get; set; }

    }
}
