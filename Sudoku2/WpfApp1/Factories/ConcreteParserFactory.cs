using Sudoku.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Factories
{
    public class ConcreteParserFactory : IAbstractFactory<AbstractParserFactory>
    {
        public Dictionary<string, AbstractParserFactory> Types { get; set; }

        public AbstractParserFactory Create(string type)
        {
            AbstractParserFactory tmp = Types[type];
            return (AbstractParserFactory)tmp.Clone();
        }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(AbstractParserFactory)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                    {
                        Console.WriteLine("There are no types");
                    }
                    else
                    {
                        Register(field.GetValue(null).ToString(),
                        (AbstractParserFactory)Activator.CreateInstance(type));
                    }
                }
            }
        }

        public void Register(string type, AbstractParserFactory obj)
        {
            Types[type] = obj;
        }
    }
}
