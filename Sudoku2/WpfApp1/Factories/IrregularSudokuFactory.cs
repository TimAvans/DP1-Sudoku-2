using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Factories
{
    public class IrregularSudokuFactory : IAbstractSudokuFactory<IIrregularSudoku>
    {
        public Dictionary<string, IIrregularSudoku> Types { get; set; }

        public IrregularSudokuFactory() { Types = new Dictionary<string, IIrregularSudoku>(); }

        public IIrregularSudoku Create(string type)
        {
            IIrregularSudoku tmp = Types[type];
            return tmp.Clone();
        }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IIrregularSudoku)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                        (IIrregularSudoku)Activator.CreateInstance(type));
                }
            }
        }

        public void Register(string type, IIrregularSudoku sudoku)
        {
            Types[type] = sudoku;
        }
    }
}
