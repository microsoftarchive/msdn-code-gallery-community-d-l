using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager
{
    public static class Commands
    {
        public static CompositeCommand AddNewCommand = new CompositeCommand();
        public static CompositeCommand UpdateCommand = new CompositeCommand();
        public static CompositeCommand RemoveCommand = new CompositeCommand();
        public static CompositeCommand SaveCommand = new CompositeCommand();

    }
    public class CommandProxy
    {
        public virtual CompositeCommand AddNew
        {
            get { return Commands.AddNewCommand; }
        }
        public virtual CompositeCommand Update
        {
            get { return Commands.AddNewCommand; }
        }
        public virtual CompositeCommand Delete
        {
            get { return Commands.RemoveCommand; }
        }
        public virtual CompositeCommand Save
        {
            get { return Commands.SaveCommand; }
        }
    }
}
