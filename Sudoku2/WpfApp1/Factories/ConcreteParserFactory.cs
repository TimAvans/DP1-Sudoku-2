using Sudoku.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Factories
{
    public class ConcreteParserFactory : IAbstractFactory<IParserFactory>
    {
        public Dictionary<string, IParserFactory> Types { get; set; }

        public IParserFactory Create(string type)
        {
            IParserFactory tmp = Types[type];
            return (IParserFactory)tmp.Clone();
        }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IParserFactory)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                        (IParserFactory)Activator.CreateInstance(type));
                }
            }
        }

        public void Register(string type, IParserFactory obj)
        {
            Types[type] = obj;
        }
    }
}
