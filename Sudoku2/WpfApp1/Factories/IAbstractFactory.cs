using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Factories
{
    public interface IAbstractFactory<T>
    {
        //Factory functies
        Dictionary<string, T> Types { get; set; }

        void LoadTypes();

        void Register(string type, T obj);

        T Create(string type);
    }
}
