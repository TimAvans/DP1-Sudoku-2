using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Factories
{
    public interface IAbstractSudokuFactory<T>
    {
        //Factory functies
        Dictionary<string, T> Types { get; set; }

        void LoadTypes();

        void Register();

        T Create();
    }
}
