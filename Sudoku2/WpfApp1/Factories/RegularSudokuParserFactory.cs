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
    public class RegularSudokuParserFactory : AbstractParserFactory, IAbstractFactory<IRegularSudokuParser>
    {
        public Dictionary<string, IRegularSudokuParser> Types { get; set; }

        public RegularSudokuParserFactory() { 
            Types = new Dictionary<string, IRegularSudokuParser>(); 
            LoadTypes(); 
        }

        public const string TYPE = "NormalSudoku";

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IRegularSudokuParser)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                    {
                        Console.WriteLine("There are no types");
                    }
                    else
                    {
                        Register(field.GetValue(null).ToString(),
                        (IRegularSudokuParser)Activator.CreateInstance(type));
                    }
                }
            }
        }



        public void Register(string type, IRegularSudokuParser obj)
        {
            Types[type] = obj;
        }

        public IRegularSudokuParser Create(string type)
        {
            IRegularSudokuParser tmp = Types[type];
            return (IRegularSudokuParser)tmp.Clone();
        }

        public override AbstractParserFactory Clone()
        {
            return (RegularSudokuParserFactory)MemberwiseClone();
        }
    }
}
