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
    public class IrregularSudokuParserFactory : AbstractParserFactory, IAbstractFactory<IIrregularSudokuParser>
    {
        private Dictionary<string, IIrregularSudokuParser> Types { get; set; }

        public const string TYPE = "NotNormalSudoku";

        public IrregularSudokuParserFactory() { 
            Types = new Dictionary<string, IIrregularSudokuParser>();
            LoadTypes();
        }

        private void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IIrregularSudokuParser)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field != null)
                    {
                        Register(field.GetValue(null).ToString(),
                        (IIrregularSudokuParser)Activator.CreateInstance(type));
                    }
                }
            }
        }

        private void Register(string type, IIrregularSudokuParser obj)
        {
            Types[type] = obj;
        }

        public IIrregularSudokuParser Create(string type)
        {
            IIrregularSudokuParser tmp = Types[type];
            return tmp.Clone();
        }

        public override AbstractParserFactory Clone()
        {
            return (IrregularSudokuParserFactory)MemberwiseClone();
        }
    }
}
