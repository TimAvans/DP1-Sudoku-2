using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public interface ISudoku
    {
        List<Grid> grids { get; set; }
        bool isValidated { get; set; }
        bool Validate();
    }
}
