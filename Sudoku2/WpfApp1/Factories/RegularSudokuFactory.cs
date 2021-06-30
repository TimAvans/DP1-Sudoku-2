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
    public class RegularSudokuFactory : IAbstractSudokuFactory<IRegularSudoku>
    {
        public Dictionary<string, IRegularSudoku> Types { get; set; }

        public RegularSudokuFactory() { Types = new Dictionary<string, IRegularSudoku>(); }

        public IRegularSudoku Create(string type)
        {
            IRegularSudoku tmp = Types[type];
            return (IRegularSudoku)tmp.Clone();
        }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IRegularSudoku)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                        (IRegularSudoku)Activator.CreateInstance(type));
                }
            }
        }

        public void Register(string type, IRegularSudoku sudoku)
        {
            Types[type] = sudoku;
        }
    }
}
