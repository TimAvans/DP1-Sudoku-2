using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Visitor;

namespace Sudoku.Models
{
    public abstract class CompoundSudokuObject : ISudokuPart
    {
        public List<ISudokuPart> Children { get; set; }

        public List<string> ValidationMessages { get; set; }

        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsValidated { get; set; }
        public abstract string ValidationMessage { get; }

        public CompoundSudokuObject(List<ISudokuPart> grids)
        {
            Children = grids;
        }

        public CompoundSudokuObject(ISudokuPart grid)
        {
            Children = new List<ISudokuPart>();
            Children.Add(grid);
        }

        public CompoundSudokuObject()
        {
            Children = new List<ISudokuPart>();
        }

        public virtual void Accept(IVisitor visitor)
        {
            foreach(ISudokuPart child in Children)
            {
                child.Accept(visitor);
            }
        }

        public List<string> GetValidationMessages()
        {
            List<string> messages = new List<string>();

            if (!IsValidated)
            {
                messages.Add(ValidationMessage);
                foreach(ISudokuPart child in Children)
                {
                    messages.AddRange(child.GetValidationMessages());
                }
            }

            return messages;
        }
    }
}
