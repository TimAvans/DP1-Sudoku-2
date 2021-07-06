using Sudoku.Models;
using Sudoku.Models.Sudokus;
using Sudoku.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Factories
{
    public class IrregularSudokuParserFactory : IParserFactory<IIrregularSudokuParser>
    {
        public Dictionary<string, IIrregularSudokuParser> Types { get; set; }

        public IrregularSudokuParserFactory() { Types = new Dictionary<string, IIrregularSudokuParser>(); }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IIrregularSudokuParser)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                        (IIrregularSudokuParser)Activator.CreateInstance(type));
                }
            }
        }

        public IParserFactory<IIrregularSudokuParser> Clone()
        {
            return (IrregularSudokuParserFactory)MemberwiseClone();
        }

        public void Register(string type, IIrregularSudokuParser obj)
        {
            Types[type] = obj;
        }

        public IIrregularSudokuParser Create(string type)
        {
            IIrregularSudokuParser tmp = Types[type];
            return (IIrregularSudokuParser)tmp.Clone();
        }
    }
}
